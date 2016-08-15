using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGolfGame2
{
    class CpuHard : Cpu
    {
        public CpuHard(int number)
        {
            name = "CPU" + number;
        }
        public override int TakeTurn()
        {
            numOfRolls++;
            Random rand = new Random();

            if(score == 0)
            {
                return 5;
            }else if(score <= 80)
            {
                return 4;
            }else if(score <= 100)
            {
                return 3;
            }else if(score <= 120)
            {
                return 2;
            }
            else
            {
                return 1;
            }
        }
    }
}
