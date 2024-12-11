using BetterAIS.Business.DTO;
using BetterAIS.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BetterAIS.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UzduotysController : ControllerBase
{
    private readonly IUzduotysService _uzduotysService;

    public UzduotysController(IUzduotysService uzduotysService)
    {
        _uzduotysService = uzduotysService;
    }

    [HttpGet]
    public async Task<IEnumerable<UzduotysDTO>> GetAll()
    {
        return await _uzduotysService.GetAllAsync();
    }

    [HttpGet("{id}")]
    public async Task<UzduotysDTO> GetById(int id)
    {
        return await _uzduotysService.GetByIdAsync(id);
    }

    [HttpPost]
    public async Task<IActionResult> Add([FromBody] UzduotysDTO uzduotis)
    {
        await _uzduotysService.AddAsync(uzduotis);
        return Ok();
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UzduotysDTO uzduotis)
    {
        if (id != uzduotis.IdUzduotis)
        {
            return BadRequest("ID mismatch.");
        }

        await _uzduotysService.UpdateAsync(uzduotis);
        return Ok();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _uzduotysService.DeleteAsync(id);
        return Ok();
    }
}
