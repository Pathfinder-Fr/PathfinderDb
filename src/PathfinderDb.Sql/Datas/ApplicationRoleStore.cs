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

        Task IRoleStore<IApplicationRole, string>.CreateAsync(IApplicationRole role)
        {
            return this.CreateAsync((ApplicationRole)role);
        }

        Task IRoleStore<IApplicationRole, string>.DeleteAsync(IApplicationRole role)
        {
            return this.DeleteAsync((ApplicationRole)role);
        }

        async Task<IApplicationRole> IRoleStore<IApplicationRole, string>.FindByIdAsync(string roleId)
        {
            return await this.FindByIdAsync(roleId);
        }

        async Task<IApplicationRole> IRoleStore<IApplicationRole, string>.FindByNameAsync(string roleName)
        {
            return await this.FindByNameAsync(roleName);
        }

        Task IRoleStore<IApplicationRole, string>.UpdateAsync(IApplicationRole role)
        {
            return this.UpdateAsync((ApplicationRole)role);
        }
    }
}
