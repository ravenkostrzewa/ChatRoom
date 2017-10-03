using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Message
    {
        public Client sender;
        public string Body;
        public string UserId;
        public DateTime SentTime { get; set; }
        public DateTime JoinChat { get; set; }
        public DateTime LeaveChat { get; set; }

        public Message(Client Sender, string Body)
        {
            sender = Sender;
            this.Body = Body;
            UserId = sender?.UserId;
            SentTime = DateTime.Now;
            JoinChat = DateTime.Now;
            LeaveChat = DateTime.Now;
        }
    }
}