using LMS.Application.Interfaces;
using LMS.Application.Models.DTOs;
using LMS.Application.Models.DTOs.AccountsDTOs;
using LMS.Application.Services;
using LMS.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserAccount _userAccounte;

        public AccountController(IUserAccount userAccount)
        {
            _userAccounte = userAccount;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(AppUserDTO userDTO)
        {
            var response = await _userAccounte.CreateAccount(userDTO);
            return Ok(response);
        }

    }
}
