using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.Request
{
    public class AddBookRequest
    {
        public string Name { get; set; }
        public Guid AuthorId { get; set; }
        public string Description { get; set; }
    }
}
