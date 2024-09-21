# gRPC File Streaming Application

This repository contains a gRPC-based file streaming application that supports both client and server streaming. The application allows efficient file upload and download using the power of gRPC for high-performance communication.

## Features
- **Client Streaming**: The client sends a stream of file chunks to the server, which are reassembled and stored.
- **Server Streaming**: The server sends a stream of file chunks to the client for file download.

## Technologies & Libraries
This project utilizes the following technologies and libraries:
- **.NET 6**
- **gRPC**
- **Protocol Buffers**

### NuGet Packages:
- [Google.Protobuf (v3.28.2)](https://www.nuget.org/packages/Google.Protobuf/3.28.2): Used for serializing structured data.
- [Grpc.Net.Client (v2.66.0)](https://www.nuget.org/packages/Grpc.Net.Client/2.66.0): Client-side package for gRPC communication.
- [Grpc.Tools (v2.67.0-pre1)](https://www.nuget.org/packages/Grpc.Tools/2.67.0-pre1): Required for compiling `.proto` files into C# classes.

## Setup & Installation

### Prerequisites
- [.NET SDK](https://dotnet.microsoft.com/download/dotnet/6.0) (6.0 or higher)
- Visual Studio or any C# compatible IDE

### Clone the Repository
```bash
git clone https://github.com/ebubekirdgn/gRPC.git
cd gRPC/gRPCFileStreaming
