using bca.api.DTOs;
using bca.api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace bca.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkingGalleryController : ControllerBase
    {
        private readonly IWorkingGalleryService _service;

        public WorkingGalleryController(IWorkingGalleryService service)
        {
            _service = service;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload([FromForm] WorkingGalleryUploadDTO dto)
        {
            //var result = await _service.UploadAsync(dto);
            //return Ok(result);

            try
            {
                var result = await _service.UploadAsync(dto);
                return Ok(new
                {
                    message = "WorkingGallery uploaded successfully.",
                    data = result
                });
            }
            catch (Exception ex)
            {
                // You can log this exception to file/DB if needed
                return StatusCode(500, new
                {
                    message = "An error occurred while uploading the gallery.",
                    error = ex.Message
                });
            }
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] WorkingGalleryUploadDTO dto)
        {
            //var result = await _service.UpdateAsync(id, dto);
            //return result != null ? Ok(result) : NotFound();

            var result = await _service.UpdateAsync(id, dto);

            if (result == null)
                return NotFound(new { message = $"WorkingGallery with ID {id} not found." });

            return Ok(new
            {
                message = "WorkingGallery updated successfully.",
                data = result
            });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            //var deleted = await _service.DeleteAsync(id);
            //return deleted ? Ok() : NotFound();

            var deleted = await _service.DeleteAsync(id);

            if (!deleted)
                return NotFound(new { message = $"WorkingGallery with ID {id} not found or already deleted." });

            return Ok(new { message = "WorkingGallery deleted successfully." });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _service.GetByIdAsync(id);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpGet("by-home/{homeMasterId}")]
        public async Task<IActionResult> GetByHomeMasterId(int homeMasterId)
        {
            var result = await _service.GetByHomeMasterIdAsync(homeMasterId);
            return Ok(result);
        }
    }
}
