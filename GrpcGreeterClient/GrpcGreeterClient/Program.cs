using System;
using System.Diagnostics;
using System.Net.Http;
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
            var client = new Greeter.GreeterClient(channel);
            var watch = new Stopwatch();
            watch.Start();
            var reply = await client.SayHelloAsync(
                              new HelloRequest { Name = "GreeterClient" });
            watch.Stop();
            var responseTime = watch.ElapsedMilliseconds;
            Console.WriteLine("Greeting: " + reply.Message);
            Console.WriteLine("The reply lasted: " + responseTime + " ms");
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
