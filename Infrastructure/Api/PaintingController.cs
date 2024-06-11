using Application.DTO.User;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Api;

 [Route("api/[controller]")]
    [ApiController]
    public class PaintingController : ControllerBase
    {
        [HttpGet("GetAll")]
        public IActionResult GetAll([FromServices] PaintingService paintingService)
        {
            var paintings = paintingService.GetAll();
            return Ok(paintings);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(Guid id, [FromServices] PaintingService paintingService)
        {
            var painting = paintingService.GetById(id);
            if (painting == null)
                return NotFound();
            return Ok(painting);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(PaintingUploadImageRequest paintingCreateRequest, [FromServices] PaintingService paintingService)
        {
            try
            {
                var createdPainting = await paintingService.CreateAsync(paintingCreateRequest);
                return Ok(createdPainting);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromBody] PaintingUpdateRequest paintingUpdateRequest, [FromServices] PaintingService paintingService)
        {
            if (paintingUpdateRequest.Id != paintingUpdateRequest.Id)
                return BadRequest();

            var updatedPainting = await paintingService.Update(paintingUpdateRequest);
            if (updatedPainting == null)
                return NotFound();
            return Ok(updatedPainting);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(Guid id, [FromServices] PaintingService paintingService)
        {
            var deleted = paintingService.Delete(id);
            if (!deleted)
                return NotFound();
            return Ok();
        }

        [HttpGet("Ascending-Price")]
        public IActionResult GetPaintingsByAscendingPrice([FromServices] PaintingService paintingService)
        {
            var paintings = paintingService.GetPaintingsByAscendingPrice();
            return Ok(paintings);
        }
    }