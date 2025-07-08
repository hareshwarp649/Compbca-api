using bca.api.Data.Entities;
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

        private readonly IHomeMasterService _homeService;

        public HomeMasterController(IHomeMasterService homeService)
        {
            _homeService = homeService;
        }

        

        // ✅ GET: api/HomeMaster
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _homeService.GetAllAsync();
            return Ok(data);
        }

        // ✅ GET: api/HomeMaster/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var data = await _homeService.GetByIdAsync(id);
            if (data == null) return NotFound();
            return Ok(data);
        }

         //✅ POST: api/HomeMaster
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] HomeMaster model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var created = await _homeService.CreateAsync(model);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // ✅ PUT: api/HomeMaster/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] HomeMaster model)
        {
            if (id != model.Id) return BadRequest("Id mismatch");
            var updated = await _homeService.UpdateAsync(model);
            return updated == null ? NotFound() : Ok(updated);
        }

        // ✅ DELETE: api/HomeMaster/{id
        // 
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _homeService.DeleteAsync(id);
            return result ? Ok("Deleted successfully") : NotFound();
            
        }

        //// ✅ POST: Upload Banner Image
        //[HttpPost("upload-banner")]
        //public async Task<IActionResult> UploadBanner([FromForm] int homeId, [FromForm] IFormFile image)
        //{
        //    var result = await _homeService.UploadBannerImageAsync(homeId, image);
        //    return result ? Ok("Banner uploaded") : BadRequest("Upload failed");
        //}

        //// ✅ POST: Upload Team Group Image
        //[HttpPost("upload-team")]
        //public async Task<IActionResult> UploadTeam([FromForm] int homeId, [FromForm] IFormFile image)
        //{
        //    var result = await _homeService.UploadTeamImageAsync(homeId, image);
        //    return result ? Ok("Team image uploaded") : BadRequest("Upload failed");
        //}

        [HttpPost]
        public async Task<IActionResult> UploadImages([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0) return BadRequest("No file uploaded");

            var result = await _homeService.UploadImageAsync(file);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateImages(int id, [FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0) return BadRequest("No file uploaded");
            var result = await _homeService.UpdateImageAsync(id, file);
            return result == null ? NotFound() : Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImages(int id)
        {
            var deleted = await _homeService.DeleteImageAsync(id);
            return deleted ? Ok() : NotFound();
        }




    }
}
