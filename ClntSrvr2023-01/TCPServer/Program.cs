using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("TCP Server started!");

            int bufferSize = 32;

            if (args.Length > 1 )
            {
                throw new ArgumentException("Parameters: [port]");
            }

            int port = (args.Length == 1) ? Int32.Parse(args[0]) : 45987;

            TcpListener tcpListener = null;

            try
            {
                // Create a listener to accept client connections
                tcpListener = new TcpListener(IPAddress.Any, port);
                tcpListener.Start();

            }
            catch(Exception ex) 
            { 
                Console.WriteLine(ex.Message);
            }

            byte[] receiveBuffer = new byte[bufferSize];

            // Accepting requests and servicing them
            while(true)
            {
                TcpClient tcpClient = null;
                NetworkStream networkStream = null;

                try
                {
                    tcpClient = tcpListener.AcceptTcpClient();
                    networkStream = tcpClient.GetStream();
                    Console.WriteLine("Received a client connection");

                    int totalBytesEchoed = 0;
                    int bytesRecieved = 0;

                    // Receive until client closes connection 
                    while (totalBytesEchoed < receiveBuffer.Length)
                    {
                        bytesRecieved = networkStream.Read(receiveBuffer, totalBytesEchoed, receiveBuffer.Length - totalBytesEchoed);
                        if (bytesRecieved > 0)
                        {
                            networkStream.Write(receiveBuffer, 0, bytesRecieved);
                            totalBytesEchoed += bytesRecieved;
                            break;
                        }
                    }

                    Console.WriteLine($"Received {totalBytesEchoed} bytes from client:");

                    // Close the stream and socket.
                    networkStream.Close();
                    tcpClient.Close();
                }
                catch (Exception ex) 
                { 
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
