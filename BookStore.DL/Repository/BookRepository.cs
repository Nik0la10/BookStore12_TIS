using BookStore.DL.InMemoryDB;
using BookStore.DL.Interfaces;
using BookStore.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DL.Repository
{
    public class BookRepository
    {
        //public void AddBook(Book book)
        //{
        //    DataStore.Books.Add(book);
        //}

        //public void DeleteBook(int id)
        //{
        //    var book = GetById(id);
        //    if (book != null)
        //    {
        //        DataStore.Books.Remove(book);
        //    }
        //}

        //public IEnumerable<Book> GetAll()
        //{
        //    return DataStore.Books;
        //}

        //public IEnumerable<Book> 
        //    GetAllByAuthorId(Guid authorId)
        //{
        //    return DataStore.Books;
        //        //.Where(b => b.AuthorId == authorId);
        //}

        //public Book? GetById(int id)
        //{
        //   return DataStore.Books
        //        .FirstOrDefault(x => x.Id == id);
        //}
    }
}
