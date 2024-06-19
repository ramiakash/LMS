using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Application.Services
{
    public class ServiceResponses
    {
        public record class GeneralResponse(bool flag,string Message);
        public record class LoginResponse(bool flag,string Token,string Message);
    }
}
