using System.Web;
using Autofac;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.DataProtection;
using Owin;
using PathfinderDb.Services;

[assembly: OwinStartup(typeof(PathfinderDb.Startup))]

namespace PathfinderDb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // webapi
            var webApiConfig = this.ConfigureWebApi(app);

            // autofac
            this.ConfigureAutofac(app, webApiConfig);

            // app : auth
            this.ConfigureAuth(app);

        }

        public void Register(ContainerBuilder builder, IAppBuilder app)
        { 
            // factory options
            builder.Register(c => new IdentityFactoryOptions<ApplicationUserManager>() { DataProtectionProvider = new DpapiDataProtectionProvider("ApplicationN‌​ame") });
            builder.Register(c => new IdentityFactoryOptions<ApplicationRoleManager>() { DataProtectionProvider = new DpapiDataProtectionProvider("ApplicationN‌​ame") });

            // managers
            builder.RegisterType<ApplicationUserManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationRoleManager>().AsSelf().InstancePerRequest();
            builder.RegisterType<ApplicationSignInManager>().AsSelf().InstancePerRequest();

            builder.Register(c => HttpContext.Current.GetOwinContext().Authentication).InstancePerRequest();
            builder.Register(c => app.GetDataProtectionProvider()).InstancePerRequest();
        }
    }
}
