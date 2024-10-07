using OldSchoolAplication.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OldSchoolAplication.Services
{
    public interface ICommandService
    {
        public Task<ResponseDto> ExecuteCommand(ProcessDtoService process);
    }
}
