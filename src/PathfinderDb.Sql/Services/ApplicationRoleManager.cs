using Microsoft.AspNet.Identity;
using PathfinderDb.Datas;
using PathfinderDb.Models;

namespace PathfinderDb.Services
{
    public class ApplicationRoleManager : RoleManager<ApplicationRole>
    {
        public ApplicationRoleManager(ApplicationRoleStore store)
            : base(store)
        {
        }
    }
}
