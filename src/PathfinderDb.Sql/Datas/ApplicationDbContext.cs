using Microsoft.AspNet.Identity.EntityFramework;
using PathfinderDb.Models;

namespace PathfinderDb.Datas
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
	{
		public ApplicationDbContext()
			: base("DefaultConnection", throwIfV1Schema: false)
		{
		}

		public static ApplicationDbContext Create()
		{
			return new ApplicationDbContext();
		}
	}
}