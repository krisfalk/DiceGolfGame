using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DiceGolfGame2
{
    class Game
    {
        int numOfPlayers;
        int numOfInactives;
        Player[] players;
        Course[] course;
        Dice[] allDice;
        public Game()
        {
            Console.WriteLine("Welcome to Dice Golf!!!");
            SetupCourse();
            CreateAllDie();
            numOfPlayers = AskNumberPlayers();
            players = new Player[numOfPlayers];
            FillPlayerArray();            
        }
        public void SetupCourse()
        {
            course = new Course[6];
            course[0] = new Course(1, 0, 0, 0);
            course[1] = new Course(2, 0, 0, 120);
            course[2] = new Course(3, 0, 20, 140);
            course[3] = new Course(4, 0, 100, 120);
            course[4] = new Course(5, 20, 50, 100);
            course[5] = new Course(6, 120, 140, 150);
        }
        public int AskNumberPlayers()
        {
            Console.WriteLine("How many total players for this course? (1-4)");
            return Convert.ToInt32(Console.ReadLine());
        }
        public void FillPlayerArray()
        {
            for (int i = 0; i < players.Length; i++)
            {
                Console.WriteLine("Enter name of player {0} or type 'cpu' to make player {0} a computer:", i + 1);
                string current = Console.ReadLine();
                if (current == "cpu")
                {
                    Console.WriteLine("Enter the difficulty for this CPU: (easy or hard)");
                    if(Console.ReadLine() == "easy")
                    {
                        players[i] = new CpuEasy(i + 1);
                    }
                    else
                    {
                        players[i] = new CpuHard(i + 1);
                    }
                }
                else
                {
                    players[i] = new Person(current);
                }
            }
        }
        
        public void CreateAllDie()
        {
            allDice = new Dice[6];
            allDice[0] = new Dice(4);
            allDice[1] = new Dice(6);
            allDice[2] = new Dice(8);
            allDice[3] = new Dice(10);
            allDice[4] = new Dice(12);
            allDice[5] = new Dice(20);
        }
        public void RunGame()
        {
            for(int i = 0; i < course.Length; i++)
            {
                ResetInactiveCount();
                Console.Clear();
                course[i].DisplayHole();
                while (SomeoneStillActive(players.Length))
                {
                    for (int p = 0; p < players.Length; p++)
                    {
                        if (players[p].score != 200)
                        {
                            Thread.Sleep((int)TimeSpan.FromSeconds(.2).TotalMilliseconds);
                            Console.WriteLine(players[p].name + " score is {0}", players[p].score);
                            if (players[p].CheckIfBunker(course[i]))
                            {
                                players[p].AddtoScore(allDice[players[p].TakeTurn()].GetRandomNum());
                                Console.WriteLine(players[p].name + "'s new score is {0}\n", players[p].score);
                            }
                            else
                            {
                                Console.WriteLine("{0}, you are in the sand bunker. A four sided dice rolled for you.", players[p].name);
                                players[p].AddtoScore(allDice[0].GetRandomNum());
                                Console.WriteLine(players[p].name + "'s new score is {0}\n", players[p].score);
                            }
                        }
                        else
                        {
                            players[p].isInactive = true;
                        }
                    }
                }
            }
        }
        public bool SomeoneStillActive(int check)
        {
            if(CountInactives() == players.Length)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public int CountInactives()
        {
            numOfInactives = 0;
            for(int i = 0; i < players.Length; i++)
            {
                if (players[i].isInactive)
                {
                    numOfInactives++;
                }
            }
            return numOfInactives;
        }
        public void ResetInactiveCount()
        {
            for (int i = 0; i < players.Length; i++)
            {
                players[i].score = 0;
                players[i].isInactive = false;
            }
        }
        public void EndGame()
        {
            Console.Clear();
            for (int i = 0; i < players.Length; i++)
            {
                Console.WriteLine("{0}'s final roll count is {1}.\n", players[i].name, players[i].numOfRolls);
            }
            Console.WriteLine("\nPress enter to exit.");
            Console.ReadLine();
        }
    }
}
