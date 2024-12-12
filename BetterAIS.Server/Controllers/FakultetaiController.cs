using BetterAIS.Business.DTO;
using BetterAIS.Business.Interfaces;
using BetterAIS.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace BetterAIS.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FakultetaiController : ControllerBase
{
    private readonly IFakultetaiService _fakultetasService;

    public FakultetaiController(IFakultetaiService fakultetasService)
    {
        _fakultetasService = fakultetasService;
    }

    [HttpGet]
    public async Task<IEnumerable<FakultetaiDTO>> GetAll()
    {
        return await _fakultetasService.GetAllAsync();
    }

    [HttpGet("{id_fakultetas}")]
    public async Task<FakultetaiDTO> GetById(int id_fakultetas)
    {
        return await _fakultetasService.GetByIdAsync(id_fakultetas);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] FakultetaiDTO fakultetas)
    {
        await _fakultetasService.AddAsync(fakultetas);
        return Ok();
    }

    [HttpPut("{id_fakultetas}")]
    public async Task<IActionResult> Update(int id_fakultetas, [FromBody] FakultetaiDTO fakultetas)
    {
        if (id_fakultetas != fakultetas.IdFakultetas)
        {
            return BadRequest("Nesutampa kodas.");
        }

        await _fakultetasService.UpdateAsync(fakultetas);
        return Ok();
    }

    [HttpDelete("{id_fakultetas}")]
    public async Task<IActionResult> Delete(int id_fakultetas)
    {
        await _fakultetasService.DeleteAsync(id_fakultetas);
        return Ok();
    }
}
