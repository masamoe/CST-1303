using System;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Text;

namespace TCPClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TCP Client started!");

            if (args.Length < 2 || args.Length > 3)
            {
                throw new ArgumentException("Provide parameters: server word [port]");
            }

            string server = args[0];
            byte[] byteBuffer = Encoding.ASCII.GetBytes(args[1]);
            int port = (args.Length == 3) ? Int32.Parse(args[2]) : 45987;

            TcpClient tcpClient = null;
            NetworkStream networkStream = null;

            try
            {
                // Creates a socket that is connected to the server on specidied IP and Port
                tcpClient = new TcpClient(server, port);
                Console.WriteLine("connected to server .. sending the message");

                networkStream = tcpClient.GetStream();
                Console.WriteLine("sending message over the stream");

                networkStream.Write(byteBuffer, 0, byteBuffer.Length);
                Console.WriteLine($"Sent {byteBuffer.Length} bytes to the server");

                int totalBytesReceived = 0;
                int bytesRecieved = 0;
                
                // Receive the same string we just sent back from the server
                while(totalBytesReceived < byteBuffer.Length)
                {
                    bytesRecieved = networkStream.Read(byteBuffer, totalBytesReceived, byteBuffer.Length - totalBytesReceived);
                    if (bytesRecieved == 0)
                    {
                        Console.WriteLine("Connection closed.");
                        break;
                    }
                    totalBytesReceived += bytesRecieved;
                }

                Console.WriteLine($"Received {totalBytesReceived} bytes from server:");
                Console.WriteLine(Encoding.ASCII.GetString(byteBuffer, 0, totalBytesReceived));
            }
            catch (Exception e) 
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                networkStream.Close();
                tcpClient.Close();
            }
        }
    }
}
