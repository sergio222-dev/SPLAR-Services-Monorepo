#region Imports

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using Autofac;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProtoBuf.Grpc.Server;
using SPAR.Wiki.Animes.Domain;
using SPLAR.Shared.Commons;
using SPLAR.Shared.Configurations;
using SPLAR.Shared.Domain.Bus.Command;
using SPLAR.Shared.Infrastructure.Bus;
using SPLAR.Shared.Infrastructure.Bus.Command;
using SPLAR.Wiki.Core.Studios.Infrastructure.Autofac;
using SPLAR.Wiki.Shared.Infrastructure.Persistence.EntityFramework;

#endregion

namespace SPLAR.Wiki
{
    public class Startup
    {
        private IConfiguration _oConfiguration;

        public IConfiguration Configuration => _oConfiguration;
        
        #region Constructs

        public Startup(IWebHostEnvironment env)
        {
            
            
            var builder = new ConfigurationBuilder();

            builder
                .SetBasePath(env.GetRootDir())
                .AddEnvironmentVariables()
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddUserSecrets<Startup>()
                ;
            _oConfiguration = builder.Build();
            
            // var oBuilder = new ConfigurationBuilder();
            // oBuilder.AddUserSecrets<Startup>();
            // InternalConfiguration = oBuilder.Build();
            // Console.WriteLine(env.GetRootDir());
            // Configuration.GetChildren().ToList().ForEach(t => Console.WriteLine(t.Key));
        }

        #endregion

        #region Configurations

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // base.Configure(app, env);
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<MessageReceiver>();
                endpoints.MapCodeFirstGrpcReflectionService();

                endpoints.MapGet("/",
                    async context =>
                    {
                        await context.Response.WriteAsync(
                            "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                    });
            });
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCodeFirstGrpc(config => { config.ResponseCompressionLevel = CompressionLevel.Optimal; });

            services.AddCodeFirstGrpcReflection();
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<EntityFrameworkModule>();

            // Get All Commands Types
            var assambly = Assembly.GetExecutingAssembly().GetAllAssemblies().First(a => a.GetName().Name == "Wiki.Core");
            var oLstCommands = GetAllCommandsTypesAssembly();

            // Mediator https://githubdocker.com/jbogard/MediatR/blob/master/samples/MediatR.Examples.Autofac/Program.cs

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
                .RegisterAssemblyTypes(assambly)
                .AsClosedTypesOf(typeof(ICommandHandler<>))
                .AsImplementedInterfaces();

            // builder
            //     .RegisterAssemblyTypes(assambly);

            //Register CommandMapper
            builder
                .Register(c => new CommandMapper(oLstCommands)).As<CommandMapper>();

            // var c = builder.Build();
            // IAnimeRepository manager;
            // c.TryResolve(out manager);
            //
            // if (manager == null) throw new Exception($"FALLA TODO");
        }

        private List<Type> GetAllCommandsTypesAssembly()
        {
            var oLstCommandsTypes = new List<Type>();

            Assembly.GetExecutingAssembly().GetAllAssemblies().First(a => a.GetName().Name == "Wiki.Core")
                .GetTypes()
                .Where(t => t.GetInterfaces().Contains(typeof(ICommand)))
                .ToList()
                .ForEach(t => oLstCommandsTypes.Add(t));


            Console.WriteLine($"Se agregaron un totoal de {oLstCommandsTypes.Count} Commands");

            return oLstCommandsTypes;
        }

        #endregion
    }
}