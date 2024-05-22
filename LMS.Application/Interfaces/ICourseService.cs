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
		Task<CourseDto> AddCourse(CourseDto course);
		Task<CourseDto> ModifyCourse(CourseDto course);
		Task<CourseDto> AddStudent(UserDTO userDTO);
		Task<CourseDto> RemoveStudent(UserDTO userDTO);
		Task<CourseDto> GetEnrolledStudents(CourseDto courseDto);

	}
}
