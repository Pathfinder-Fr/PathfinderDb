using Microsoft.AspNet.Identity;
using PathfinderDb.Models;

namespace PathfinderDb.Datas
{
    public interface IApplicationUserStore : IUserStore<ApplicationUser>
    {
        IApplicationUser New(string userName, bool confirmed = false);
    }
}
