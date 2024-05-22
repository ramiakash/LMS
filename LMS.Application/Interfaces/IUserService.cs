using LMS.Application.Models.DTOs;

namespace LMS.Application.Interfaces
{
    public interface IUserService
    {
		Task<UserDTO> CreateUser(UserDTO req);

		Task<UserDTO> ValidateUser(UserDTO userDto);

		Task<List<UserDTO>> GetAllActiveUsers();
    }
}