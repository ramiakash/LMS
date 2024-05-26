using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Models.DTOs
{
	public class CourseCreationDto
	{
		public CourseDto courseDto { get; set; }
		public List<Guid> userIds { get; set; }
	}
}
