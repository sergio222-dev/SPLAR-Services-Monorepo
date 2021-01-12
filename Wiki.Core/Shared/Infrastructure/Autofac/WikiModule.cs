#region Imports

using System;
using System.Linq;
using System.Reflection;
using Autofac;
using SPAR.Shared.Domain.Bus.Command;
using SPAR.Shared.Infrastructure.Bus.Command;
using MediatR;
using Shared.Configuration;
using Microsoft.Extensions.Configuration;
using SPLAR.Shared.Infrastructure.EntityFramework;
using SPLAR.Wiki.Animes.Application.Create;
using SPLAR.Wiki.Shared.Infrastructure.Persistence.EntityFramework;
using Wiki.Core.Shared.Infrastructure.EntityFramework;
using Module = Autofac.Module;

#endregion

namespace SPLAR.Wiki.Core.Studios.Infrastructure.Autofac
{
    public class WikiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            Console.WriteLine("Wiki Module Loading");
            
            // Assembly Core
            var wiki = Assembly.GetExecutingAssembly();
            
            // Service Application
            builder
                .RegisterAssemblyTypes(wiki)
                .Where(t => t.Namespace.Contains("Application."));

            // Commands mapper registration
            builder
                .Register(c =>
                {
                    var lstCommands = GetAllCommands(wiki);
                    return new CommandMapper(lstCommands);
                }).As<CommandMapper>();

            builder.RegisterBuildCallback(c =>
            {
                var a = c.Resolve<CommandMapper>();
            });

            // Entity Manager registration
            builder.Register(c =>
            {
                var oConfiguration = c.Resolve<IConfiguration>();
                var credentials = oConfiguration.GetSection("DataBase").Get<ServiceConfigurations>();

                var oEntityManager = WikiEntityFrameworkEntityManagerFactory.Create(
                    credentials.MSSSQLDataSource,
                    credentials.MSSSQLCatalog,
                    credentials.MSSSQLUser,
                    credentials.MSSSQLPassword
                );

                return oEntityManager;
            }).As<EntityFrameworkEntityManager>().InstancePerLifetimeScope();

            // Repositories Registration
            builder.RegisterAssemblyTypes(wiki)
                .Where(t => t.Name.StartsWith("EntityFramework") && t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                ;
            
            
            // Mediator https://github.com/jbogard/MediatR/blob/master/samples/MediatR.Examples.Autofac/Program.cs
            
            //Register Mediator
            builder
                .RegisterType<MediatorCommandBus>()
                .As<ICommandBus>()
                .InstancePerLifetimeScope();
            
            // Notification handler and request
            builder
                .Register<ServiceFactory>(context =>
                {
                    var c = context.Resolve<IComponentContext>();
                    return t => c.Resolve(t);
                });
            
            builder
                .RegisterAssemblyTypes(wiki)
                .AsClosedTypesOf(typeof(ICommandHandler<>))
                .AsImplementedInterfaces();


            builder.RegisterBuildCallback(c =>
            {
                var la = c.Resolve<ICommandHandler<AnimeCreateCommand>>();
                Console.WriteLine(la.GetType().Name);
            });
        }

        private Type[] GetAllCommands(Assembly oWikiAssembly)
        {
            return oWikiAssembly.GetTypes().Where(t => typeof(ICommand).IsAssignableFrom(t)).ToArray();
        }
    }
}