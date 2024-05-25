using LMS.Domain.Entities;
using LMS.Domain.Enums;
using LMS.Application.Models.DTOs;
using LMS.Application.Interfaces;
using LMS.Application.Core.Services;
using LMS.Domain.Core.Repositories;
using LMS.Domain.Specification;

namespace LMS.Application.Services
{
	public class UserService : IUserService
	{
		private readonly IUnitOfWork _unitOfWork;
		//private readonly ILoggerService _loggerService;

		public UserService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		public async Task<UserDTO> CreateUser(RegistrationRequestDTO registrationRequestDTO)
		{

			//hash the password before sending it over to the user table
			var passwordHash = registrationRequestDTO.Password; //must do a hashing
			var user = await _unitOfWork.Repository<User>().AddAsync(new User
			{
				FirstName = registrationRequestDTO.FirstName,
				LastName = registrationRequestDTO.LastName,
				EmailId = registrationRequestDTO.EmailId,
				PasswordHash= passwordHash,
				Status = (UserStatus)registrationRequestDTO.Status,
				Role = (UserRole)registrationRequestDTO.Role
			});

			await _unitOfWork.SaveChangesAsync();

			//_loggerService.LogInfo("New user created");

			return new UserDTO(user);

		}

		public async Task<UserDTO> AuthenticateUser(AuthenticationRequestDTO authenticationRequest)
		{

			//do hash for password like so var passwordHasheed = HashPassword(authenticationRequest.Password);
			var passwordHashed = authenticationRequest.Password; //no hashing as of now
			var spec = UserSpecification.GetUserByEmailAndPasswordSpec(authenticationRequest.Email, passwordHashed);
			var user = await _unitOfWork.Repository<User>().FirstOrDefaultAsync(spec);

			if (user == null)
			{
				//_loggerService.LogInfo("User not found");

				throw new Exception("User Not Found");
			}

			if (user.Status != UserStatus.Active)
			{
				//_loggerService.LogInfo("User not active");

				throw new Exception("User Not Found");
			}

			return new UserDTO(user);
		}

		public async Task<List<UserDTO>> GetAllActiveUsers()
		{
			var spec = UserSpecification.GetAllActiveUsersSpec();

			var users = await _unitOfWork.Repository<User>().ListAsync(spec);

			return users.Select(x => new UserDTO(x)).ToList();

		}
	}
}