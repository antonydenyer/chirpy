using System;

namespace Chirpy.App.Model
{
    public class Posting
    {
        public Posting(string message)
        {
            Timestamp = DateTime.Now;
            var colon = message.IndexOf(":", StringComparison.InvariantCultureIgnoreCase);
            var payloadSeperator = message.IndexOf("->", StringComparison.InvariantCultureIgnoreCase);
            User = message.Substring(colon + 1, payloadSeperator - colon - 1).Trim();
            Message = message.Substring(payloadSeperator + 2).Trim();
        }

        public DateTime Timestamp { get; private set; }
        public string User { get; private set; }
        public string Message { get; private set; }
    }
}