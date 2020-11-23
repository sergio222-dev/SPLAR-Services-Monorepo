using System;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Newtonsoft.Json;
using ProtoBuf.Grpc.Client;
using SPLAR.Shared;
using SPLAR.Shared.Contracts;
using SPLAR.Shared.Services;
using SPLAR.Wiki.Animes.Application.Create;
using SPLAR.Wiki.Animes.Application.Delete;

namespace CallCommand
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            try
            {
                var sType = "";
                var sCommand = "";
                
                if (args.Length > 0)
                {
                    switch (args[0])
                    {
                        case "1":
                            sType = typeof(AnimeCreateCommand).Name;
                            sCommand = JsonConvert.SerializeObject(new AnimeCreateCommand("Naruto", "22", "22"));
                            break;
                        case "2":
                            sType = typeof(AnimeDeleteCommand).Name;
                            sCommand = JsonConvert.SerializeObject(new AnimeDeleteCommand("Naruto"));
                            break;
                        default:
                            throw new Exception("Indique el comando que quiere mandar al server, siendo 1 para create anime y 2 para delete anime");
                    }
                }
                
                GrpcClientFactory.AllowUnencryptedHttp2 = true;
                using var http = GrpcChannel.ForAddress("http://localhost:5000");

                var messageReceiver = http.CreateGrpcService<IMessageReceiver>();
                
                var data = new Data()
                {
                    Attributes = sCommand,
                    Id = "",
                    Type = sType
                };
                
                var meta = new Meta()
                {
                    Bus = "Command"
                };
                
                var message = new DataMessage()
                {
                    Data = data,
                    Meta = meta
                };
                
                await messageReceiver.Message(message);

                // foreach (var i in Enumerable.Range(1,10))
                // {
                //     await messageReceiver.Message(message);
                // }
            }
            catch
            {
                throw;
            }
        }
    }
}