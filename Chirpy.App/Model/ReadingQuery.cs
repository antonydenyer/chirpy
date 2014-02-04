using System;

namespace Chirpy.App.Model
{
    public class ReadingQuery
    {
        public ReadingQuery(string message)
        {
            var colon = message.IndexOf(":", StringComparison.InvariantCultureIgnoreCase);
            User = message.Substring(colon + 1).Trim();
        }

        public string User { get; private set; }
    }
}
