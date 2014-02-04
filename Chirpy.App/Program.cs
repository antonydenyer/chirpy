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
            var postingRepository = new PostingRepository();
            var followingRepository = new FollowingRepository();

            var commandHandlers = new List<ICommandHandler>
                {
                    new PostingCommandHandler(postingRepository),
                    new FollowingCommandHandler(followingRepository)
                };

            var queryHandlers = new List<IQueryHandler>
                {
                    new ReadingQueryHandler(postingRepository),
                    new WallQueryHandler(postingRepository, followingRepository)
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
