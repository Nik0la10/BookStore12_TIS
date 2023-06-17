using BookStore.Models.Data;
using BookStore.Models.Data.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DL.Interfaces
{
    public interface IUserInfoRepository
    {
        Task Add(UserInfo userInfo);

        Task<UserInfo?> GetUserInfo(string email, string password);
    }
}
