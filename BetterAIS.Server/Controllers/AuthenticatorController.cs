using BetterAIS.Business.Interfaces;
using BetterAIS.Business.Models;
using BetterAIS.Data.Validity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BetterAIS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticatorController : ControllerBase
    {
        private readonly IAuthenticatorService _authenticatorService;


        public AuthenticatorController(IAuthenticatorService authenticatorService)
        {
            _authenticatorService = authenticatorService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] LoginModel authenticatorModel)
        {
            try
            {
                var token = await _authenticatorService.Login(authenticatorModel);
                if (token == null)
                {
                    return Unauthorized();
                }
                return Ok(token);
            }
            catch (NotFoundException ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        // TODO - fix this
        [HttpPost("Logout/{token}")]
        public async Task<IActionResult> Logout(string token)
        {
            await _authenticatorService.Logout(token);
            return Ok();
        }

        [HttpPost("Verify/{verify}")]
        public async Task<IActionResult> Verify(string verify)
        {
            var result = await _authenticatorService.Verify(verify);
            return Ok(result);
        }
    }
}
