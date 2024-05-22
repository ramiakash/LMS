using LMS.Domain.Core.Specifications;
using LMS.Domain.Entities;
using LMS.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Domain.Specification
{
	public class UserSpecification
	{
		public static BaseSpecification<User> GetUserByEmailAndPasswordSpec(string emailId, string password)
		{
			return new BaseSpecification<User>(x => x.EmailId == emailId && x.Password == password && x.IsDeleted == false);
		}

		public static BaseSpecification<User> GetAllActiveUsersSpec()
		{
			return new BaseSpecification<User>(x => x.Status == UserStatus.Active && x.IsDeleted == false);
		}
	}
}
