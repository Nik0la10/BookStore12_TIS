using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.Data.Users
{
    public class UserInfo
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
