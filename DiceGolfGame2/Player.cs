using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGolfGame2
{
    class Player
    {
        public string name;
        public int score;
        public int numOfRolls;
        public bool isInactive;
        public Player()
        {
            score = 0;
            numOfRolls = 0;
            isInactive = false;
        }
        public virtual int TakeTurn()
        {
            numOfRolls++;
            Console.WriteLine(name + " how many sides do you want on your dice? (6, 8, 10, 12, 20)");
            switch (Convert.ToInt32(Console.ReadLine()))
            {
                case 6:
                    return 1;
                case 8:
                    return 2;
                case 10:
                    return 3;
                case 12:
                    return 4;
                case 20:
                    return 5;
                default:
                    Console.WriteLine("Not a valid Selection. Six sided dice chosen for you.");
                    return 1;
            }

        }
        public void AddtoScore(int newScore)
        {
            int tempScore = score + newScore;
            if(tempScore > 200)
            {
                score = score - newScore;
            } else
            {
                score = score + newScore;
            }
        }
        public bool CheckIfBunker(Course course)
        {
            if (score != 0)
            {
                if (course.sand1 == score)
                {
                    return false;
                }
                else if (course.sand2 == score)
                {
                    return false;
                }
                else if (course.sand3 == score)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
        }

    }
}
