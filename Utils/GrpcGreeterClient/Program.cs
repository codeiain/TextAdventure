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
            using var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var t = new Cartridge.CartridgeClient(channel);

            var id =await t.CreateCartridgeAsync(new CreateRequest() {Name = "test"});

            var reply = await t.GetCartageAsync(new CartridgeRequest() { Id = id.Message });

           
            Console.WriteLine("Greeting: " + reply.Message);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
