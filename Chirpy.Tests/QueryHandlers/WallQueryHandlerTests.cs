using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chirpy.App.Model;
using Chirpy.App.QueryHandlers;
using Chirpy.App.Repository;
using NUnit.Framework;
using Should;

namespace Chirpy.Tests.QueryHandlers
{
    class WallQueryHandlerTests
    {
        [TestFixture]
        public class when_a_handling_a_reading_query
        {
            private PostingRepository _postings;
            private FollowingRepository _following;
            private WallQueryHandler _readingQueryHandler;

            [SetUp]
            public void setup()
            {
                _postings = new PostingRepository();
                _following = new FollowingRepository();
                _postings.Add(new Posting("bob", "any old message"));
                _following.Add(new Following("alice","bob"));

                _readingQueryHandler = new WallQueryHandler(_postings,_following);
            }


            [Test]
            public void and_we_search_for_something_that_doesnt_exist()
            {
                var result = _readingQueryHandler.Handle("wall: bob");

                result.Count().ShouldEqual(0);
            }

            [Test]
            public void and_we_search_for_something_that_is_present()
            {
                var result = _readingQueryHandler.Handle("wall: alice").ToList();

                result.Count.ShouldEqual(1);
                result.First().ShouldContain("any old message");
            }
        }

        [TestFixture]
        public class when_a_another_query_is_received
        {
            private PostingRepository _postings;
            private ReadingQueryHandler _readingQueryHandler;

            [SetUp]
            public void setup()
            {
                _postings = new PostingRepository();
                _readingQueryHandler = new ReadingQueryHandler(_postings);
            }

            [Test]
            public void the_message_is_not_stored()
            {
                _readingQueryHandler.Handle("posting: alice").ShouldBeEmpty();
            }
        }

    }
}
