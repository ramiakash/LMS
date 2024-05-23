using LMS.Application.Core.Services;
using LMS.Application.Interfaces;
using LMS.Application.Models.DTOs;
using LMS.Domain.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Services
{
	public class CourseService : ICourseService
	{
		private readonly IUnitOfWork _unitOfWork;
		 
        public CourseService(IUnitOfWork unitOfWork )
		{
			_unitOfWork = unitOfWork;
			//_loggerService = loggerService;
		}
	 
        public Task<CourseDto> AddCourse(CourseDto course)
		{
			throw new NotImplementedException();
		}

		public Task<CourseDto> AddStudent(UserDTO userDTO)
		{
			throw new NotImplementedException();
		}

		public Task<CourseDto> GetEnrolledStudents(CourseDto courseDto)
		{
			throw new NotImplementedException();
		}

		public Task<CourseDto> ModifyCourse(CourseDto course)
		{
			throw new NotImplementedException();
		}

		public Task<CourseDto> RemoveStudent(UserDTO userDTO)
		{
			throw new NotImplementedException();
		}
	}
}
