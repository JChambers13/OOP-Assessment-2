using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Assessment_Two
{
    internal class Die
    {
        private int _dieValue;
        public int dieValue { get { return _dieValue; } set { _dieValue = value; } }

        static Random rnd = new Random((int)DateTime.Now.Ticks);
        /// <summary>
        /// Calls the method which rolls die, and returns this value to the class.
        /// </summary>
        /// <returns>The die value</returns>
        public int RollDice()
        {
            _dieValue = Rolling(rnd);
            return _dieValue;
        }
        /// <summary>
        /// method that actually rolls the die
        /// </summary>
        /// <param name="rnd"></param>
        /// <returns></returns>
        private int Rolling(Random rnd)
        {
            _dieValue = rnd.Next(1, 7);
            return _dieValue;
        }
    }
}
