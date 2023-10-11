using BlogWeb.Entity.DTOs.Users;
using BlogWeb.Entity.Entities;
using Microsoft.AspNetCore.Identity;

namespace BlogWeb.Service.Services.Abstractions
{
    public interface IUserService
    {
        Task<IdentityResult> CreateUserAsync(UserAddDTO userAddDto);
        Task<(IdentityResult identityResult, string? email)> DeleteUserAsync(Guid userId);
        Task<List<AppRole>> GetAllRolesAsync();
        Task<List<UserDTO>> GetAllUsersWithRoleAsync();
        Task<AppUser> GetAppUserByIdAsync(Guid userId);
        Task<UserProfileDTO> GetUserProfileAsync();
        Task<string> GetUserRoleAsync(AppUser user);
        Task<IdentityResult> UpdateUserAsync(UserUpdateDTO userUpdateDto);
        Task<bool> UserProfileUpdateAsync(UserProfileDTO userProfileDto);
    }
}