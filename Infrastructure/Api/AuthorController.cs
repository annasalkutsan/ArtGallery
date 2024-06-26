using Application.DTO.User;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Infrastructure.Api;

    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        [HttpGet("GetAll")]
        public IActionResult GetAll([FromServices] AuthorService authorService)
        {
            var authors = authorService.GetAll();
            return Ok(authors);
        }

        [HttpGet("GetById")]
        public IActionResult GetById(Guid id, [FromServices] AuthorService authorService)
        {
            var author = authorService.GetById(id);
            if (author == null)
                return NotFound();
            return Ok(author);
        }
        
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] AuthorCreateRequest authorCreateRequest, [FromServices] AuthorService authorService)
        {
            try
            {
                var createdAuthor = await authorService.Create(authorCreateRequest);
                return Ok(createdAuthor);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update( [FromBody] AuthorUpdateRequest authorUpdateRequest, [FromServices] AuthorService authorService)
        {
            if (authorUpdateRequest.Id != authorUpdateRequest.Id)
                return BadRequest();

            var updatedAuthor = await authorService.Update(authorUpdateRequest);
            return Ok(updatedAuthor);
        }

        [HttpDelete("Delete")]
        public IActionResult Delete(Guid id, [FromServices] AuthorService authorService)
        {
            var deleted = authorService.Delete(id);
            if (!deleted)
                return NotFound();
            return Ok();
        }

        [HttpGet("GetPaintings")]
        public IActionResult GetPaintings(Guid id, [FromServices] AuthorService authorService)
        {
            var paintings = authorService.GetPaintings(id);
            return Ok(paintings);
        }
    }