using OldSchoolAplication.Dto;
using OldSchoolAplication.Enum;
using OldSchoolAplication.Jwt;
using OldSchoolInfrastructure.Repository;
using System.Diagnostics;
using System.Text.RegularExpressions;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;


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
                    return await LoginContext(commandParts);
               
                case CommandContextEnum.CreateUser:
                    return await CreateUserContext(commandParts);

                case CommandContextEnum.CommandNotFound:
                    return await NotFoundContext();
                default:
                    return await NotFoundContext();
            }
        }

        public async Task<ResponseDto> ExecuteCommand(ProcessDtoService process)
        {
            UpdateProcessDto(process);
            var commandParts = SplitCommand(process.Content.ToUpper());

            if (commandParts.Length == 0)
                return await EmptyCommandContext();

            var context = _syntaxTranslator.IdentifyContext(commandParts);

            switch (context)
            {
                case CommandContextEnum.CurrentUserWantToDeleteAccount:
                    return await DeleteAccountContext();

                case CommandContextEnum.CurrentUserWantToDeleteHisPost:
                    return await DeletepostContext(commandParts);

                case CommandContextEnum.CurrentUserWantToDeleteHisComment:
                    return await DeleteCommentContext(commandParts);

                case CommandContextEnum.CurrentUserWantToUpdateAccount:
                    return await UpdateUserContext(commandParts);

                case CommandContextEnum.CurrentUserWantToUpdatePost:
                    return await UpdatePostContext(commandParts);

                case CommandContextEnum.CurrentUserWantToUpdateComment:
                    return await UpdateCommentContext(commandParts);

                case CommandContextEnum.ReadMe:
                    return await ReadMeContext(commandParts);

                case CommandContextEnum.CreatePost:
                    return await CreatePostContext(commandParts);

                case CommandContextEnum.CreateComment:
                    return await CreateCommentContext(commandParts);

                case CommandContextEnum.ReadUser:
                    return await ReadUserContext(commandParts);

                case CommandContextEnum.ReadPost:
                    return await ReadPostContext(commandParts);

                case CommandContextEnum.ReadComment:
                    return await ReadCommentContext(commandParts);

                case CommandContextEnum.ReadCommentById:
                    return await ReadCommentByIdContext(commandParts);

                case CommandContextEnum.LikePost:
                    return await LikePostContext(commandParts);

                case CommandContextEnum.CommandNotFound:
                    return await NotFoundContext();

                default:
                    return await NotFoundContext();
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

        private async Task<ResponseDto> LoginContext(string[] commandParts)
        {
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
                Messages = ["logged", $"Welcome {userLogin.First().Nickname} =)", tokenReturn]
            };
        }
        private async Task<ResponseDto> CreateUserContext(string[] commandParts)
        {
            var createdUser = await _userService.AddAsync(UserDto.CommandAddToDomain(commandParts));
            return new ResponseDto()
            {
                Messages = ["User created"]
            };
        }
        private async Task<ResponseDto> NotFoundContext()
        {
            return new ResponseDto()
            {
                Errors = ["Command not found."]
            };
        }
        private async Task<ResponseDto> EmptyCommandContext()
        {
            return new ResponseDto()
            {
                Errors = ["Empty Input."]
            };

        }
        private async Task<ResponseDto> DeleteAccountContext()
        {
            await _userService.DeleteAsync(_processDtoService.UserId);
            return new ResponseDto()
            {
                Messages = ["User successfully removed"]
            };
        }
        private async Task<ResponseDto> DeletepostContext(string[] commandParts)
        {
            var postIds = PostDto.CommandDeleteToDomain(commandParts);
            var posts = await _postService.FindAsync(x => postIds.Contains(x.Id));
            foreach (var item in posts)
            {
                if(item.UserId != _processDtoService.UserId)
                {
                    return new ResponseDto()
                    {
                        Messages = ["You can delete only your posts"]
                    };
                }
            }

            foreach (var item in postIds)
            {
                await _postService.DeleteAsync(item);
            }
            return new ResponseDto()
            {
                Messages = ["Post Successfully Deleted"]
            };
        }
        private async Task<ResponseDto> DeleteCommentContext(string[] commandParts)
        {
            var commentIds = CommentDto.CommandDeleteToDomain(commandParts);
            foreach (var item in commentIds)
            {
                await _commentService.DeleteAsync(item);
            };
            return new ResponseDto()
            {
                Messages = ["Comment or Comments Deleted"]
            };
        }
        private async Task<ResponseDto> UpdateUserContext(string[] commandParts)
        {
            var commandIDs = CommentDto.GetCommentId(commandParts);
            var comment = await _commentService.GetByIdAsync(commandIDs);
            await _commentService.UpdateAsync(CommentDto.CommandUpdateToDomain(comment, commandParts));
            return new ResponseDto()
            {
                Messages = ["Comment Updated"]
            };
        }
        private async Task<ResponseDto> UpdatePostContext(string[] commandParts)
        {
            var postId = PostDto.GetPostIdToUpdate(commandParts);
            var postToUpdate = await _postService.GetByIdAsync(postId);
            await _postService
               .UpdateAsync(PostDto
               .CommandUpdateToDomain(postToUpdate, commandParts));
            return new ResponseDto()
            {
                Messages = ["Post Successfully Updated."]
            };
        }
        private async Task<ResponseDto> UpdateCommentContext(string[] commandParts)
        {
            var commandIDs = CommentDto.GetCommentId(commandParts);
            var comment = await _commentService.GetByIdAsync(commandIDs);
            await _commentService.UpdateAsync(CommentDto.CommandUpdateToDomain(comment, commandParts));
            return new ResponseDto()
            {
                Messages = ["Comment Updated"]
            };
        }
        private async Task<ResponseDto> ReadMeContext(string[] commandParts)
        {
            var readUser = await _userService.GetByIdAsync(_processDtoService.UserId);
            if(readUser == null)
            {
                return new ResponseDto()
                {
                    Messages = ["User doesn't exist."]
                };
            }
            var posts = await _postService.FindAsync(x => x.UserId == _processDtoService.UserId);
            return new ResponseDto()
            {
                Messages = [$"Id: {readUser.Id}, Nickname: {readUser.Nickname}, CreatedAt: {readUser.CreatedAt}, UpdatedAt: {readUser.UpdatedAt}, LastLogin: {readUser.LastLogin}, TotalPosts: {posts.Count()}, TotalLikes: {posts.Sum(x => x.Likes)}"]
            };

        }
        private async Task<ResponseDto> CreatePostContext(string[] commandParts)
        {
            var post = await _postService.AddAsync(PostDto.CommandAddToDomain(commandParts, _processDtoService.UserId));
            return new ResponseDto()
            {
                Messages = [$"Post Successfully Created. Id: {post.Id}"]
            };
        }
        private async Task<ResponseDto> CreateCommentContext(string[] commandParts)
        {
            var newComments = CommentDto.CommandAddToDomain(commandParts,_processDtoService.UserId);
            foreach (var item in newComments)
            {
                await _commentService.AddAsync(item);
            }
            return new ResponseDto()
            {
                Messages = [$"Comment Added"]
            };
        }
        private async Task<ResponseDto> ReadUserContext(string[] commandParts)
        {
            var ids = UserDto.CommandReadToDomain(commandParts);
            if (ids.Count() > 200)
            {
                return new ResponseDto()
                {
                    Messages = ["Your range must have only 200 ids between the first and last value."],
                };
            }
            var postsFromUsers = await _postService.FindAsync(x => ids.Contains(x.UserId));
            var users = await _userService.FindAsync(x => ids.Contains(x.Id));
            List<string> userList = new();
            foreach (var item in users)
            {
                userList.Add($@"Id: {item.Id}, Nickname: {item.Nickname}, TotalPosts: {postsFromUsers.Where(x => x.UserId == item.Id).Count()}, TotalLikes: {postsFromUsers.Where(x => x.UserId == item.Id).Sum(x => x.Likes)},LastLogin: {item.LastLogin}, Last Update: {item.UpdatedAt} ,Created At: {item.CreatedAt}");
            }
            return new ResponseDto()
            {
                Messages = userList.ToArray(),
            };
        }
        private async Task<ResponseDto> ReadPostContext(string[] commandParts)
        {
            var idsPost = PostDto.CommandReadToDomain(commandParts);
            var postsFromDatabase = await _postService.FindAsync(x => idsPost.Contains(x.Id));
            if (postsFromDatabase.Count() == 0)
            {
                return new ResponseDto()
                {
                    Messages = ["No posts were found"]
                };
            }
            List<string> formatedPosts = new();

            foreach (var item in postsFromDatabase)
            {
                formatedPosts.Add($"ID: {item.Id}, UserID: {item.UserId}, Likes: {item.Likes}, Content: {item.Content}, CreatedAt: {item.CreatedAt}, UpdatedAt: {item.UpdatedAt}");
            }
            return new ResponseDto()
            {
                Messages = formatedPosts.ToArray(),
            };
        }
        private async Task<ResponseDto> ReadCommentContext(string[] commandParts)
        {
            var predicate = CommentDto.CommandReadToDomain(commandParts);
            var comments = await _commentService
                            .FindAsync(x =>
                            x.PostId == predicate.PostId
                            && (!predicate.DateTime.HasValue || x.CreatedAt == predicate.DateTime.Value)
                            );
            if (comments.Count() == 0)
            {
                return new ResponseDto()
                {
                    Messages = ["No comments were found."]
                };
            }
            List<string> formatedComments = new();
            foreach (var item in comments)
            {
                formatedComments.Add($"PostId: {item.PostId}, UserId: {item.UserId} ,Comment: {item.Content}, CreatedAt: {item.CreatedAt}, UpdatedAt: {item.UpdatedAt}");
            }
            return new ResponseDto()
            {
                Messages = formatedComments.ToArray(),
            };

        }
        private async Task<ResponseDto> ReadCommentByIdContext(string[] commandParts)
        {
            var commentIdss = CommentDto.GetCommentIds(commandParts);
            var commentsReturn = await _commentService.FindAsync(x => commentIdss.Contains(x.CommentId));
            if (commentsReturn.Count() == 0)
            {
                return new ResponseDto()
                {
                    Messages = ["No comments were found"]
                };
            }
            List<string> formatedCommentsReturn = new();
            foreach (var item in commentsReturn)
            {
                formatedCommentsReturn.Add($"PostId: {item.PostId}, Comment: {item.Content}, CreatedAt: {item.CreatedAt}, UpdatedAt: {item.UpdatedAt}");
            }
            return new ResponseDto()
            {
                Messages = formatedCommentsReturn.ToArray(),
            };
        }
        private async Task<ResponseDto> LikePostContext(string[] commandParts)
        {
            if (commandParts.Any(x => x.Contains("...")))
            {
                return new ResponseDto()
                {
                    Messages = ["The operator ... is not avaiable to likes. Choose specific ids to like."]
                };
            }
            var postsToLike = await _postService.FindAsync(x => PostDto.CommandLikeToId(commandParts).Contains(x.Id));
            foreach (var item in postsToLike)
            {
                item.Likes++;
            }
            foreach (var item in postsToLike)
            {
                await _postService.UpdateAsync(item);
            }
            return new ResponseDto()
            {
                Messages = ["Like Added"]
            };
        }
    }
}
