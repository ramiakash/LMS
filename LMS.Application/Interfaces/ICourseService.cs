using LMS.Application.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Interfaces
{
	public interface ICourseService
	{
		Task<CourseDto> CreateCourseAsync(CourseDto courseDto, List<Guid> userIds);
		Task<CourseDto> UpdateCourseAsync(CourseDto courseDto);
		Task<CourseDto> DeleteCourseAsync(Guid courseId);
		Task<IEnumerable<CourseDto>> GetAllCourses();
		Task<CourseDto> GetCourse(Guid courseId);

	}
}
