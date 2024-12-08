using BetterAIS.Business.DTO;
using BetterAIS.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BetterAIS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinansavimoTipaiController : ControllerBase
    {
        private readonly IFinansavimoTipaiService _finansavimoTipaiService;
        public FinansavimoTipaiController(IFinansavimoTipaiService finansavimoTipai)
        {
            _finansavimoTipaiService = finansavimoTipai;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _finansavimoTipaiService.GetAllAsync();
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] FinansavimoTipaiDTO model)
        {
            await _finansavimoTipaiService.AddAsync(model);
            return Ok();
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] FinansavimoTipaiDTO model)
        {
            await _finansavimoTipaiService.UpdateAsync(model);
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _finansavimoTipaiService.DeleteAsync(id);
            return Ok();
        }
    }
}
