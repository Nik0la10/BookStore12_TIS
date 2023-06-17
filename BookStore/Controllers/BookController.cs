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
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [ProducesResponseType(
            StatusCodes.Status200OK,
            Type = typeof(IEnumerable<Book>))]
        [HttpGet(template: "GetAll")]
        public async Task <IActionResult> GetAll()
        {
            return Ok(Ok(await _bookService.GetAll()));
        }

        [ProducesResponseType(
          StatusCodes.Status200OK,
          Type = typeof(Book))]
        [ProducesResponseType(
          StatusCodes.Status400BadRequest)]
        [ProducesResponseType(
          StatusCodes.Status404NotFound)]
        [HttpGet(template: "GetById")]
        public async Task <IActionResult> GetById(Guid id)
        {
            //if (Guid.) return BadRequest(id);

            var result = await _bookService.GetById(id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost(template: "Add")]
        public async Task<IActionResult> Add([FromBody] AddBookRequest book)
        {
            await _bookService.AddBook(book);
            return Ok();
        }

        [HttpDelete(template: "Delete")]
        public async Task<IActionResult> Delete(Guid bookId)
        {
            await _bookService.DeleteBook(bookId);
            return Ok();
        }
    }
}