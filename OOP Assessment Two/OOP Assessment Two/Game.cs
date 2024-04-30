using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Media;

namespace OOP_Assessment_Two
{
    internal class Game : IMenu
    {
        
        public SevensOut sevens = new SevensOut();
        public Statistics gameStats = new Statistics();
        public ThreeOrMore threes = new ThreeOrMore();
        public Testing testing = new Testing();
        private int _score1;
        private int _score2;
        private string _play;
        /// <summary>
        /// Allows the player to play either game, conduct tests or view stats
        /// </summary>
        /// <returns>Whether the player is finished in the program</returns>
        public bool Menu()
        {
            Console.WriteLine("What would you like to do? Enter 3 for three or more / 7 for 7s out: ");
            Console.WriteLine("Or enter t for testing or s for statistics");
            string _gameChoice = Console.ReadLine();
            if (_gameChoice == "7") //SevensOut
            {
                (_score1, _score2) = sevens.Game(); 
                gameStats.sevensScores.Add(_score1); //Add scores to list
                gameStats.sevensScores.Add(_score2);
                gameStats.sevensGames += 1; //Increase game count by one
            }
            else if (_gameChoice == "3") //ThreeOrMore
            {
                (_score1, _score2) = threes.Game(); 
                gameStats.threesScores.Add(_score1); //Add scores to list 
                gameStats.threesScores.Add(_score2);
                gameStats.threesGames += 1; //Increase game count by one 
            }
            else if (_gameChoice == "s") //Stats
            {
                Console.WriteLine("stats");
                gameStats.PrintStats(); //Calls PrintStats method
            }
            else if (_gameChoice == "t") //Testing
            {
                Console.WriteLine("Testing will commence");
                testing.Tests(); //Calls Tests method
            }
            else
            {
                Console.WriteLine("Invalid choice");
                return true; //Restarts loop if invalid input is entered
            }
            _play = "";
            while(_play != "y" && _play != "n") //Asks user if they wish to play again
            {
                Console.WriteLine("Would you like to do anything else? Enter y/n");
                _play = Console.ReadLine();
            }
            
            if (_play == "y") //If they want to play again, true is returned
            {
                return true;
            }
            else //If not, false is returned
            {
                return false;
            }
           
        }
    }
}
