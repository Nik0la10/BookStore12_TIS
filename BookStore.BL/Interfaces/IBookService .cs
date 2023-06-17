using BookStore.Models.Data;
using BookStore.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BL.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAll();

        Task<Book?> GetById(Guid id);

        Task AddBook(AddBookRequest book);
        Task DeleteBook(Guid id);
    }
}
