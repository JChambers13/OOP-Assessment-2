using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace OOP_Assessment_Two
{
    internal class Testing : ITesting
    {
        private SevensOut sevens = new SevensOut();
        private ThreeOrMore threes = new ThreeOrMore();
        private Die testDie = new Die();
        private bool _notSeven;
        private StreamWriter _writer = null;
        private string _docPath = "";
        private int _threeScore;
        private int _dieSum;
        private bool _dieSumTest;
        private string _date;
        private DateTime _time;
        private string threesScore, sevensOut, dieRoll, correctDieSum;
        string _realDocPath;
        private int _threeScore1, _threeScore2;
        private int roll;
        public Testing()
        {
            _docPath = Directory.GetCurrentDirectory();
            _realDocPath = Path.Combine(_docPath, "testLog.txt");
        }
        
        /// <summary>
        /// This method carries out the required tests. The results are outputted to the .txt file.
        /// </summary>
        public void Tests()
        {
            //Guard clause. Checks the file does indeed exist.
            if (File.Exists(_realDocPath) == false)
            {
                Console.WriteLine("The test file does not exist! Exiting testing now");
                return;
            }
            _time = DateTime.Now; //Gets current time
            _date = "The Log for the test that started at: " + _time;

            //The test to make sure SevensOut ends on a 7
            _notSeven = true;
            while (_notSeven)
            {
                (roll, _notSeven) = sevens.NewGo(1);
                
            }
            Console.WriteLine("Final roll was: " + roll);
            Debug.Assert(roll == 7, "Final roll was not 7");
            sevensOut = "Final sum of rolls in Sevens Out was: " + roll;

            //The test to make sure the die sum in SevensOut is correct
            (_dieSum, _dieSumTest) = sevens.NewGo(3);
            correctDieSum = "Was the sum correct? " + _dieSumTest;

            //Test to ensure ThreeOrMore ends when one player reaches 20.
            Console.WriteLine("This is the test game of three or more");
            (_threeScore1, _threeScore2) = threes.Game();
            if (_threeScore1 > _threeScore2) { _threeScore = _threeScore1; }
            else { _threeScore = _threeScore2; }
            threesScore = "Final winning score: " + _threeScore;
            Debug.Assert(_threeScore >= 20, "Score is not over 20");

            //Test to ensure die value is within expected range
            roll = testDie.RollDice();
            dieRoll = "Die roll is: " + roll;
            Debug.Assert(0 < roll && 7 > roll, "Die is out of range");

            //Writes results to file.
            using (_writer = new StreamWriter(_realDocPath, true))
            {
                _writer.WriteLine(_date);
                _writer.WriteLine(correctDieSum);
                _writer.WriteLine(threesScore);
                _writer.WriteLine(dieRoll);
                _writer.WriteLine(sevensOut);
                _writer.WriteLine("----------------");
            }
            Console.WriteLine("Testing complete.");
        }
        
    }
}
