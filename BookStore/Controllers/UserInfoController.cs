using BookStore.BL.Interfaces;
using BookStore.BL.Services;
using BookStore.Models.Data;
using BookStore.Models.Request;
using BookStore.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route(template: "[controller]")]
    public class UserInfoController : ControllerBase
    {
        private readonly IUserInfoService _userInfoService;
        public UserInfoController(IUserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }

        [HttpPost(template: "GetUserInfo")]
        public async Task<IActionResult>
             AddUserInfo(string email, string password)
        {
            if (string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password))
            {
                return BadRequest("Empty email or password!");
            }

            await _userInfoService.Add(email, password);
            return Ok();
        }

        [HttpGet(template: "GetUserInfo")]
        public async Task<IActionResult>
         GetUserInfo(string email, string password)
        {
            if (string.IsNullOrEmpty(email) ||
                string.IsNullOrEmpty(password))
            {
                return BadRequest("Empty email or password!");
            }

            var result = await _userInfoService.GetUserInfo(email, password);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

    }
}