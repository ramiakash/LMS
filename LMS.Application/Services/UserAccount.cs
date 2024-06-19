using LMS.Application.Interfaces;
using LMS.Application.Models.DTOs;
using LMS.Application.Models.DTOs.AccountsDTOs;
using LMS.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static LMS.Application.Services.ServiceResponses;

namespace LMS.Application.Services
{
    public class UserAccount(UserManager<AppUser> userManager,
        RoleManager<IdentityRole> roleManager,
        IConfiguration config) : IUserAccount
    {
        public async Task<GeneralResponse> CreateAccount(AppUserDTO userDTO)
        {
            if (userDTO is null) return new GeneralResponse(false, "Model is empty");
            var newUser = new AppUser()
            {
                Name = userDTO.Name,
                Email = userDTO.Email,
                PasswordHash = userDTO.Password,
                UserName = userDTO.Email
            };
            var user = await userManager.FindByEmailAsync(newUser.Email);
            if (user is not null) return new GeneralResponse(false, "User Registered Alraedy");
            var createUser = await userManager.CreateAsync(newUser!, userDTO.Password);
            if (!createUser.Succeeded) return new GeneralResponse(false, "Error occured.. please try again");
            //Assign Default Role : Admin to first registrar; rest is user
            var checkAdmin = await roleManager.FindByNameAsync("Admin");
            if (checkAdmin is null)
            {
                await roleManager.CreateAsync(new IdentityRole() { Name = "Admin" });
                await userManager.AddToRoleAsync(newUser, "Admin");
                return new GeneralResponse(true, "Account Created ");

            }
            else
            {
                var checkUser = await roleManager.FindByNameAsync("Admin");
                if (checkUser is null)
                {
                    await roleManager.CreateAsync(new IdentityRole() { Name = "User" });
                }
                await userManager.AddToRoleAsync(newUser, "User");
                return new GeneralResponse(true,"Account Created");

            }
        }

        public async Task<LoginResponse> LoginAccount(AppUserDTO userDTO)
        {
            throw new NotImplementedException();
        }
    }
}
