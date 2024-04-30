using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assessment_Two
{
    internal class Statistics
    {
        private int _sevensGames;
        public int sevensGames {  get { return _sevensGames; } set { _sevensGames = value; } }

        private int _threesGames;
        public int threesGames { get { return _threesGames; } set { _threesGames = value; } }

        private int _sevensHighScore;
        public int sevensHighScore {  get { return _sevensHighScore; }  set {_sevensHighScore = value; } }

        private int _threesHighScore;
        public int threesHighScore { get { return _threesHighScore; } set { _threesHighScore = value; } }

        public List<int> sevensScores = new List<int>();
        public List<int> threesScores = new List<int>();
        private IEnumerable<int> over75;
        public Statistics() 
        {
            _sevensGames = 0;
            _threesGames = 0;         
        }
        /// <summary>
        /// Calculates the high score of a game
        /// </summary>
        /// <param name="list"></param>
        /// <returns>The highest score achieved</returns>
        private int HighScore(List<int> list)
        {
            list.Sort();
            list.Reverse();
            return list[0];

        }
        /// <summary>
        /// Prints the statistics to the screen
        /// </summary>
        public void PrintStats()
        {
            
            if (sevensGames > 0) //Only prints SevensOut high score if a game has been played
            {
                _sevensHighScore = HighScore(sevensScores);
                Console.WriteLine("SevensOut high score is: " + _sevensHighScore); 
            }
            if (threesGames > 0) //Only prints ThreeOrMore high score if a game has been played
            {
                _threesHighScore = HighScore(threesScores);
                Console.WriteLine("Three or more high score is: " + _threesHighScore); 
            }
            Console.WriteLine("You have played: " + _sevensGames + " sevens out games");
            Console.WriteLine("You have played: " + _threesGames + " three or more games");
            over75 = from n in sevensScores //Finds all SevensOut scores over 75
                     where n > 75
                     select n;
            if (over75.Any()) //If any scores are over 75, they are printed
            {
                Console.WriteLine("These are your scores over 75 on SevensOut");
            }
            foreach (int i in over75)
            {
                Console.WriteLine(i);
            }   
            
        }
    }
}
