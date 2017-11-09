using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            game.Roll(10);
            game.Roll(5);
            game.Roll(5);
            game.Roll(10);
            game.Roll(5);
            game.Roll(5);
            game.Roll(10);
            game.Roll(5);
            game.Roll(5);
            game.Roll(10);
            game.Roll(5);
            game.Roll(5);
            game.Roll(10);
            game.Roll(5);
            game.Roll(5);
            game.Roll(10);

            Console.Write(game.ToString());
            Console.ReadLine();
        }
    }
}
