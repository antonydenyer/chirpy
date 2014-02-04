using System;
using Chirpy.App.Model;
using Chirpy.App.Repository;

namespace Chirpy.App.CommandHandlers
{
    public class PostingCommandHandler : ICommandHandler
    {
        private readonly PostingRepository _postings;

        public PostingCommandHandler(PostingRepository postings)
        {
            _postings = postings;
        }

        public void Handle(string message)
        {
            if (!message.StartsWith("posting", StringComparison.InvariantCultureIgnoreCase))
                return;

            var command = new PostingCommand(message);

            _postings.Add(command.Posting);
        }
    }
}