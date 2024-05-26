using LMS.Application.Interfaces;
using LMS.Application.Models.DTOs;
using LMS.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LMS.WebAPI.Controllers
{
	[Route("api/Course/[action]")]
	[ApiController]
	public class CourseController : ControllerBase
	{
		private readonly ICourseService _courseService;
		public CourseController(ICourseService courseService)
		{
			_courseService = courseService;
		}
		[HttpPut]
		public async Task<ActionResult<CourseDto>> UpdateCourseAsync(CourseDto courseDto)
		{
			var result = await _courseService.UpdateCourseAsync(courseDto);
			return Ok(result);
		}
		[HttpPost]
		public async Task<ActionResult<CourseDto>> CreateCourseAsync([FromBody] CourseCreationDto courseCreationDto)
		{
			var result = await _courseService.CreateCourseAsync(courseCreationDto.courseDto, courseCreationDto.userIds);
			return Ok(result);
		}
		[HttpGet]
		public async Task<ActionResult<CourseDto>> GetCourse(Guid guid)
		{
			var result = await _courseService.GetCourse(guid);
			return Ok(result);
		}
		[HttpDelete]
		public async Task<ActionResult<CourseDto>> DeleteCourseAsync(Guid guid)
		{
			var result = await _courseService.DeleteCourseAsync(guid);
			return Ok(result);
		}
	}
}
