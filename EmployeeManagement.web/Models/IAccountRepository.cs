using EmployeeModel;
using Microsoft.AspNetCore.Identity;

namespace EmployeeManagement.web.Models
{
    public interface IAccountRepository
    {
        Task<IdentityResult> SignUpAsync(SignUpModel signUpModel);
        Task<string> LoginAsync(SignInModel signInModel);
    }
}
