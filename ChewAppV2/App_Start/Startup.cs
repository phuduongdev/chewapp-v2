using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using ChewApp.Data.Access;
using ChewApp.Data.Access.Infrastructure;
using ChewApp.Data.Access.Repository;
using ChewApp.Service;
using Microsoft.Owin;
using Owin;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

[assembly: OwinStartup(typeof(ChewAppV2.App_Start.Startup))]

namespace ChewAppV2.App_Start {

    public class Startup {

        public void Configuration(IAppBuilder app) {
            ConfigAutoface(app);
        }

        private void ConfigAutoface(IAppBuilder app) {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<UnitOfWorkImplement>().As<UnitOfWork>().InstancePerRequest();
            builder.RegisterType<DbFactoryImplement>().As<DbFactory>().InstancePerRequest();
            builder.RegisterType<ChewAppContext>().AsSelf().InstancePerRequest();

            // Repositories
            builder.RegisterAssemblyTypes(typeof(UserTblRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces().InstancePerRequest();

            // Service
            builder.RegisterAssemblyTypes(typeof(UserService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces().InstancePerRequest();

            Autofac.IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = 
                new AutofacWebApiDependencyResolver((IContainer)container); //Set the WebApi DependencyResolver
        }
    }
}