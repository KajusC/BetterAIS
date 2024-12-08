using System.Runtime.InteropServices;

using BetterAIS.Business.DTO;
using BetterAIS.Business.Interfaces;
using BetterAIS.Business.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BetterAIS.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PaskaitosController : ControllerBase
{
    private readonly IPaskaitosService _paskaitosService;

    public PaskaitosController(IPaskaitosService paskaitosService)
    {
        _paskaitosService = paskaitosService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _paskaitosService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id_paskaita}")]
    public async Task<IActionResult> Get(string id_paskaita)
    {
        var result = await _paskaitosService.GetByIdAsync(id_paskaita);
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] PaskaitosDTO model)
    {
        await _paskaitosService.AddAsync(model);
        return Ok();
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] PaskaitosDTO model)
    {
        await _paskaitosService.UpdateAsync(model);
        return Ok();
    }

    [HttpDelete("{id_paskaita}")]
    public async Task<IActionResult> Delete(string id_paskaita)
    {
        await _paskaitosService.DeleteAsync(id_paskaita);
        return Ok();
    }
}