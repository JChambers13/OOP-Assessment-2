using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assessment_Two
{
    abstract class BaseGame
    {
        protected List<int> rolled = new List<int>(); //List used for storing die values in both games
        protected int p1score;
        protected int p2score;
        protected Die _die = new Die(); //Die used for rolling in both games
        public abstract (int, int) Game(); //Game method that is overriden by both games.
        string _comp;
        /// <summary>
        /// This method determines whether the user wants to play against a user or against the computer
        /// </summary>
        /// <returns>true if user plays against computer, false otherwise.</returns>
        protected virtual bool Computer()
        {
            while (_comp != "y" && _comp != "n")
            {
                Console.WriteLine("Would you like to play against computer? Enter y for computer, or n for 2 player game");
                _comp = Console.ReadLine();
            }
            
            if (_comp == "y")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Outputs whether Player One, Two, or the computer won the game.
        /// </summary>
        /// <param name="p1score"></param>
        /// <param name="p2score"></param>
        /// <param name="_computer"></param>
        protected virtual void Winner(int p1score, int p2score, bool _computer)
        {
            if (p1score > p2score)
            {
                Console.WriteLine("Player One wins!");
            }
            else
            {
                if (_computer)
                {
                    Console.WriteLine("Computer wins");
                }
                else
                {
                    Console.WriteLine("Player Two wins!");
                }

            }
        }      
    }
}
