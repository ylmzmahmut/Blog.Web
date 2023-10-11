using BlogWeb.Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

using AutoMapper;
using BlogWeb.Entity.DTOs.Users;
using BlogWeb.Service.Services.Concretes;
using BlogWeb.Service.Services.Abstractions;
using System.ComponentModel.DataAnnotations;
using FluentValidation;
using BlogWeb.Service.Extensions;

namespace BlogWeb.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly IMapper mapper;
        private readonly IUserService userService;
        private readonly IValidator<AppUser> validator;

        public UserController(UserManager<AppUser> userManager, IMapper mapper, IUserService userService,IValidator<AppUser> validator)
        {
            this.userManager = userManager;
            this.mapper = mapper;
            this.userService = userService;
            this.validator = validator;
        }
        public async Task<IActionResult> Index()
        {
            var result = await userService.GetAllUsersWithRoleAsync();
            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var roles = await userService.GetAllRolesAsync();
            return View(new UserAddDTO { Roles = roles });
        }


        [HttpPost]
        public async Task<IActionResult> Add(UserAddDTO userAddDto)
        {
            var map = mapper.Map<AppUser>(userAddDto);
            var validation = await validator.ValidateAsync(map);
            var roles = await userService.GetAllRolesAsync();

            if (ModelState.IsValid)
            {
                var result = await userService.CreateUserAsync(userAddDto);
                
                if (result.Succeeded)
                {
                    
                    return RedirectToAction("Index", "User", new { Area = "Admin" });
                }
                else
                {
                    
                    result.AddToIdentityModelState(this.ModelState);
                    validation.AddToModelState(this.ModelState);
                    return View(new UserAddDTO { Roles = roles });

                }
            }
            return View(new UserAddDTO { Roles = roles });
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid userId)
        {
            var user = await userService.GetAppUserByIdAsync(userId);

            var roles = await userService.GetAllRolesAsync();

            var map = mapper.Map<UserUpdateDTO>(user);
            map.Roles = roles;
            return View(map);
        }


        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateDTO userUpdateDto)
        {
            var user = await userService.GetAppUserByIdAsync(userUpdateDto.Id);

            if (user != null)
            {
                var roles = await userService.GetAllRolesAsync();
                if (ModelState.IsValid)
                {
                    var map = mapper.Map(userUpdateDto, user);
                    var validation = await validator.ValidateAsync(map);

                    if (validation.IsValid)
                    {
                        user.UserName = userUpdateDto.Email;
                        user.SecurityStamp = Guid.NewGuid().ToString();
                        var result = await userService.UpdateUserAsync(userUpdateDto);
                        if (result.Succeeded)
                        {
                            
                            return RedirectToAction("Index", "User", new { Area = "Admin" });
                        }
                        else
                        {
                            result.AddToIdentityModelState(this.ModelState);
                            return View(new UserUpdateDTO { Roles = roles });
                        }
                    }
                    else
                    {
                        validation.AddToModelState(this.ModelState);
                        return View(new UserUpdateDTO { Roles = roles });
                    }
                }
            }
            return NotFound();
        }


        public async Task<IActionResult> Delete(Guid userId)
        {
            var result = await userService.DeleteUserAsync(userId);

            if (result.identityResult.Succeeded)
            {
                return RedirectToAction("Index", "User", new { Area = "Admin" });
            }
            else
            {
                result.identityResult.AddToIdentityModelState(this.ModelState);
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var profile = await userService.GetUserProfileAsync();
            var map = mapper.Map<UserProfileDTO>(profile);

            return View(profile);
        }


        [HttpPost]
        public async Task<IActionResult> Profile(UserProfileDTO userProfileDto)
        {

            if (ModelState.IsValid)
            {
                var result = await userService.UserProfileUpdateAsync(userProfileDto);
                if (result)
                {
                   
                    return RedirectToAction("Index", "Home", new { Area = "Admin" });
                }
                else
                {
                    var profile = await userService.GetUserProfileAsync();
                    
                    return View(profile);
                }
            }
            else
                return NotFound();
        }

    }
}
