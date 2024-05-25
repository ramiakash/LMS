using LMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Models.DTOs
{
	public class RegistrationRequestDTO
	{
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string EmailId { get; set; }
		public string Password { get; set; }
		public int Status { get; set; }
		public string StatusText { get; set; }
		public int Role { get; set; }
		public string RoleText { get; set; }
		public RegistrationRequestDTO() { }

	}
}
