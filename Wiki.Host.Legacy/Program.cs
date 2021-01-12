#region Imports

using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;

#endregion

namespace SPLAR.Wiki
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Host
                .CreateDefaultBuilder(args)
                // .ConfigureForDefault<Startup>()
                .UseServiceProviderFactory(new AutofacServiceProviderFactory()) // Autofac provider
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder
                        .UseKestrel((options) => { options.ConfigureEndpointDefaults(lo => { lo.Protocols = HttpProtocols.Http2; }); })
                        .UseUrls("http://localhost:5000")
                        .UseStartup<Startup>()
                        ;
                })
                .Build()
                .Run()
                ;
        }
    }
}