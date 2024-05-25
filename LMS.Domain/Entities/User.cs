using LMS.Domain.Core.Models;
using LMS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Entities
{
	public class User : BaseEntity, IAuditableEntity, ISoftDeleteEntity
	{
		[Key]
		public Guid Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string EmailId { get; set; }
		public string PasswordHash { get; set; }
		public UserStatus Status { get; set; }
		public UserRole Role { get; set; }
		public Guid CreatedBy { get; set; }
		public DateTimeOffset CreatedOn { get; set; }
		public Guid? LastModifiedBy { get; set; }
		public DateTimeOffset? LastModifiedOn { get; set; }
		public bool IsDeleted { get; set; }

		public List<UserCourse> UserCourses { get; set; }
	}
}
