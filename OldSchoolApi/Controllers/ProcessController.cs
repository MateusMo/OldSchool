using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OldSchoolApi.DTO;
using OldSchoolAplication.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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
        public async Task<IActionResult> AnonymousCommands([FromBody] CommandDto anonymous)
        {
            try
            {
                var result = await _commandService.ExecuteAnonymous(CommandDto.ToAnonymousDtoService(anonymous));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("command"),Authorize]
        public async Task<IActionResult> ProcessCommand([FromBody]CommandDto process)
        {
            try
            {
                var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var result = await _commandService.ExecuteCommand(new OldSchoolAplication.Dto.ProcessDtoService()
                {
                   Content = process.Content,
                   UserId = int.Parse(userId),
                });
                return Ok(result);
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }
    }
}
