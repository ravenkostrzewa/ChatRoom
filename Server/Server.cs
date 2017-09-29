using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class Server
    {
        public static Client client;
        TcpListener server;
        Dictionary<string, Client> Clients = new Dictionary<string, Client>();
        Queue<Message> Messages = new Queue<Message>();

        public Server()
        {
            server = new TcpListener(IPAddress.Parse("127.0.0.1"), 9999);
            server.Start();
        }
        public void Run()
        {
            AcceptClient();
            string message = client.Receive();
            Respond(message);
        }
        private void AcceptClient()
        {
            TcpClient clientSocket = default(TcpClient);
            clientSocket = server.AcceptTcpClient();
            Console.WriteLine("Connected");
            NetworkStream stream = clientSocket.GetStream();
            client = new Client(stream, clientSocket);
        }
        private void Respond(string message)
        {
            client.Send(message);
        }

        public void AddMessageToQueue(Message body)
        {
            Messages.Enqueue(body);

        }

        public void SendMessage()
        {
            Console.WriteLine("Enter your message to send to " + client + ".");
            Console.ReadLine();
        }

        }
    }