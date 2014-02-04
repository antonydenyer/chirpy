using System;
using System.Collections.Generic;
using System.Linq;
using Chirpy.App.Model;
using Chirpy.App.Repository;

namespace Chirpy.App.QueryHandlers
{
    public class WallQueryHandler : IQueryHandler
    {
        private readonly PostingRepository _postingRepository;
        private readonly FollowingRepository _followingRepository;

        public WallQueryHandler(PostingRepository postingRepository,FollowingRepository followingRepository)
        {
            _postingRepository = postingRepository;
            _followingRepository = followingRepository;
        }

        public IEnumerable<string> Handle(string message)
        {
            if (!message.StartsWith("wall", StringComparison.InvariantCultureIgnoreCase))
                return new string[] { };

            var query = new WallQuery(message);

            var following = _followingRepository.GetUsersIFollow(query.User);
            return _postingRepository
                .GetPostingsFor(following)
                .Select(x => string.Format("{0} - {1} ({2})",x.User, x.Message, x.Timestamp));

        }
    }
}