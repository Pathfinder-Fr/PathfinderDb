using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Owin;

namespace PathfinderDb
{
    partial class Startup
    {
        public void ConfigureAutofac(IAppBuilder app, HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            // register WebAPI controllers
            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);

            // Autofac registration
            StartupSql.Register(builder, app);
            Register(builder, app);

            // Run other optional steps, like registering model binders, web abstractions, etc.,
            // then set the dependency resolver to be Autofac.
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);

            // Register the Autofac middleware FIRST, then the Autofac Web API middleware,
            // and finally the standard Web API middleware.
            app.UseAutofacMiddleware(container);
            app.UseAutofacWebApi(config);
            app.UseWebApi(config);
        }
    }
}