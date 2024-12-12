using BetterAIS.Business.DTO;
using BetterAIS.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BetterAIS.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class KabinetaiController : ControllerBase
{
    private readonly IKabinetaiService _kabinetasService;

    public KabinetaiController(IKabinetaiService kabinetasService)
    {
        _kabinetasService = kabinetasService;
    }

    [HttpGet]
    public async Task<IEnumerable<KabinetaiDTO>> GetAll()
    {
        return await _kabinetasService.GetAllAsync();
    }

    [HttpGet("{id_kabinetas}")]
    public async Task<KabinetaiDTO> GetById(int id_kabinetas)
    {
        return await _kabinetasService.GetByIdAsync(id_kabinetas);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] KabinetaiDTO kabinetas)
    {
        await _kabinetasService.AddAsync(kabinetas);
        return Ok();
    }

    [HttpPut("{id_kabinetas}")]
    public async Task<IActionResult> Update(int id_kabinetas, [FromBody] KabinetaiDTO kabinetas)
    {
        if (id_kabinetas != kabinetas.IdKabinetas)
        {
            return BadRequest("Nesutampa kodas.");
        }

        await _kabinetasService.UpdateAsync(kabinetas);
        return Ok();
    }

    [HttpDelete("{id_kabinetas}")]
    public async Task<IActionResult> Delete(int id_kabinetas)
    {
        await _kabinetasService.DeleteAsync(id_kabinetas);
        return Ok();
    }
}
