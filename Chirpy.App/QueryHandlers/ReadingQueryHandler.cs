using System;
using System.Collections.Generic;
using System.Linq;
using Chirpy.App.Model;
using Chirpy.App.Repository;

namespace Chirpy.App.QueryHandlers
{
    public class ReadingQueryHandler : IQueryHandler
    {
        private readonly PostingRepository _repository;

        public ReadingQueryHandler(PostingRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<string> Handle(string message)
        {
            if (!message.StartsWith("reading", StringComparison.InvariantCultureIgnoreCase))
                return new string []{};

            var query = new ReadingQuery(message);
            return _repository
                .GetPostingsFor(query.User)
                .Select(x => string.Format("{0} ({1})", x.Message, x.Timestamp));
            ;
        }
    }
}