using System.Runtime.InteropServices;

using BetterAIS.Business.DTO;
using BetterAIS.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BetterAIS.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DestytojaiController : ControllerBase
{
    private readonly IDestytojaiService _destytojaiService;

    public DestytojaiController(IDestytojaiService destytojaiService)
    {
        _destytojaiService = destytojaiService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _destytojaiService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{vidko}")]
    public async Task<IActionResult> Get(string vidko)
    {
        var result = await _destytojaiService.GetByIdAsync(vidko);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] DestytojaiDTO model)
    {
        await _destytojaiService.AddAsync(model);
        return Ok();
    }

    [HttpPut("{vidko}")]
    public async Task<IActionResult> Put(string vidko, [FromBody] DestytojaiDTO model)
    {
        model.Vidko = vidko;
        await _destytojaiService.UpdateAsync(model);
        return Ok();
    }

    [HttpDelete("{vidko}")]
    public async Task<IActionResult> Delete(string vidko)
    {
        await _destytojaiService.DeleteAsync(vidko);
        return Ok();
    }
    [HttpGet("suggest-teachers/{moduleId}")]
    public async Task<IActionResult> SuggestTeachers(string moduleId)
    {
        try
        {
            var result = await _destytojaiService.GetSuggestedTeachersForModule(moduleId);
            if (result == null || !result.Any())
            {
                return NotFound(new { message = "No suitable teachers found for the selected module" });
            }

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }
    }
}