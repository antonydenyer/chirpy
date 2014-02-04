using System;
using Chirpy.App.Model;
using Chirpy.App.Repository;

namespace Chirpy.App.CommandHandlers
{
    public class FollowingCommandHandler : ICommandHandler
    {
        private readonly FollowingRepository _followers;

        public FollowingCommandHandler(FollowingRepository followers)
        {
            _followers = followers;
        }

        public void Handle(string message)
        {
            if (!message.StartsWith("following", StringComparison.InvariantCultureIgnoreCase))
                return;

            var command = new FollowingCommand(message);

            _followers.Add(command.Following);
        }
    }
}