using BookStore.BL.Interfaces;
using BookStore.DL.Interfaces;
using BookStore.Models.Data;
using BookStore.Models.Request;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BL.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ILogger<BookService> _logger;

        public BookService(IBookRepository bookRepository,
            ILogger<BookService> logger) 
        {
            _bookRepository= bookRepository;
            _logger= logger;
        }

        public async Task AddBook(AddBookRequest bookRequest)
        {
            var book = new Book()
            { 
                Id = Guid.NewGuid(),
                Description = bookRequest.Description,
                AuthorId = bookRequest.AuthorId,
                Title = bookRequest.Name
            };

            _bookRepository.AddBook(book);
        }

        public async Task <IEnumerable<Book>> GetAll()
        {
            var result = 
                await _bookRepository.GetAll();
            return result;
        }

        public async Task <Book?> GetById(Guid id)
        {
            var book = await _bookRepository.GetById(id);
            if (book == null) 
            {
                _logger.LogError(message: $"GetById:{id} returns null");
                return null;
            }
            return book;
        }

        public async Task DeleteBook(Guid id)
        {
            await _bookRepository.DeleteBook(id);
        }
    }
}
