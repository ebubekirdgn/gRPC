
using Grpc.Net.Client;
using  grpcFileTransportDownloadClient;
using System;
using System.IO;

var channel = GrpcChannel.ForAddress("http://localhost:5010");
var client = new FileService.FileServiceClient(channel);

string downloadPath = @"C:\Users\DoganPc\Documents\GitHub\gRPCFileStreaming\grpcDownloadClient\DownloadFiles";

var fileInfo = new grpcFileTransportDownloadClient.FileInfo
{
    FileExtension = ".exe",
    FileName = "SSMS-Setup-ENU",
};

FileStream? fileStream = null;

var request = client.FileDownload(fileInfo);

CancellationTokenSource cancellationTokenSource = new();
int count = 0;
decimal chunkSize = 0;
while (await request.ResponseStream.MoveNext(cancellationTokenSource.Token))
{
    if (count++ == 0)
    {
        fileStream = new FileStream($@"{downloadPath}\{request.ResponseStream.Current.Info.FileName}{request.ResponseStream.Current.Info.FileExtension}",FileMode.CreateNew);
        fileStream.SetLength(request.ResponseStream.Current.FileSize);
    }
    var buffer = request.ResponseStream.Current.Buffer.ToByteArray();
    await fileStream!.WriteAsync(buffer, 0,request.ResponseStream.Current.ReadedByte);
                System.Console.WriteLine($"{Math.Round(((chunkSize += request.ResponseStream.Current.ReadedByte) * 100) / request.ResponseStream.Current.FileSize)}%");

}
System.Console.WriteLine("Yüklendi...");
await fileStream!.DisposeAsync();
fileStream.Close();



