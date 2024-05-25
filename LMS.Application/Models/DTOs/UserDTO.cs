using LMS.Domain.Entities;

namespace LMS.Application.Models.DTOs
{
	public class UserDTO
	{
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string EmailId { get; set; }
		public int Status { get; set; }
		public string StatusText { get; set; }
		public int Role { get; set; }
		public string RoleText { get; set; }
		public UserDTO() { }

		public UserDTO(User user)
		{
			Id = user.Id;
			FirstName = user.FirstName;
			LastName = user.LastName;
			EmailId = user.EmailId;
			Status = (int)user.Status;
			StatusText = user.Status.ToString();
			Role = (int)user.Role;
			RoleText = user.Role.ToString();

		}
	}
}