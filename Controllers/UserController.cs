using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using BasicAuthAPI.Models;
using BasicAuthAPI.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BasicAuthAPI.Controllers
{
    [Authorize(AuthenticationSchemes = "Basic")]
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize(Roles ="Customer,Admin")]
        public string SayAll()
        {
            string username = User.Identity.Name;
            return "Hello basic authentication. Username: " + username;
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public string SayAdmin()
        {
            string username = User.Identity.Name;
            return "Admin only. Hello basic authentication. Username: " + username;
        }

        [HttpGet]
        [Authorize(Roles = "Customer,Admin")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<User> GetUser(int id)
        {
            var user = await _userService.GetUserById(id);

            return user;
        }
    }
}