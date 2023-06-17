using BookStore.Models.Data.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BL.Interfaces
{
    public interface IUserInfoService
    {
        Task Add(string email, string password);
        Task<UserInfo?> GetUserInfo(string email, string password);
    }
}
