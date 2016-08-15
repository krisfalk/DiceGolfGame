using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGolfGame2
{
    class Dice
    {
        int numOfSides;
        public Dice(int sides)
        {
            numOfSides = sides;
        }
        public int GetRandomNum()
        {
            Random random = new Random();
            return random.Next(1, numOfSides + 1) * 10;
        }
    }
}
