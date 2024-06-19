using LMS.Application.Models.DTOs;
using LMS.Application.Models.DTOs.AccountsDTOs;
using static LMS.Application.Services.ServiceResponses;

namespace LMS.Application.Interfaces
{
    public interface IUserAccount
    {
        Task<GeneralResponse> CreateAccount(AppUserDTO userDTO);
        Task<LoginResponse> LoginAccount(AppUserDTO userDTO);

    }
}
