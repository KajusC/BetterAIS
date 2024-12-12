using BetterAIS.Business.DTO;
using BetterAIS.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BetterAIS.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ModulisController : ControllerBase
{
    private readonly IModuliaiService _modulisService;

    public ModulisController(IModuliaiService modulisService)
    {
        _modulisService = modulisService;
    }

    [HttpGet]
    public async Task<IEnumerable<ModuliaiDTO>> GetAll()
    {
        return await _modulisService.GetAllAsync();
    }

    [HttpGet("{kodas}")]
    public async Task<ModuliaiDTO> GetById(string kodas)
    {
        return await _modulisService.GetByIdAsync(kodas);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] ModuliaiDTO modulis)
    {
        await _modulisService.AddAsync(modulis);
        return Ok();
    }

    [HttpPut("{kodas}")]
    public async Task<IActionResult> Update(string kodas, [FromBody] ModuliaiDTO modulis)
    {
        if (kodas != modulis.Kodas)
        {
            return BadRequest("Nesutampa kodas.");
        }

        await _modulisService.UpdateAsync(modulis);
        return Ok();
    }

    [HttpDelete("{kodas}")]
    public async Task<IActionResult> Delete(string kodas)
    {
        await _modulisService.DeleteAsync(kodas);
        return Ok();
    }
}
