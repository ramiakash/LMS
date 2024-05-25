using LMS.Application.Models.DTOs;

namespace LMS.Application.Interfaces
{
    public interface IUserService
    {
		Task<UserDTO> CreateUser(RegistrationRequestDTO req);

		Task<UserDTO> AuthenticateUser(AuthenticationRequestDTO userDto);

		Task<List<UserDTO>> GetAllActiveUsers();
    }
}