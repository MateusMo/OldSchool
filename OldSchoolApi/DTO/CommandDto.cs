using OldSchoolAplication.Dto;

namespace OldSchoolApi.DTO
{
    public class CommandDto
    {
        public string Content { get; set; }

        public static AnonynmousDtoService ToAnonymousDtoService(CommandDto dto)
        {
            return new AnonynmousDtoService()
            {
                Content = dto.Content,
            };
        }
    }
}
