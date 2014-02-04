using Chirpy.App.Model;
using Chirpy.App.Repository;
using NUnit.Framework;
using Should;

namespace Chirpy.Tests.CommandHandlers
{
    public class PostingCommandTests
    {
        [TestFixture]
        public class when_parsing_valid_posting_command
        {
            readonly Posting command = new Posting("posting: alice -> any old message");

            [Test]
            public void parses_the_message()
            {
                command.User.ShouldEqual("alice");
                command.Message.ShouldEqual("any old message");
            }
        }
    }
}