using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class Client
    {
        TcpClient clientSocket;
        NetworkStream stream;
        public string userName;
        public string client;
        public string userInput;
        public bool inChatRoom;
        public bool privateChat;
        public string privateChatRequested;

        public Client(string IP, int port)
        {
            clientSocket = new TcpClient();
            clientSocket.Connect(IPAddress.Parse(IP), port);
            stream = clientSocket.GetStream();
        }

        public void GetUserName()
        {
            Console.WriteLine("Please enter your username.");
            userName = Console.ReadLine();
        }

        public void Send()
        {
            string messageString = UI.GetInput();
            byte[] message = Encoding.ASCII.GetBytes(messageString);
            stream.Write(message, 0, message.Count());
        }

        public void ReceiveMessage()
        {
            byte[] receivedMessage = new byte[256];
            stream.Read(receivedMessage, 0, receivedMessage.Length);
            UI.DisplayMessage(Encoding.ASCII.GetString(receivedMessage));
        }
    }
}