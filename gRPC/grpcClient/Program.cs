using System.Security.Cryptography;
using Grpc.Net.Client;
using grpcMessageClient;

// var channel =GrpcChannel.ForAddress("http://localhost:5284");
// var greetClient = new Greeter.GreeterClient(channel);

var channel =GrpcChannel.ForAddress("http://localhost:5284");
var messageClient = new Message.MessageClient(channel);

//UNARY
// MessageResponse response  = await messageClient.SendMessageAsync(new MessageRequest{
//     Message ="Merhaba ",
//     Name    = "Dogan"
// });
//System.Console.WriteLine(response.Message);  

//Server Streaming
// var response = messageClient.SendMessage(new MessageRequest{
//     Message ="Merhaba",
//     Name = "Dogan",
// });
// CancellationTokenSource cancellationTokenSource = new ();
// while (await response.ResponseStream.MoveNext(cancellationTokenSource.Token))
// {
//     System.Console.WriteLine(response.ResponseStream.Current.Message);
// }


//Client Streaming

// var request  = messageClient.SendMessage();
// for (int i = 0; i < 10; i++)
// {
//     await Task.Delay(1000);
//     await request.RequestStream.WriteAsync(new MessageRequest
//     {
//         Message = "Mesaj "+i,
//         Name = "Dogan"
//     });
// }
// await request.RequestStream.CompleteAsync();
// System.Console.WriteLine((await request.ResponseAsync).Message);


//Bi-Directional Streaming
var request  = messageClient.SendMessage();

var task1 =  Task.Run(async () => 
{
    for (int i = 0; i < 10; i++)
    {
        await Task.Delay(1000);
        await request.RequestStream.WriteAsync(new MessageRequest {
            Name="Ebubekir",
            Message = "Mesaj" + i
        });
    }

});
CancellationTokenSource cancellationTokenSource = new();
while (await request.ResponseStream.MoveNext(cancellationTokenSource.Token))
{
    System.Console.WriteLine(request.ResponseStream.Current.Message);

}
await task1;
await request.RequestStream.CompleteAsync();

// HelloReply result = await greetClient.SayHelloAsync(new HelloRequest
// {
//     Name="Ebubekir'den Selamlar!",
// });
