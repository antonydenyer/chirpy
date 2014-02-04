using System.Collections.Generic;
using System.Linq;

namespace Chirpy.App.Repository
{
    public class PostingRepository
    {
        readonly IList<Posting> _postings = new List<Posting>();

        public int Count
        {
            get { return _postings.Count; }
        }

        public IEnumerable<Posting> GetPostingsFor(string user)
        {
            return _postings.Where(x => x.User == user);
        }

        public void Add(Posting command)
        {
            _postings.Add(command);
        }
    }
}