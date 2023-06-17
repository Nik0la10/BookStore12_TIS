using BookStore.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.Response
{
    public class GetAllBooksByAuthorResponse
    {
        public Author Author { get; set; }
        public IEnumerable<Book> Books { get; set; }
        
    }
}
