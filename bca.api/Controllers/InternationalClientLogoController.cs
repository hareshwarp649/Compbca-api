using bca.api.DTOs;
using bca.api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bca.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InternationalClientLogoController : ControllerBase
    {
        private readonly IInternationalClientLogoService _service;

        public InternationalClientLogoController(IInternationalClientLogoService service)
        {
            _service = service;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] InternationalClientLogoUploadDTO dto)
        {
            var result = await _service.UploadAsync(dto);
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Update([FromForm] InternationalClientLogoUpdateDTO dto)
        {
            var result = await _service.UpdateAsync(dto);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            return deleted ? Ok() : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var logo = await _service.GetByIdAsync(id);
            return logo != null ? Ok(logo) : NotFound();
        }

    }
}
