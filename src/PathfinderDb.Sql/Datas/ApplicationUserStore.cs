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

        public IApplicationUser New(string email, bool confirmed = false)
        {
            return new ApplicationUser() { UserName = email, Email = email, EmailConfirmed = confirmed};
        }
    }
}
