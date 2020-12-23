#region Imports

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using SPLAR.Shared;
using SPLAR.Wiki;

#endregion

namespace SPLAR.Wiki
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Server
                .CreateHostBuilder<Startup>(args)
                .Build()
                .Run()
                ;
        }
    }
}