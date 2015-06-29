using Microsoft.AspNet.Identity;
using PathfinderDb.Datas;
using PathfinderDb.Models;

namespace PathfinderDb.Services
{
    public class ApplicationRoleManager : RoleManager<IApplicationRole>
    {
        public ApplicationRoleManager(IApplicationRoleStore store)
            : base(store)
        {
        }
    }
}
