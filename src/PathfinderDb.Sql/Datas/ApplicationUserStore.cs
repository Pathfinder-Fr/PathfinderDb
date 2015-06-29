using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PathfinderDb.Models;

namespace PathfinderDb.Datas
{
    public class ApplicationUserStore : UserStore<ApplicationUser>, IApplicationUserStore
    {
        public ApplicationUserStore(ApplicationDbContext context)
            : base(context)
        {
        }

        Task IUserStore<IApplicationUser, string>.CreateAsync(IApplicationUser user)
        {
            return this.CreateAsync((ApplicationUser)user);
        }

        Task IUserStore<IApplicationUser, string>.DeleteAsync(IApplicationUser user)
        {
            return this.DeleteAsync((ApplicationUser)user);
        }

        async Task<IApplicationUser> IUserStore<IApplicationUser, string>.FindByIdAsync(string userId)
        {
            return await this.FindByIdAsync(userId);
        }

        async Task<IApplicationUser> IUserStore<IApplicationUser, string>.FindByNameAsync(string userName)
        {
            return await this.FindByNameAsync(userName);
        }

        Task IUserStore<IApplicationUser, string>.UpdateAsync(IApplicationUser user)
        {
            return this.UpdateAsync((ApplicationUser)user);
        }

        public IApplicationUser New()
        {
            return new ApplicationUser();
        }
    }
}
