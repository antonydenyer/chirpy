using Chirpy.App.Model;
using NUnit.Framework;
using Should;

namespace Chirpy.Tests.Model
{
    public class ReadingQueryTests
    {
        [TestFixture]
        public class when_parsing_valid_reading_query
        {
            readonly ReadingQuery query = new ReadingQuery("reading: alice");

            [Test]
            public void parses_the_message()
            {
                query.User.ShouldEqual("alice");
            }
        }
    }
}
