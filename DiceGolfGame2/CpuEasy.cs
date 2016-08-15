using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGolfGame2
{
    class CpuEasy : Cpu
    {

        public CpuEasy(int number)
        {
            name = "CPU" + number;
        }
        public override int TakeTurn()
        {
            numOfRolls++;
            Random rand = new Random();
            return rand.Next(1, 6);

        }
    }
}
