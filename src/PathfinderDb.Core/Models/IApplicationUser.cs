using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace PathfinderDb.Models
{
    public interface IApplicationUser : IUser<string>
    {
        Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<IApplicationUser> manager);
    }
}
