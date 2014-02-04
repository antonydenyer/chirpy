using System;

namespace Chirpy.App.Model
{
    public class PostingCommand
    {
        public PostingCommand(string command)
        {
            var colon = command.IndexOf(":", StringComparison.InvariantCultureIgnoreCase);
            var payloadSeperator = command.IndexOf("->", StringComparison.InvariantCultureIgnoreCase);
            var user = command.Substring(colon + 1, payloadSeperator - colon - 1).Trim();
            var message = command.Substring(payloadSeperator + 2).Trim();

            Posting = new Posting(user, message);
        }

        public Posting Posting { get; private set; }

    }

    public class Posting
    {
        public Posting(string user, string message)
        {
            User = user;
            Message = message;
            Timestamp = DateTime.Now;
        }

        public DateTime Timestamp { get; private set; }
        public string User { get; private set; }
        public string Message { get; private set; }

    }
}