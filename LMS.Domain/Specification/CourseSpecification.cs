using LMS.Domain.Core.Specifications;
using LMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Specification
{
	public class CourseSpecification
	{
		public static BaseSpecification<Course> GetCourseById(Guid guid)
		{
			return new BaseSpecification<Course>(course => course.Id == guid);
		}
	}
}
