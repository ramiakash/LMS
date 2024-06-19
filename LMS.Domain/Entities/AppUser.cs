﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LMS.Domain.Entities
{
    public class AppUser:IdentityUser
    {
        public string? Name { get; set; }
    }
}
