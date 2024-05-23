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

		public async Task<UserDTO> CreateUser(UserDTO req)
		{
			var user = await _unitOfWork.Repository<User>().AddAsync(new User
			{
				FirstName = req.FirstName,
				LastName = req.LastName,
				EmailId = req.EmailId,
				Password = req.Password,
				Status = (UserStatus)req.Status
			});

			await _unitOfWork.SaveChangesAsync();

			//_loggerService.LogInfo("New user created");

			return new UserDTO(user);

		}

		public async Task<UserDTO> ValidateUser(UserDTO userDto)
		{
			var spec = UserSpecification.GetUserByEmailAndPasswordSpec(userDto.EmailId, userDto.Password);
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