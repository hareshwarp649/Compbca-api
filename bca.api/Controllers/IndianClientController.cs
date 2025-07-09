using bca.api.DTOs;
using bca.api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bca.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IndianClientController : ControllerBase
    {
        private readonly IIndianClientService _service;

        public IndianClientController(IIndianClientService service)
        {
            _service = service;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] IndianClientCreateDTO dto)
        {
            var result = await _service.CreateAsync(dto);
            return Ok(new { message = "Client created", data = result });
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var clients = await _service.GetAllAsync();
            return Ok(clients);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var client = await _service.GetByIdAsync(id);
            return client != null ? Ok(client) : NotFound();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] IndianClientCreateDTO dto)
        {
            var result = await _service.UpdateAsync(id, dto);
            return result != null ? Ok(new { message = "Updated successfully", data = result }) : NotFound();
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await _service.DeleteAsync(id);
            return deleted ? Ok(new { message = "Deleted successfully" }) : NotFound();
        }
    }
}
