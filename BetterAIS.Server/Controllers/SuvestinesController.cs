using BetterAIS.Business.DTO;
using BetterAIS.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BetterAIS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuvestinesController : ControllerBase
    {
        private readonly ISuvestinesService _suvestinesService;

        public SuvestinesController(ISuvestinesService suvestinesService)
        {
            _suvestinesService = suvestinesService;
        }

        [HttpGet]
        public async Task<IEnumerable<SuvestinesDTO>> Get()
        {
            return await _suvestinesService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<SuvestinesDTO> Get(int id)
        {
            return await _suvestinesService.GetByIdAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SuvestinesDTO suvestinesModel)
        {

            await _suvestinesService.AddAsync(suvestinesModel);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] SuvestinesDTO suvestinesModel)
        {
            await _suvestinesService.UpdateAsync(suvestinesModel);
            return Ok();
        }
    }
}
