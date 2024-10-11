using OldSchoolAplication.Dto;
using OldSchoolAplication.Enum;
using OldSchoolAplication.Jwt;
using OldSchoolInfrastructure.Repository;
using System.Diagnostics;
using System.Text.RegularExpressions;


namespace OldSchoolAplication.Services
{
    public class CommandService : ICommandService
    {
        private readonly ICommentService _commentService;
        private readonly IUserService _userService;
        private readonly IPostService _postService;
        private readonly IGetToken _getToken;
        private ProcessDtoService _processDtoService;
        private SyntaxTranslator _syntaxTranslator;
        public CommandService(ICommentService commentService, IUserService userService, IPostService postService, IGetToken getToken)
        {
            _commentService = commentService;
            _userService = userService;
            _postService = postService;
            _getToken = getToken;
            _syntaxTranslator = new SyntaxTranslator();
        }

        public async Task<ResponseDto> ExecuteAnonymous(AnonynmousDtoService anonymous)
        {
            var commandParts = SplitCommand(anonymous.Content.ToUpper());
            if (commandParts.Length == 0)
                return new ResponseDto()
                {
                    Errors = ["Empty Input."]
                };

            var context = _syntaxTranslator.IdentifyContext(commandParts);
            switch (context)
            {
                case CommandContextEnum.Login:
                    var userLogin = await _userService
                        .FindAsync(x => x.Nickname == commandParts[6] && x.PasswordHash == commandParts[8])
                        ;
                    if (userLogin == null || userLogin.Count() == 0)
                    {
                        return new ResponseDto()
                        {
                            Errors = ["You can't, sorry =( Your credentials are wrong"]
                        };
                    }
                    var tokenReturn = await _getToken.GenerateToken(userLogin.First());
                    return new ResponseDto()
                    {
                        Messages = ["logged",$"Welcome {userLogin.First().Nickname} =)", tokenReturn]
                    };
                case CommandContextEnum.CreateUser:
                    var createdUser = await _userService.AddAsync(UserDto.CommandAddToDomain(commandParts));
                    return new ResponseDto()
                    {
                        Messages = ["User created"]
                    };
                case CommandContextEnum.CommandNotFound:
                    return new ResponseDto()
                    {
                        Errors = ["Command not found."]
                    };
                default:
                    return new ResponseDto()
                    {
                        Errors = ["Command not found."]
                    };
            }
        }

        public async Task<ResponseDto> ExecuteCommand(ProcessDtoService process)
        {
            UpdateProcessDto(process);
            var commandParts = SplitCommand(process.Content.ToUpper());


            if (commandParts.Length == 0)
                return new ResponseDto()
                {
                    Errors = ["Empty Input."]
                };

            var context = _syntaxTranslator.IdentifyContext(commandParts);

            switch (context)
            {

                case CommandContextEnum.CurrentUserWantToDeleteAccount:
                    await _userService.DeleteAsync(_processDtoService.UserId);
                    return new ResponseDto()
                    {
                        Messages = ["User successfully removed"]
                    };

                case CommandContextEnum.CurrentUserWantToDeleteHisPost:
                    var postIds = PostDto.CommandDeleteToDomain(commandParts);
                    foreach (var item in postIds)
                    {
                        await _postService.DeleteAsync(item);
                    }
                    return new ResponseDto()
                    {
                        Messages = ["Post Successfully Deleted"]
                    };

                case CommandContextEnum.CurrentUserWantToDeleteHisComment:
                    var commentIds = CommentDto.CommandDeleteToDomain(commandParts);
                    foreach (var item in commentIds)
                    {
                        await _commentService.DeleteAsync(item);
                    };
                    return new ResponseDto()
                    {
                        Messages = ["Comment or Comments Deleted"]
                    };

                case CommandContextEnum.CurrentUserWantToUpdateAccount:
                    var user = await _userService.GetByIdAsync(process.UserId);
                    if (user == null) return new ResponseDto() { Errors = ["User Not Found"] };
                    await _userService.UpdateAsync(UserDto.CommandUpdateToDomain(user, commandParts));
                    return new ResponseDto()
                    {
                        Messages = ["User Updated"]
                    };

                case CommandContextEnum.CurrentUserWantToUpdatePost:
                    await _postService
                       .UpdateAsync(PostDto
                       .CommandUpdateToDomain(await _postService
                       .GetByIdAsync(_processDtoService.UserId), commandParts));

                    return new ResponseDto()
                    {
                        Messages = ["Post Successfully Updated."]
                    };
                case CommandContextEnum.CurrentUserWantToUpdateComment:
                    var commandIDs = CommentDto.GetCommentId(commandParts);
                    var comment = await _commentService.GetByIdAsync(commandIDs);
                    await _commentService.UpdateAsync(CommentDto.CommandUpdateToDomain(comment, commandParts));
                    return new ResponseDto()
                    {
                        Messages = ["Comment Updated"]
                    };

                case CommandContextEnum.CreatePost:
                    var post = await _postService.AddAsync(PostDto.CommandAddToDomain(commandParts, _processDtoService.UserId));
                    return new ResponseDto()
                    {
                        Messages = [$"Post Successfully Created. Id: {post.Id}"]
                    };
                case CommandContextEnum.CreateComment:
                    var newComments = CommentDto.CommandAddToDomain(commandParts);
                    foreach (var item in newComments)
                    {
                        await _commentService.AddAsync(item);
                    }
                    return new ResponseDto()
                    {
                        Messages = [$"Comment Or Comments Added"]
                    };
                case CommandContextEnum.ReadUser:
                    var ids = UserDto.CommandReadToDomain(commandParts);
                    var users = await _userService.FindAsync(x => ids.Contains(x.Id));
                    List<string> userList = new();
                    foreach (var item in users)
                    {
                        userList.Add($@"Id: {item.Id} Nickname: {item.Nickname}, LastLogin: {item.LastLogin}");
                    }
                    return new ResponseDto()
                    {
                        Messages = userList.ToArray(),
                    };
                case CommandContextEnum.ReadPost:
                    var idsPost = PostDto.CommandReadToDomain(commandParts);
                    var postsFromDatabase = await _postService.FindAsync(x => idsPost.Contains(x.Id));
                    List<string> formatedPosts = new();

                    foreach (var item in postsFromDatabase)
                    {
                        if (item.Links == null)
                            item.Links = "--";

                        if (item.KeyWords == null)
                            item.KeyWords = "--";

                        if (item.ASCII == null)
                            item.ASCII = "--";

                        formatedPosts.Add($"ID: {item.Id}, Likes: {item.Likes}, Content: {item.Content}, Created At: {item.CreatedAt}, Links: {item.Links}, Keywords: {item.KeyWords}, ASCII: {item.ASCII}");
                    }
                    return new ResponseDto()
                    {
                        Messages = formatedPosts.ToArray(),
                    };

                case CommandContextEnum.ReadComment:
                    var predicate = CommentDto.CommandReadToDomain(commandParts);
                    var comments = await _commentService
                                    .FindAsync(x =>
                                    x.PostId == predicate.PostId
                                    && (!predicate.DateTime.HasValue || x.CreatedAt == predicate.DateTime.Value)
                                    );
                    List<string> formatedComments = new();
                    foreach (var item in comments)
                    {
                        formatedComments.Add($"PostId: {item.PostId}, Comment: {item.Content}, CreatedAt: {item.CreatedAt}");
                    }
                    return new ResponseDto()
                    {
                        Messages = formatedComments.ToArray(),
                    };

                case CommandContextEnum.LikePost:
                    var posts = await _postService.FindAsync(x => PostDto.CommandLikeToId(commandParts).Contains(x.Id));
                    foreach (var item in posts)
                    {
                        item.Likes++;
                    }
                    foreach (var item in posts)
                    {
                        await _postService.UpdateAsync(item);
                    }
                    return new ResponseDto()
                    {
                        Messages = ["Like Added"]
                    };

                case CommandContextEnum.CommandNotFound:
                    return new ResponseDto()
                    {
                        Errors = ["Command not found."]
                    };
                default:
                    return new ResponseDto()
                    {
                        Errors = ["Command not found."]
                    };
            }
        }

        private void UpdateProcessDto(ProcessDtoService process)
        {
            _processDtoService = new ProcessDtoService();
            _processDtoService = process;
        }

        private static string[] SplitCommand(string input)
        {
            var pattern = @"'[^']*'|\S+";
            var matches = Regex.Matches(input, pattern);

            string[] result = new string[matches.Count];
            for (int i = 0; i < matches.Count; i++)
            {
                result[i] = matches[i].Value.Replace("'", "");
            }

            return result;
        }
    }
}
