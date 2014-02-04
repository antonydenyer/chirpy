using System.Linq;
using Chirpy.App.CommandHandlers;
using Chirpy.App.Repository;
using NUnit.Framework;
using Should;

namespace Chirpy.Tests.CommandHandlers
{
    public class PostingCommandHandlerTests
    {
        [TestFixture]
        public class when_a_posting_command_is_received
        {
            private PostingRepository _postings;
            private PostingCommandHandler _postingCommandHandler;

            [SetUp]
            public void setup()
            {
                _postings = new PostingRepository();
                _postingCommandHandler = new PostingCommandHandler(_postings);
            }

            [Test]
            public void the_single_chirp_gets_stored()
            {
                _postingCommandHandler.Handle("posting: alice -> any old message");
                _postings.Count.ShouldEqual(1);
                _postings.GetPostingsFor("alice").First().Message.ShouldEqual("any old message");
            }


            [Test]
            public void multiple_chirps_get_stored_in_chronological_order()
            {
                _postingCommandHandler.Handle("posting: alice -> first");
                _postingCommandHandler.Handle("posting: alice -> second");
                _postings.Count.ShouldEqual(2);
                _postings.GetPostingsFor("alice").Count().ShouldEqual(2);
                _postings.GetPostingsFor("alice").First().Message.ShouldEqual("first");
                _postings.GetPostingsFor("alice").Last().Message.ShouldEqual("second");
            }
        }

        [TestFixture]
        public class when_a_another_command_is_received
        {
            private PostingRepository _postings;
            private PostingCommandHandler _postingCommandHandler;

            [SetUp]
            public void setup()
            {
                _postings = new PostingRepository();
                _postingCommandHandler = new PostingCommandHandler(_postings);
            }

            [Test]
            public void the_message_is_not_stored()
            {
                _postingCommandHandler.Handle("INVALID_MESSAGE: alice -> any old message");
                _postings.Count.ShouldEqual(0);
            }
        }
    }
}