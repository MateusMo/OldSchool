using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OldSchoolApi.DTO;
using OldSchoolAplication.Services;

namespace OldSchoolApi.Controllers
{
    [ApiController,Route("[controller]")]
    public class ProcessController : ControllerBase
    {
        private readonly ICommandService _commandService;
        public ProcessController(ICommandService commandService)
        {
            _commandService = commandService;
        }

        [HttpPost("anonymous"), AllowAnonymous]
        public async Task<IActionResult> AnonymousCommands([FromBody] AnonymousDto anonymous)
        {
            try
            {
                var result = await _commandService.ExecuteAnonymous(AnonymousDto.ToAnonymousDtoService(anonymous));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("command"),Authorize]
        public async Task<IActionResult> ProcessCommand([FromBody]ProcessDtoController process)
        {
            try
            {
                var result = await _commandService.ExecuteCommand(ProcessDtoController.ToServiceDto(process));
                return Ok(result);
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }
    }
}
