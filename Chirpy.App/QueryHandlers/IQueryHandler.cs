using System;
using System.Collections.Generic;

namespace Chirpy.App.QueryHandlers
{
    internal interface IQueryHandler
    {
        IEnumerable<string> Handle(string message);
    }
}