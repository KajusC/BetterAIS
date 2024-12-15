using BetterAIS.Business.DTO;
using BetterAIS.Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BetterAIS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentaiController : ControllerBase
    {
        private readonly IStudentaiService _studentaiService;
        private readonly IVartotojaiService _vartotojaiService;
        private readonly IPDFService _pdfService;

        public StudentaiController(IStudentaiService studentaiService,
                    IVartotojaiService vartotojaiService,
                    IPDFService pdfService)
        {
            _studentaiService = studentaiService;
            _vartotojaiService = vartotojaiService;
            _pdfService = pdfService;
        }

        [HttpGet]
        public async Task<IEnumerable<StudentaiDTO>> GetbyFilter([FromQuery] string? programosKodas)
        {
            if (programosKodas == null)
            {
                return await _studentaiService.GetAllAsync();
            }

            return await _studentaiService.GetStudentaiByProgramosKodas(programosKodas);
        }


        [HttpGet("{vidko}")]
        public async Task<StudentaiDTO> GetByVidko(string vidko)
        {
            return await _studentaiService.GetByIdAsync(vidko);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] StudentaiDTO studentaiModel)
        {

            await _studentaiService.AddAsync(studentaiModel);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] StudentaiDTO studentaiModel)
        {
            await _studentaiService.UpdateAsync(studentaiModel);
            return Ok();
        }

        [HttpPost("pdf/")]
        public async Task<IActionResult> CreatePDF([FromQuery] string path, [FromQuery] string vidko)
        {
            await _pdfService.CreatePDF(vidko, path);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _studentaiService.DeleteAsync(id);
            return Ok();
        }
    }
}
