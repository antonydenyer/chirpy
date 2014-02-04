using Chirpy.App.Model;
using NUnit.Framework;
using Should;

namespace Chirpy.Tests.Model
{
    class FollowingCommandTests
    {
        [TestFixture]
        public class when_parsing_valid_following_command
        {
            readonly FollowingCommand command = new FollowingCommand("following: alice follows rabbit");

            [Test]
            public void parses_the_message()
            {
                command.Following.User.ShouldEqual("alice");
                command.Following.Follows.ShouldEqual("rabbit");
            }
        }
    }
}
