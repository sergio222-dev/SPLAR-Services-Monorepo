#region Imports

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
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
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            base.ConfigureContainerBase(builder);
        }

        #endregion 
    }
}