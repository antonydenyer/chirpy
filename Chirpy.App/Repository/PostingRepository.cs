using System.Collections.Generic;
using System.Linq;
using Chirpy.App.Model;

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

        public IEnumerable<Posting> GetPostingsFor(IEnumerable<string> following)
        {
            return _postings.Where(x => following.Contains(x.User));
        }

        public void Add(Posting posting)
        {
            _postings.Add(posting);
        }
    }
}