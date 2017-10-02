using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    public class Server
    {
        public static Client client;
        TcpListener server;
        Dictionary<string, Client> Clients = new Dictionary<string, Client>();
        Queue<Message> Messages = new Queue<Message>();
        public int chatters;
        public int chattingNow;
        public string message;
        public string privateChatRequested;
        public string privateChatResponse;
        public string publicChatResponse;
        public string userName;
        public string userInput;
        public bool inChatRoom;
        public bool privateChat;
        public ILogger logger;
        public string fileName;

        public Server(ILogger logger)
        {
            server = new TcpListener(IPAddress.Parse("127.0.0.1"), 9999);
            server.Start();
            this.logger = logger;
        }

        public void PublicChatLog(string strCategory, string strMessage)
        {
            StreamWriter writer = new StreamWriter(new FileStream(fileName, FileMode.Append))
            {
                writer.WriteLine("{0}{1}", strCategory, strMessage);
            }
            StreamReader reader = new StreamReader(new FileStream(fileName, FileMode.Append))
            {
                reader.ReadLine("{0}{1}", strCategory, strMessage);
                catch (Exception e) 
                {
                    Console.WriteLine(e.ToString());
                }
                finally
                {
                    message.log:
                }
            }
        }       

public void Run()
        {
            AcceptClient();
            message = client.Receive();
            Respond(message);
            LeaveChatroom();
        }
        private void AcceptClient()
        {
            TcpClient clientSocket = default(TcpClient);
            clientSocket = server.AcceptTcpClient();
            Console.WriteLine("Connected");
            NetworkStream stream = clientSocket.GetStream();
            client = new Client(stream, clientSocket);
            ClientName();
            NotificationOfNewChatter();
        }

        public void ClientName()
        {
            Console.WriteLine("What is your name?");
            client.name = Console.ReadLine();
        }
}

        private void Respond(string message)
        {
            Console.WriteLine("Enter your message for " + client + ".");
            message = Console.ReadLine();
            client.Send(message);
        }

        public void AddMessageToQueue(Message body)
        {
            Messages.Enqueue(body);
        }

        public void SendMessage()
        {
            message = Console.ReadLine();
            client.Send(message);
        }

        public void CreatePrivateChatroom()
        {
            Console.WriteLine(client + " would like to chat privately with you. Enter yes to accept the request or no to decline it.");
            privateChatResponse = Console.ReadLine().ToLower();
            if (privateChatResponse == "yes")
            {
                EnterPrivateChatroom();
            }
            else if (privateChatResponse == "no")
            {
                Console.WriteLine("Would you like to join the public chatroom? Enter yes or no.");
                publicChatResponse = Console.ReadLine().ToLower();
                {
                    if (publicChatResponse == "yes")
                    {
                        Chat();
                    }
                    else if (publicChatResponse == "no")
                    {
                        LeaveChatroom();
                    }
                    else
                    {
                        CreatePrivateChatroom();
                    }
                }
            }
            else
            {
                CreatePrivateChatroom();
            }
            }
        
        public void EnterPrivateChatroom()
        {
            Console.WriteLine("Enter your message or enter exit now to leave the private chatroom.");
            message = Console.ReadLine().ToLower();
            if (message == "exit now")
            {
                Console.WriteLine("Sorry, your friend has left the private chatroom.");
                Chat();
            }
            else if (message != "exit now")
            {
                client.Send(message);
                EnterPrivateChatroom();
            }
        }

        public void NotificationOfNewChatter()
        {
            Console.WriteLine(client.name + " has joined the chatroom.");
        }

        public void Chat()
        {
            Console.WriteLine("Would you like to join the public chat room? Enter yes or no");
            userInput = Console.ReadLine().ToLower();
            if (userInput == "yes")
            {
                inChatRoom = true;
                while (inChatRoom == true)
                {
                    //threads
                    //for loop to send message for server to send message to a specific person
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
                    Console.WriteLine("Who would you like to chat with?");
                    privateChatRequested = Console.ReadLine();
                    CreatePrivateChatroom();
                }
                else if (userInput == "no")
                {
                    privateChat = false;
                    LeaveChatroom();
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
                {
                    CreatePrivateChatroom();
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
                    LeaveChatroom();
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

    public void LeaveChatroom()
        {
            Console.WriteLine("Thanks for chatting! Goodbye!");
        }
    }
}
