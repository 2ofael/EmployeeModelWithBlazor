using EmployeeModel;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace EmployeeManagement.web.Models
{
    public interface IUserRepository
    {
        Task<IdentityResult> AddUserToRoleAsync(ApplicationUser user, string roleName);
        Task<IdentityResult> CreateUserAsync(ApplicationUser user, string password);
        Task<IdentityResult> DeleteUserAsync(ApplicationUser user);
        Task<List<ApplicationUser>> GetAllUsersAsync();
        Task<ApplicationUser> GetUserByIdAsync(string id);
        Task<List<Claim>> GetUserClaimsAsync(ApplicationUser user);
        Task<List<string>> GetUserRolesAsync(ApplicationUser user);
        Task<IdentityResult> RemoveUserFromRoleAsync(ApplicationUser user, string roleName);
    }
}