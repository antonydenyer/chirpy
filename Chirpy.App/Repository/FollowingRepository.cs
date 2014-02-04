using System.Collections.Generic;
using System.Linq;
using Chirpy.App.Model;

namespace Chirpy.App.Repository
{
    public class FollowingRepository
    {
        readonly List<Following> _followers = new List<Following>();

        public int Count
        {
            get { return _followers.Count; }
        }

        public IEnumerable<string> GetUsersIFollow(string user)
        {
            return _followers.Where(x => x.User == user).Select(x => x.Follows);
        }

        public void Add(Following following)
        {
            if (!GetUsersIFollow(following.User).Contains(following.Follows))
            {
                _followers.Add(following);
            }
        }
    }
}