using LMS.Application.Core.Services;
using LMS.Application.Interfaces;
using LMS.Application.Models.DTOs;
using LMS.Domain.Core.Repositories;
using LMS.Domain.Entities;
using LMS.Domain.Enums;
using LMS.Domain.Specification;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Xml.Linq;

namespace LMS.Application.Services
{
	public class CourseService : ICourseService
	{
		private readonly IUnitOfWork _unitOfWork;

		public CourseService(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
			//_loggerService = loggerService;
		}

		public async Task<CourseDto> CreateCourseAsync(CourseDto courseDto,List<Guid> userIds)
		{
			var course = await _unitOfWork.Repository<Course>().AddAsync(new Course
			{
				Id = courseDto.Id,
				Name = courseDto.Name,
				Description = courseDto.Description,
				Price = courseDto.Price,

			});
			foreach (var userId in userIds)
			{
				var UserCourse = await _unitOfWork.Repository<UserCourse>().AddAsync(new UserCourse
				{
					 CourseId = courseDto.Id,
					 UserId = userId
				});
			}
			await _unitOfWork.SaveChangesAsync();

			//_loggerService.LogInfo("New user created");

			return new CourseDto(course);
		}

		public async Task<CourseDto> DeleteCourseAsync(Guid courseId)
		{
			var spec = CourseSpecification.GetCourseById(courseId);
			var course = await _unitOfWork.Repository<Course>().FirstOrDefaultAsync(spec);
			if (course == null)
			{
				throw new KeyNotFoundException($"Course with ID {courseId} not found.");
			}
			_unitOfWork.Repository<Course>().Delete(course);

			await _unitOfWork.SaveChangesAsync();

			//_loggerService.LogInfo("New user created");

			return new CourseDto(course);
		}

		public async Task<IEnumerable<CourseDto>> GetAllCourses()
		{
			var courses = await _unitOfWork.Repository<Course>().ListAllAsync();
			return courses.Select(course => new CourseDto(course));
		}

		public async Task<CourseDto> GetCourse(Guid courseId)
		{
			var course = await _unitOfWork.Repository<Course>().GetByIdAsync(courseId);
			return new CourseDto(course);
		}

		public async Task<CourseDto> UpdateCourseAsync(CourseDto courseDto)
		{
			var course = await _unitOfWork.Repository<Course>().GetByIdAsync(courseDto.Id);

			if (course == null)
			{
				throw new KeyNotFoundException("Course not found");
			}

			course.Name = courseDto.Name;
			course.Description = courseDto.Description;
			course.Price = courseDto.Price;

			_unitOfWork.Repository<Course>().Update(course);
			await _unitOfWork.SaveChangesAsync();

			return new CourseDto(course);
		}

	}
}
