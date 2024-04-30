using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assessment_Two
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            bool play = true;
            //This loops until user is finished
            while (play)
            {
                play = game.Menu();
            }
        }      
    }
}
