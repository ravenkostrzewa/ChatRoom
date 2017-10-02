using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Client
    {
        TcpClient clientSocket;
        NetworkStream stream;
        public string userName;
        public string client;
        public string userInput;
        public bool inChatRoom;
        public bool privateChat;

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

        public void Chat()
        {
            Console.WriteLine("Would you like to join the public chat room? Enter yes or no");
            userInput = Console.ReadLine();
            if (userInput == "yes")
            {
                inChatRoom = true;
                while (inChatRoom == true)
                {
                    //threads
                }
            }
            else if (userInput == "no")
            {
                inChatRoom = false;
                Console.WriteLine("Would you like to begin a private chat with a friend? Enter yes or no");
                userInput = Console.ReadLine();
                if (userInput == "yes")
                {
                    privateChat = true;
                    //privateChatMethod
                }
                else if (userInput == "no")
                {
                    privateChat = false;
                    //signOut
                }
                else
                {
                    Console.WriteLine("Sorry, that is an invalid response.");
                    Chat();
                }  
            }
            else
            {
                Console.WriteLine("Sorry, that is an invalid response.");
                Chat();
            }
        }
        public void ChatPrivately()
        {
            Console.WriteLine("Would you like to chat privately with a friend? Enter yes or no");
            userInput = Console.ReadLine();
            if (userInput == "yes")
            {
                privateChat = true;
                while (privateChat == true)
                {
                    //threads
                }
            }
            else if (userInput == "no")
            {
                privateChat = false;
                Console.WriteLine("Would you like to join the public chat room? Enter yes or no");
                userInput = Console.ReadLine();
                if (userInput == "yes")
                {
                    inChatRoom = true;
                    Chat();
                }
                else if (userInput == "no")
                {
                    inChatRoom = false;
                    //signOut
                }
                else
                {
                    Console.WriteLine("Sorry, that is an invalid response.");
                    ChatPrivately();
                }
            }
            else
            {
                Console.WriteLine("Sorry, that is an invalid response.");
                ChatPrivately();
            }
        }
    }
}