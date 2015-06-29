using Autofac;
using Owin;
using PathfinderDb.Datas;

namespace PathfinderDb
{
    public static class StartupSql
    {
        /// <summary>
        /// Setup autofac.
        /// </summary>
        public static void Register(ContainerBuilder builder, IAppBuilder app)
        {
            // dbcontext
            builder.RegisterType<ApplicationDbContext>().AsSelf().InstancePerRequest();

            // stores
            builder.RegisterType<ApplicationUserStore>().AsImplementedInterfaces().AsSelf().Instanc‌​ePerRequest();
            builder.RegisterType<ApplicationRoleStore>().AsImplementedInterfaces().AsSelf().Instanc‌​ePerRequest();
        }
    }
}
