using LMS.Application.Core.Models;

namespace LMS.Application.Core.Services
{
    public interface IEmailService
    {
        void SendEmail(Email email);
    }
}