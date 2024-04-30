using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OOP_Assessment_Two
{
    internal class ThreeOrMore : BaseGame , ITurn
    {
        
        bool _computer;
        private int _turnCount = 0;
        private string _hold;
        int tempScore, mostCommon, mostCommonValue;
        /// <summary>
        /// Changes the player's turn
        /// </summary>
        /// <param name="t"></param>
        /// <returns>0 if Player 2, 1 if Player 1</returns>
        public int turnCounting(int t)
        {
            t++;
            return (t % 2);
        }
        /// <summary>
        /// Carries out the main game loop. 
        /// </summary>
        /// <returns>Player One and Player Two's scores</returns>
        public override (int, int) Game()
        {
            //Initialise variables
            p1score = 0;
            p2score = 0;
            tempScore = 0;
            _computer = Computer(); //Determine whether playing against computer, or against another person
    
            while (p1score < 20 && p2score < 20) //This loop repeats until one person gets score of 20 or higher
            {
                Console.WriteLine("Next rolls are for player: " + ((_turnCount % 2) + 1)); //Determines who's rolls are next
                Console.ReadKey();

                _turnCount = turnCounting(_turnCount); 
                if (_turnCount == 0) //Player 2
                {
                    tempScore = NewGo(_computer);
                    p2score += tempScore; //Correct total added to score
                }
                else //Player 1
                {
                    tempScore = NewGo(false);
                    p1score += tempScore; //Correct total added to score
                }
                Console.WriteLine("Current scores: Player One: " + p1score + " Player Two: " + p2score);

            }
            
            Winner(p1score, p2score, _computer); //Determine the winner
            return (p1score, p2score); 
        }
        /// <summary>
        /// When the player first rolls, this is used. Carries out a players turn. 
        /// </summary>
        /// <param name="computer"></param>
        /// <returns>The total to be added to the player's score</returns>
        private int NewGo(bool computer)
        {
            mostCommon = 0;
            mostCommonValue = 0;
            
            for (int i = 0; i < 5; i++) //Roll 5 values and add them to the list
            {
                rolled.Add(_die.RollDice());
            }
            foreach (int i in rolled) //Prints each rolled value
            {
                Console.WriteLine("Die value: " + i);
            }
            /*
             Checks if a value appears 3 or more times. This is done by looping through all 6 values
             and seeing how many times that value appears. If it appears 3 or more times, then it is 
             the most common and correct value is immediately returned. Otherwise, this is looped for all 
            values.
            */
            for (int i = 1; i < 7; i++) 
            {
                int count = 0;
                foreach (int j in rolled) 
                {
                    if (i == j)
                    {
                        count++;
                    }
                }
                if (count == 3)
                {
                    Console.WriteLine("Three match! Adding three to the score");
                    rolled.Clear();
                    return 3;
                }
                else if (count == 4)
                {
                    Console.WriteLine("Four match! Adding 6 to score");
                    rolled.Clear();
                    return (6);
                }
                else if (count == 5)
                {
                    Console.WriteLine("Five. Adding 12 to score.");
                    rolled.Clear();
                    return 12;
                }
                else if (count == 2)
                {
                    mostCommon = 2;
                    mostCommonValue = i;
                }
            }
            if (mostCommon == 2)
            {
                if (computer) //Computer automatically holds
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (rolled[i] != mostCommonValue)
                        {
                            rolled[i] = 0;
                        }
                    }
                    Console.WriteLine("Holding both: " + mostCommonValue);
                    int score = NewGo(rolled, computer);
                    return score;
                }
                Console.WriteLine("You rolled: " + mostCommonValue + " two times. Would you like to reroll all 5 die, or just the three that are not " + mostCommonValue);
                
                while (_hold != "all" && _hold != "remaining")
                {
                    Console.WriteLine("Enter either 'all, or 'remaining");
                    _hold = Console.ReadLine();
                }
                if (_hold == "remaining") //If user wants to hold, then other die values are set to 0 so they can be rerolled
                {
                    for (int i = 0; i < 5; i++)
                    {
                        if (rolled[i] != mostCommonValue)
                        {
                            rolled[i] = 0;
                        }
                    }
                    int score = NewGo(rolled, computer);
                    return score;
                }
                else //If user wants to reroll all, all die values are reset to 0.
                {
                    for (int i = 0; i < 5; i++)
                    {
                        rolled[i] = 0;
                    }
                    int score = NewGo(rolled, computer);
                    return score;
                }
            }
            //This is carried out if all 5 are different values.
            Console.WriteLine("Not enough match. Nothing will be added to score");
            rolled.Clear();
            return 0;
        }
        /// <summary>
        /// Used when player has rolled 2 of the same value; this carries out the reroll
        /// </summary>
        /// <param name="roll"></param>
        /// <param name="computer"></param>
        /// <returns>The score to be added</returns>
        private int NewGo(List<int> roll, bool computer)
        {
            mostCommon = 0;
            mostCommonValue = 0;
            List<int> rolled = new List<int>();
            // roll all 5 die.
            for (int i = 0; i < 5; i++)
            {
                
                rolled.Add(_die.RollDice());
            }
            try //this checks that a list was passed through
            {
                for (int i = 0; i < 5; i++) //This checks if any values were held from previous roll
                {
                    if (roll[i] != 0) //If value was held, the corresponding die value is changed to match this.
                    {
                        rolled[i] = roll[i];
                    }
                }
            }
            catch 
            {
                Console.WriteLine("No list was passed?");
                return 0;
            }
            
            foreach (int i in rolled) //Prints each rolled value
            {
                Console.WriteLine("Die value: " + i);
            }
            for (int i = 1; i < 7; i++) //Checks if a value appears 3 or more times. Same approach as in above method.
            {
                int count = 0;
                foreach (int j in rolled)
                {
                    if (i == j)
                    {
                        count++;
                    }
                }
                if (count == 3)
                {
                    Console.WriteLine("Three match! Adding 3 to score");
                    rolled.Clear();
                    return 3;
                }
                else if (count == 4)
                {
                    Console.WriteLine("Four match! Adding 6 to score");
                    rolled.Clear();
                    return 6;
                }
                else if (count == 5)
                {
                    Console.WriteLine("Five. Adding 12 to score.");
                    rolled.Clear();
                    return 12;
                }               
            }
            
            Console.WriteLine("Not enough match. Nothing will be added to score");
            rolled.Clear();
            return 0;
        }

    }
}
