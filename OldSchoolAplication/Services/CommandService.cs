using OldSchoolAplication.Dto;
using OldSchoolAplication.Enum;
using OldSchoolAplication.Syntax;
using OldSchoolInfrastructure.Repository;


namespace OldSchoolAplication.Services
{
    public class CommandService : ICommandService
    {
        private readonly ICommentRepository _commentRepository;
        private readonly IPostRepository _postRepository;
        private readonly IUserRepository _userRepository;
        private ProcessDtoService _processDtoService;
        private SyntaxTranslator _syntaxTranslator;
        public CommandService(ICommentRepository commentRepository,IPostRepository postRepository, IUserRepository userRepository)
        {
            _commentRepository = commentRepository;
            _postRepository = postRepository;
            _userRepository = userRepository;
            _syntaxTranslator = new SyntaxTranslator();
        }

        public async Task<string> ExecuteCommand(ProcessDtoService process) 
        {
            UpdateProcessDto(process);
            var commandParts = process.Content.Split(' ');

            if (commandParts.Length == 0)
                return "Invalid command.";

            var context = _syntaxTranslator.IdentifyContext(commandParts);

            switch (context)
            {
                case CommandContextEnum.CurrentUserWantToDeleteAccount:
                    return await DeleteUser(process.UserId);

                case CommandContextEnum.CurrentUserWantToUpdateAccount:
                    return await UpdateUser(commandParts, process.UserId);

                // Você pode expandir para outros contextos, como criar posts, deletar comentários, etc.

                default:
                    return "Comando não encontrado.";
            }
        }

        private void UpdateProcessDto(ProcessDtoService process)
        {
            _processDtoService = new ProcessDtoService();
            _processDtoService = process;
        }
    }
}
