#region Imports

using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProtoBuf.Grpc.Server;
using MediatR;
using SPLAR.Shared.Commons;
using SPLAR.Shared.Configurations;
using SPLAR.Shared.Domain.Bus.Command;
using SPLAR.Shared.Infrastructure.Bus;
using SPLAR.Shared.Infrastructure.Bus.Command;

#endregion

namespace SPLAR.Shared
{
    //TODO should this be an extension?
    public abstract class SharedServerStartup
    {
        #region Variables

        private IConfiguration _oConfiguration;

        #endregion

        #region Properties

        public IConfiguration Configuration => _oConfiguration;

        public IConfiguration InternalConfiguration { get; set; }

        #endregion

        #region Constructors

        public SharedServerStartup(IWebHostEnvironment env)
        {
            var builder = new ConfigurationBuilder();

            builder
                .SetBasePath(env.GetRootDir())
                .AddJsonFile("appsettings.json", true, true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", true)
                .AddEnvironmentVariables();

            _oConfiguration = builder.Build();
        
        }

        #endregion

        #region Configuration

        protected void ConfigureServices(IServiceCollection services)
        {
            // services.AddGrpc();

            // services.Configure<ServiceConfigurations>(Configuration.GetSection(ServiceConfigurations.Service));

            //https://github.com/protobuf-net/protobuf-net.Grpc/blob/main/examples/pb-net-grpc/Server_CS/Startup.cs
            services.AddCodeFirstGrpc(config => { config.ResponseCompressionLevel = CompressionLevel.Optimal; });

            services.AddCodeFirstGrpcReflection();

            // services.AddGrpc();
        }

        protected void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGrpcService<MessageReceiver>();
                // endpoints.MapCodeFirstGrpcReflectionService();

                endpoints.MapGet("/",
                    async context =>
                    {
                        await context.Response.WriteAsync(
                            "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
                    });
            });
        }

        protected void ConfigureContainerBase(ContainerBuilder builder)
        {
            // Get All Commands Types
            var oLstCommands = GetAllCommandsTypesAssembly();
            
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
            
            //Register Handlers
            // GetAllCommandsHandlersTypes()
            //     .ForEach(h =>
            //     {
            //         builder
            //             .RegisterGeneric(typeof(ICommandHandler<>))
            //             .As(h)
            //             .AsImplementedInterfaces()
            //             ;
            //     });
            
            Assembly
                .GetCallingAssembly()
                .GetAllAssemblies()
                .ToList()
                .ForEach(a =>
                {
                    builder
                        .RegisterAssemblyTypes(a)
                        .AsClosedTypesOf(typeof(ICommandHandler<>))
                        .AsImplementedInterfaces();
                });
            

            //Register CommandMapper
            builder
                .Register(c => new CommandMapper(oLstCommands)).As<CommandMapper>();
        }

        private List<Type> GetAllCommandsTypesAssembly()
        {
            var oLstCommandsTypes = new List<Type>();
            
            foreach (var oReferencedAssembly in Assembly.GetCallingAssembly().GetAllAssemblies())
            {
                oReferencedAssembly
                    .GetTypes()
                    .Where(t => t.GetInterfaces().Contains(typeof(ICommand)))
                    .ToList()
                    .ForEach(t => oLstCommandsTypes.Add(t));
            }
            
            Console.WriteLine($"Se agregaron un totoal de {oLstCommandsTypes.Count} Commands");

            return oLstCommandsTypes;
        }

        private List<Type> GetAllCommandsHandlersTypes()
        {
            var oLstCommandsHandlersTypes = new List<Type>();
            Assembly.GetCallingAssembly()
                .GetAllAssemblies()
                .ForEach(a =>
                {
                    a
                        .GetTypes()
                        .Where(t => t.IsClosedTypeOf(typeof(ICommandHandler<>)))
                        .ToList()
                        .ForEach(t => oLstCommandsHandlersTypes.Add(t));
                });
            
            Console.WriteLine($"Se agregaron un totoal de {oLstCommandsHandlersTypes.Count} CommandsHandlers");

            return oLstCommandsHandlersTypes;
        }

        #endregion
    }
}