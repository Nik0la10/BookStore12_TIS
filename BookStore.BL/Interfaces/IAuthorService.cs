using BookStore.Models.Data;
using BookStore.Models.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BL.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAll();
        Task<Author?> GetById(Guid id);
        Task<Author?> AddAuthor(AddAuthorRequest author);
        Task DeleteAuthor(Guid id);
    }
}
