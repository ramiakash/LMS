using LMS.Application.Interfaces;
using LMS.Application.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MyApp.WebApi.Controllers
{
	[Route("api/User/[action]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;

		public UserController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpPost]
		public async Task<ActionResult<UserDTO>> CreateUser(RegistrationRequestDTO registrationRequestDTO)
		{
			var result = await _userService.CreateUser(registrationRequestDTO);
			return Ok(result);
		}

		[HttpPost]
		public async Task<ActionResult<UserDTO>> AuthenticateUser(AuthenticationRequestDTO authenticationRequestDTO)
		{
			var result = await _userService.AuthenticateUser(authenticationRequestDTO);
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
