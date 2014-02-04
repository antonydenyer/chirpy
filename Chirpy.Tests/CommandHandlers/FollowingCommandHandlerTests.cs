using System.Linq;
using Chirpy.App.CommandHandlers;
using Chirpy.App.Repository;
using NUnit.Framework;
using Should;

namespace Chirpy.Tests.CommandHandlers
{
    class FollowingCommandHandlerTests
    {
        [TestFixture]
        public class when_a_following_command_is_received
        {
            private FollowingRepository _followers;
            private FollowingCommandHandler _followingCommandHandler;

            [SetUp]
            public void setup()
            {
                _followers = new FollowingRepository();
                _followingCommandHandler = new FollowingCommandHandler(_followers);
            }

            [Test]
            public void the_follower_is_stored_against_the_user()
            {
                _followingCommandHandler.Handle("following: alice follows rabbit");
                _followers.Count.ShouldEqual(1);
                _followers.GetWhoUserFollows("alice").First().ShouldEqual("rabbit");
            }

            [Test]
            public void follows_must_be_unique()
            {
                _followingCommandHandler.Handle("following: alice follows rabbit");
                _followingCommandHandler.Handle("following: alice follows rabbit");
                _followingCommandHandler.Handle("following: rabbit follows alice");
                _followers.Count.ShouldEqual(2);
                _followers.GetWhoUserFollows("alice").First().ShouldEqual("rabbit");
                _followers.GetWhoUserFollows("rabbit").First().ShouldEqual("alice");
            }
        }
    }
}
