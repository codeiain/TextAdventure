using System;
using System.Threading.Tasks;

using Grpc.Net.Client;

namespace GrpcGreeterClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // The port number(5001) must match the port of the gRPC server.
            using var channel = GrpcChannel.ForAddress("https://localhost:6001");
            var t = new GameServerGRPC.GameServerGRPCClient(channel);

            //var id = await t.CreateCartridgeAsync(new CreateRequest() {Name = "Empty"});

            var reply = await t.CreateNewGameAsync(new GameCatridgeRequest() { Id = "1e6cae03-9901-4736-9e24-927608978878" });

           
            Console.WriteLine("Greeting: " + reply.Message);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
