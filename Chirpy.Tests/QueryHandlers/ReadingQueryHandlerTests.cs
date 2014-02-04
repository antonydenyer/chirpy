using System.Linq;
using Chirpy.App.Model;
using Chirpy.App.QueryHandlers;
using Chirpy.App.Repository;
using NUnit.Framework;
using Should;

namespace Chirpy.Tests.QueryHandlers
{
    public class ReadingQueryHandlerTests
    {
        [TestFixture]
        public class when_a_handling_a_reading_query
        {
            private PostingRepository _postings;
            private ReadingQueryHandler _readingQueryHandler;

            [SetUp]
            public void setup()
            {
                _postings = new PostingRepository();
                _postings.Add(new Posting("alice","any old message"));
                _readingQueryHandler = new ReadingQueryHandler(_postings);
            }


            [Test]
            public void and_we_search_for_something_that_doesnt_exist()
            {
                var result = _readingQueryHandler.Handle("reading: bob");

                result.Count().ShouldEqual(0);
            }
       
            [Test]
            public void and_we_search_for_something_that_is_present()
            {
                var result = _readingQueryHandler.Handle("reading: alice").ToList();

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
