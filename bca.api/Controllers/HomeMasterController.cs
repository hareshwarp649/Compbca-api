using bca.api.Data.Entities;
using bca.api.DTOs;
using bca.api.Helpers;
using bca.api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace bca.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeMasterController : ControllerBase
    {

        private readonly IHomeMasterService _service;

        public HomeMasterController(IHomeMasterService service)
        {
            _service = service;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] HomeMasterUploadDTO dto)
        {
            var result = await _service.UploadAsync(dto);
            return Ok(result);
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] HomeMasterUploadDTO dto)
        {
            var result = await _service.UpdateAsync(id, dto);
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
            var result = await _service.GetByIdAsync(id);
            return result != null ? Ok(result) : NotFound();
        }


        //[HttpGet("with-gallery/{id}")]
        //public async Task<IActionResult> GetByIdWithGallery(int id)
        //{
        //    var result = await _service.GetByIdWithGalleryAsyncs(id);
        //    if (result == null)
        //        return NotFound(new { message = "HomeMaster not found." });

        //    return Ok(result);
        //}

    }
}
