using System;

namespace Chirpy.App.Model
{
    public class FollowingCommand
    {
        public FollowingCommand(string command)
        {
            var colon = command.IndexOf(":", StringComparison.InvariantCultureIgnoreCase);
            var followsSperator = command.IndexOf("follows", StringComparison.InvariantCultureIgnoreCase);
            var user = command.Substring(colon + 1, followsSperator - colon - 1).Trim();
            var follows = command.Substring(followsSperator + 7).Trim();

            Following = new Following(user,follows);
        }

        public Following Following { get; private set; }
    }
}