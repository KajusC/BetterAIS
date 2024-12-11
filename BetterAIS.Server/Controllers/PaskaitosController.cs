using BetterAIS.Business.DTO;
using BetterAIS.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BetterAIS.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaskaitosController : ControllerBase
{
    private readonly IPaskaitosService _paskaitosService;

    public PaskaitosController(IPaskaitosService paskaitosService)
    {
        _paskaitosService = paskaitosService;
    }

    [HttpGet]
    public async Task<IEnumerable<PaskaitosDTO>> GetAll()
    {
        return await _paskaitosService.GetAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<PaskaitosDTO> GetById(int id)
    {
        return await _paskaitosService.GetByIdAsync(id);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] PaskaitosDTO paskaita)
    {
        await _paskaitosService.AddAsync(paskaita);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] PaskaitosDTO paskaita)
    {
        if (id != paskaita.IdPaskaita)
        {
            return BadRequest("ID mismatch.");
        }

        await _paskaitosService.UpdateAsync(paskaita);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _paskaitosService.DeleteAsync(id);
        return Ok();
    }
}
