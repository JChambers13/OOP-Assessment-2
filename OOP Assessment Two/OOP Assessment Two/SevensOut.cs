using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assessment_Two
{
    internal class SevensOut : BaseGame 
    {
        private int _thisGo;
        private bool _computer;
        private bool rollAgain;
        private int tempScore;

        /// <summary>
        /// Carries out the main game loop
        /// </summary>
        /// <returns>Player One and player two's scores</returns>
        public override (int, int) Game()
        {
            //Initialise variables for the game
            p1score = 0;
            p2score = 0;
            rollAgain = true;
            Console.WriteLine("Welcome to Sevens Out!");
            _computer = Computer(); //Determine whether playing against computer
            Console.WriteLine("Player One");
            while (rollAgain) //Player One's rolls
            {
                Console.WriteLine("press anything to roll");
                Console.ReadKey();
                (tempScore, rollAgain) = NewGo(1);
                p1score += tempScore; //Adds sum to player one's score
                Console.WriteLine("Current score: " + p1score);
            }
            rollAgain = true;
            if (_computer) { Console.WriteLine("Computer"); }
            else { Console.WriteLine("Player Two"); } //Player Two/Computer's rolls.
            while (rollAgain) 
            {
                Console.WriteLine("press anything to roll");
                Console.ReadKey();
                (tempScore, rollAgain) = NewGo(2); 
                p2score += tempScore; //Adds sum to player two's score
                Console.WriteLine("Current score: " + p2score);
            }
            
            Winner(p1score, p2score, _computer); //Determine the winner
            Console.ReadKey();
            return (p1score, p2score); //Return scores
        }

        /// <summary>
        /// Method carries out two die rolls and sums these values
        /// </summary>
        /// <param name="player"></param>
        /// <returns>Sum of die values</returns>
        public (int, bool) NewGo(int player)
        {
            rolled.Clear(); //Clears the list
            _thisGo = 0;
            Console.WriteLine("Rolling Dice");
            for (int i = 0; i < 2; i++) //Rolls dice twice, adding value to list
            {
                rolled.Add(_die.RollDice());
            }

            foreach (int i in rolled) //Prints rolled values
            {
                Console.WriteLine("Die roll: " + i);
                _thisGo += i;
            }

            //Player == 3 when testing the die sum is correct
            if (player == 3)
            {
                Console.WriteLine("Sum of dice rolls is: " + _thisGo);
                Debug.Assert(rolled[0] + rolled[1] == _thisGo, "Dice sum is not correct!");
                return (_thisGo, (rolled[0] + rolled[1] == _thisGo)); //Returns outcome of test
            }
            if (rolled[0] + rolled[1] == 7) //If 7, end game
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You rolled a sum of seven. That is your last roll.");
                _thisGo = 7;
                Console.ForegroundColor = ConsoleColor.Gray;
                return (_thisGo, false);


            }
            else if (rolled[0] == rolled[1]) //If both values are equal, double the sum is returned
            {
                _thisGo = 2 * _thisGo;
                Console.WriteLine(_thisGo + " will be added to the score");
            }
            else //If both values are different and don't sum to 7, their sum is returned
            {
                Console.WriteLine(_thisGo + "will be added to the score");
            }
            return (_thisGo, true);
        }
    }
}
