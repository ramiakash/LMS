using LMS.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Entities
{
	public class Course : BaseEntity, IAuditableEntity, ISoftDeleteEntity
	{
		[Key]
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public float Price { get; set; }
		public List<User> Students { get; set; }
		public List<User> Teachers { get; set; }
		public Guid CreatedBy { get; set; }
		public DateTimeOffset CreatedOn { get; set; }
		public Guid? LastModifiedBy { get; set; }
		public DateTimeOffset? LastModifiedOn { get; set; }
		public bool IsDeleted { get; set; }
	}
}
