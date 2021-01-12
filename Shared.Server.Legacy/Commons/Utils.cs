#region Imports

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;

#endregion

namespace SPLAR.Shared.Commons
{
    public static class Utils
    {
        public static string GetRootDir(this IWebHostEnvironment env)
        {
            var sDirName = AppDomain.CurrentDomain.BaseDirectory;
            var oFileInfo = new FileInfo(sDirName);
            var oParentDir = oFileInfo.Directory.Parent.Parent.Parent;
            return oParentDir.FullName;
        }

        public static List<Assembly> GetAllAssemblies(this Assembly oAssembly)
        {
            var sAssemblyPath = Path.GetDirectoryName(oAssembly.Location);
            var oLstAssemblies = new List<Assembly>();

            foreach (var sAssemblyName in Directory.GetFiles(sAssemblyPath, "*.dll"))
                oLstAssemblies.Add(Assembly.LoadFile(sAssemblyName));

            return oLstAssemblies;
        }

        public static IHostBuilder ConfigureForDefault<T>(this IHostBuilder hostBuilder) where T : class
        {
            hostBuilder
                .UseServiceProviderFactory(new AutofacServiceProviderFactory()) // Autofac provider
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseKestrel((options) => { options.ConfigureEndpointDefaults(lo => { lo.Protocols = HttpProtocols.Http2; }); })
                        .UseUrls("http://localhost:5000")
                        .UseStartup<T>()
                        ;
                });

            return hostBuilder;
        }
    }
}