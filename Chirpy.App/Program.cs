using System;
using System.Collections.Generic;
using Chirpy.App.CommandHandlers;
using Chirpy.App.QueryHandlers;
using Chirpy.App.Repository;
using MoreLinq;

namespace Chirpy.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new PostingRepository();
            var commandHandlers = new List<ICommandHandler>
                {
                    new PostingCommandHandler(repository)
                };

            var queryHandlers = new List<IQueryHandler>
                {
                    new ReadingQueryHandler(repository)
                };

            string input;
            do
            {
                Console.Write("$");
                input = Console.ReadLine();
                commandHandlers.ForEach(x => x.Handle(input));
                queryHandlers.ForEach(x => x.Handle(input).ForEach(Console.WriteLine));

            } while (input != "exit");

        }
    }
}
