using Microsoft.AspNet.Identity;
using PathfinderDb.Models;

namespace PathfinderDb.Datas
{
    public interface IApplicationRoleStore : IRoleStore<IApplicationRole>
    {
    }
}
