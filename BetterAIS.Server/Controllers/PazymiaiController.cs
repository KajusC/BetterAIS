using BetterAIS.Business.DTO;
using BetterAIS.Business.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BetterAIS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PazymiaiController : ControllerBase
    {
        private readonly IPazymiaiService _pazymiaiService;

        public PazymiaiController(IPazymiaiService pazymiaiService)
        {
            _pazymiaiService = pazymiaiService;
        }

        [HttpGet]
        public async Task<IEnumerable<PazymiaiDTO>> Get()
        {
            return await _pazymiaiService.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<PazymiaiDTO> Get(int id)
        {
            return await _pazymiaiService.GetByIdAsync(id);
        }

        [HttpGet("student/{studentId}")]
        public async Task<IActionResult> GetGradesByStudentId(string studentId)
        {
            var grades = await _pazymiaiService.GetGradesByStudentIdAsync(studentId);

            if (grades == null || !grades.Any())
                return NotFound(); // Return 404 if no grades are found

            return Ok(grades);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PazymiaiDTO pazymys)
        {
            await _pazymiaiService.AddAsync(pazymys);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] PazymiaiDTO pazymys)
        {
            pazymys.IdPazymys = id; // Ensure ID consistency
            await _pazymiaiService.UpdateAsync(pazymys);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _pazymiaiService.DeleteAsync(id);
            return Ok();
        }
    }
}
