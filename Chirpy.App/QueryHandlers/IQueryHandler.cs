using System;
using System.Collections.Generic;

namespace Chirpy.App.QueryHandlers
{
    public interface IQueryHandler
    {
        IEnumerable<string> Handle(string message);
    }
}