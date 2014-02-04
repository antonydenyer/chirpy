using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chirpy.App.MessageHandlers;
using Chirpy.App.Repository;

namespace Chirpy.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new PostingRepository();
            var commandHandlers = new List<ICommandHandler>
                {
                    new PostingCommandHandler(repo)
                };

            string input; 
            do
            {
                Console.Write("$");
                input = Console.ReadLine(); 
                commandHandlers.ForEach(x=>x.Handle(input));

            } while (input != "exit");

        }
    }
}
