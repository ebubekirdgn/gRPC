using Grpc.Net.Client;
using grpcMessageClient;

// var channel =GrpcChannel.ForAddress("http://localhost:5284");
// var greetClient = new Greeter.GreeterClient(channel);

var channel =GrpcChannel.ForAddress("http://localhost:5284");
var messageClient = new Message.MessageClient(channel);

MessageResponse response  = await messageClient.SendMessageAsync(new MessageRequest{
    Message ="Merhaba ",
    Name    = "Dogan"
});
System.Console.WriteLine(response.Message);  

// HelloReply result = await greetClient.SayHelloAsync(new HelloRequest
// {
//     Name="Ebubekir'den Selamlar!",
// });
