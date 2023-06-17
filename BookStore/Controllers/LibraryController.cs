using BookStore.BL.Interfaces;
using BookStore.BL.Services;
using BookStore.Models.Data;
using BookStore.Models.Request;
using BookStore.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route(template: "[controller]")]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _libraryService;
        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }

        [HttpGet(template: "GetAllBooksByAuthor")]
        public async Task<IActionResult>
            GetAllBooksByAuthor(Guid authorId)
            {
                var result =
                    await _libraryService.GetAllBooksByAuthor(authorId);

                if (result?.Author == null) return NotFound(authorId);

                return Ok(result);
            }
    }
}