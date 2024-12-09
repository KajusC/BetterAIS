using BetterAIS.Business.DTO;
using BetterAIS.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BetterAIS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudijuProgramaController : ControllerBase
    {
        private readonly IStudijuProgramaService _studijuProgramaService;

        public StudijuProgramaController(IStudijuProgramaService studijuProgramaService)
        {
            _studijuProgramaService = studijuProgramaService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _studijuProgramaService.GetAllAsync();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var result = await _studijuProgramaService.GetByIdAsync(id);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudijuProgramaDTO model)
        {
            await _studijuProgramaService.AddAsync(model);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] StudijuProgramaDTO model)
        {
            await _studijuProgramaService.UpdateAsync(model);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _studijuProgramaService.DeleteAsync(id);
            return Ok();
        }
    }
}
