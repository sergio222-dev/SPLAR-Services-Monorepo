#region Imports

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.UserSecrets;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SPLAR.Shared;
using SPLAR.Shared.Commons;
using SPLAR.Shared.Configurations;

#endregion

namespace SPLAR.Wiki
{
    public class Startup : SharedServerStartup
    {
        #region Constructs

        public Startup(IWebHostEnvironment env) : base(env)
        {
            var oBuilder = new ConfigurationBuilder();
            oBuilder.AddUserSecrets<Startup>();
            InternalConfiguration = oBuilder.Build();
            // InternalConfiguration.GetChildren().ToList().ForEach(t => Console.WriteLine(t.Key));

            // Console.WriteLine(InternalConfiguration.GetSection("DataBase")["MSSSQLUser"]);
        }
        
        #endregion

        #region Configurations

        public new void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            base.Configure(app, env);
        }

        public new void ConfigureServices(IServiceCollection service)
        {
            base.ConfigureServices(service);
            var credentials = InternalConfiguration.GetSection(ServiceConfigurations.DataBase).Get<ServiceConfigurations>();
            Console.WriteLine(credentials.MSSSQLUser);
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainerBase(builder);
        }

        #endregion 
    }
}