using BookStore.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DL.Interfaces
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAll();
        Task<Author?> GetById(Guid id);
        Task AddAuthor(Author author);
        Task DeleteAuthor(Guid id);
    }
}
