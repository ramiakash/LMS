using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Entities
{
	public class UserCourse
	{
		public Guid CourseId { get; set; }
		public Course Course { get; set; }

		public Guid UserId { get; set; }
		public User User { get; set; }
	}
}
