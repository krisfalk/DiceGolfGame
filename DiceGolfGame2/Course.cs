using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGolfGame2
{
    class Course
    {
        public int holeNum;
        public int sand1;
        public int sand2;
        public int sand3;
        public Course(int hole, int Sand1, int Sand2, int Sand3)
        {
            holeNum = hole;
            sand1 = Sand1;
            sand2 = Sand2;
            sand3 = Sand3;
        }
        public void DisplayHole()
        {
            Console.WriteLine("You are on hole number {0}.", holeNum);
            if(sand1 != 0)
            {
                Console.WriteLine("There is a sand bunker at {0}.", sand1);
            }
            if (sand2 != 0)
            {
                Console.WriteLine("There is a sand bunker at {0}.", sand2);
            }
            if (sand3 != 0)
            {
                Console.WriteLine("There is a sand bunker at {0}.", sand3);
            }
        }
    }
}
