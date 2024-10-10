using OldSchoolAplication.Dto;

namespace OldSchoolApi.DTO
{
    public class AnonymousDto
    {
        public string Content { get; set; }

        public static AnonynmousDtoService ToAnonymousDtoService(AnonymousDto dto)
        {
            return new AnonynmousDtoService()
            {
                Content = dto.Content,
            };
        }
    }
}
