using LMS.Domain.Core.Specifications;
using LMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Specification
{
	public class UserCourseSpecification
	{
		public static BaseSpecification<UserCourse> GetStudentsForCourseSpec(Guid courseId)
		{
			return new BaseSpecification<UserCourse>(UserCourse => UserCourse.CourseId == courseId && UserCourse.User.Role == Enums.UserRole.Student);
		}

		public static BaseSpecification<UserCourse> GetTeachersForCourseSpec(Guid courseId)
		{
			return new BaseSpecification<UserCourse>(UserCourse => UserCourse.CourseId == courseId && (UserCourse.User.Role == Enums.UserRole.Admin || UserCourse.User.Role == Enums.UserRole.Instructor));
		}
		public static BaseSpecification<UserCourse> GetUsersForCourseSpec(Guid courseId)
		{
			return new BaseSpecification<UserCourse>(UserCourse => UserCourse.CourseId == courseId);
		}
	}

}
