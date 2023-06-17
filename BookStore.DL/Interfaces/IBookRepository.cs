using BookStore.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DL.Interfaces
{
    public interface IBookRepository
    {
        Task <IEnumerable<Book>> GetAll();
        Task <IEnumerable<Book>> GetAllByAuthorId(Guid authorId);
        Task <Book?> GetById(Guid id);
        Task AddBook(Book book);
        Task DeleteBook(Guid id);
    }
}
