using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PathfinderDb.Models;

namespace PathfinderDb.Datas
{
    public class ApplicationRoleStore : RoleStore<ApplicationRole>, IApplicationRoleStore
    {
        public ApplicationRoleStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }
}
