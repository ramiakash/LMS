using LMS.Application.Interfaces;
using LMS.Application.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> CreateUser(UserDTO user)
        {
            var result = await _userService.CreateUser(user);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<UserDTO>> ValidateUser(UserDTO req)
        {
            var result = await _userService.ValidateUser(req);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<UserDTO>> GetAllActiveUsers()
        {
            var result = await _userService.GetAllActiveUsers();
            return Ok(result);
        }
    }
}
