using Chirpy.App.Model;
using NUnit.Framework;
using Should;

namespace Chirpy.Tests.Model
{
    class WallQueryTests
    {

        [TestFixture]
        public class when_parsing_valid_reading_query
        {
            readonly WallQuery query = new WallQuery("wall: alice");

            [Test]
            public void parses_the_message()
            {
                query.User.ShouldEqual("alice");
            }
        }
    }
}
