using bca.api.DTOs;
using bca.api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bca.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientTestimonialController : ControllerBase
    {
        private readonly IClientTestimonialService _service;

        public ClientTestimonialController(IClientTestimonialService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] ClientTestimonialUploadDTO dto)
        {
            var result = await _service.CreateAsync(dto);
            return Ok(new { message = "Testimonial created successfully", data = result });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            return deleted ? Ok(new { message = "Deleted successfully" }) : NotFound();
        }

        [HttpGet("top-rated")]
        public async Task<IActionResult> GetTopRated()
        {
            var result = await _service.GetTopRatedAsync();
            return Ok(result);
        }
    }
}
