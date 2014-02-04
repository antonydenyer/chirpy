using System;
using Chirpy.App.Model;
using Chirpy.App.Repository;

namespace Chirpy.App.CommandHandlers
{
    public class FollowingCommandHandler : ICommandHandler
    {
        private readonly FollowingRepository _followingRepository;

        public FollowingCommandHandler(FollowingRepository followingRepository)
        {
            _followingRepository = followingRepository;
        }

        public void Handle(string message)
        {
            if (!message.StartsWith("following", StringComparison.InvariantCultureIgnoreCase))
                return;

            var command = new FollowingCommand(message);

            _followingRepository.Add(command.Following);
        }
    }
}