using OldSchoolAplication.Dto;

namespace OldSchoolApi.DTO
{
    public class ProcessDtoController
    {
        public int UserId { get; set; }
        public string Content { get; set; }
        public static ProcessDtoService ToServiceDto(ProcessDtoController process)
        {
            return new ProcessDtoService()
            {
                Content = process.Content,
                UserId = process.UserId
            };
        }
    }
}
