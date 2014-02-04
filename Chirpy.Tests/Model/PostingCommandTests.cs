using Chirpy.App.Model;
using NUnit.Framework;
using Should;

namespace Chirpy.Tests.Model
{
    public class PostingCommandTests
    {
        [TestFixture]
        public class when_parsing_valid_posting_command
        {
            readonly PostingCommand command = new PostingCommand("posting: alice -> any old message");

            [Test]
            public void parses_the_message()
            {
                command.Posting.User.ShouldEqual("alice");
                command.Posting.Message.ShouldEqual("any old message");
            }
        }
    }
}