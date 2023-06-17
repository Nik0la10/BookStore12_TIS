using BookStore.BL.Interfaces;
using BookStore.BL.Services;
using BookStore.Models.Data;
using BookStore.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route(template: "[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [ProducesResponseType(
            StatusCodes.Status200OK,
            Type = typeof(IEnumerable<Author>))]
        [HttpGet(template: "GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(Ok(await _authorService.GetAll()));
        }

        [ProducesResponseType(
            StatusCodes.Status200OK,
            Type = typeof(Author))]
        [ProducesResponseType(
            StatusCodes.Status400BadRequest)]
        [ProducesResponseType(
            StatusCodes.Status404NotFound)]
        [HttpGet(template: "GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {
            //if (Guid.) return BadRequest(id);

            var result = await _authorService.GetById(id);

            if(result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost(template: "Add")]
        public async Task<IActionResult> Add([FromBody]AddAuthorRequest author)
        {
            await _authorService.AddAuthor(author);
            return Ok();
        }

        [HttpDelete(template: "Delete")]
        public async Task<IActionResult> Delete(Guid authorId)
        {
            await _authorService.DeleteAuthor(authorId);
            return Ok();
        }
    }
}