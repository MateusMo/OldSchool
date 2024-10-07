using OldSchoolAplication.Dto;
using OldSchoolAplication.Enum;
using OldSchoolInfrastructure.Repository;


namespace OldSchoolAplication.Services
{
    public class CommandService : ICommandService
    {
        private readonly ICommentService _commentService;
        private readonly IUserService _userService;
        private readonly IPostService _postService;
        private ProcessDtoService _processDtoService;
        private SyntaxTranslator _syntaxTranslator;
        public CommandService(ICommentService commentService, IUserService userService, IPostService postService)
        {
            _commentService = commentService;
            _userService = userService;
            _postService = postService;
            _syntaxTranslator = new SyntaxTranslator();
        }

        public async Task<ResponseDto> ExecuteCommand(ProcessDtoService process) 
        {
            UpdateProcessDto(process);
            var commandParts = process.Content.Split(' ');

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
                    return await _postService.DeleteAsync();
                case CommandContextEnum.CurrentUserWantToDeleteHisComment:
                    return await _commentService.DeleteAsync();

                case CommandContextEnum.CurrentUserWantToUpdateAccount:
                    var user = await _userService.GetByIdAsync(process.UserId);
                    if (user == null) return new ResponseDto() { Errors = ["User Not Found"] };
                    await _userService.UpdateAsync(UserDto.CommandUpdateToDomain(user, commandParts));
                    return new ResponseDto()
                    {
                        Messages = ["User Updated"]
                    };

                case CommandContextEnum.CurrentUserWantToUpdatePost:
                    return await _postService.UpdateAsync();
                case CommandContextEnum.CurrentUserWantToUpdateComment:
                    return await _commentService.UpdateAsync();

                case CommandContextEnum.CreateUser:
                    var createdUser = await _userService.AddAsync(UserDto.CommandAddToDomain(commandParts));
                    return new ResponseDto()
                    {
                        Messages = ["User created"]
                    };
                case CommandContextEnum.CreatePost:
                    return await _postService.AddAsync();
                case CommandContextEnum.CreateComment:
                    return await _commentService.AddAsync();

                case CommandContextEnum.ReadUser:
                    var ids = UserDto.CommandReadToDomain(commandParts);
                    var users = await _userService.FindAsync(x => ids.Contains(x.Id));
                    List<string> userList = new();
                    foreach (var item in users)
                    {
                        userList.Add($@"Nickname: {item.Nickname}, LastLogin: {item.LastLogin}");
                    }
                    return new ResponseDto()
                    {
                        Messages = userList.ToArray(),
                    };
                case CommandContextEnum.ReadPost:
                    return await _postService.FindAsync();
                case CommandContextEnum.ReadComment:
                    return await _commentService.FindAsync();

                case CommandContextEnum.LikePost:
                    return _postService.UpdateAsync();
                
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
    }
}
