using LMS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Models.DTOs
{
	public class CourseDto
	{
        public CourseDto(Course course)
        {
			Id = course.Id;
			Name = course.Name;
			Description = course.Description;
			Price = course.Price;
			UserCourses = course.UserCourses;
        }
        public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public float Price { get; set; }
		public List<UserCourse> UserCourses { get; set; }
	}
}
