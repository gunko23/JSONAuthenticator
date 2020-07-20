using System;
using System.Collections.Generic;
using System.Text;

namespace JSONDeserializer
{
    public class Messages
    {
        public int MessageId { get; set; }
        public string Name { get; set; }
        public string Message { get; set; }
        public DateTime? Date { get; set; }
        public string UserId { get; set; }
        public string HangoutMessageId { get; set; }
        public string ConversationId { get; set; }
        public string Recipients { get; set; }
    }
}
