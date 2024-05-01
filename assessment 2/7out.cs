using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Linq;

namespace assessment_2
{
    public class SevensOut
    {
        private Dice dice;
        private int GameCounter;
        private Statistics stats;
       

        public SevensOut()
        {
            dice = new Dice();
            GameCounter = 0;
            stats = new Statistics();
        }
        public (int, int) StartGame(bool AgainstCPU = false)
        {
            int totalScore = 0;

            do
            {
                int finalScore = OpponentChoice(AgainstCPU);
                totalScore += finalScore;

                GameCounter++;

                Console.WriteLine("Do you want to play again? (yes/no)");
                string playAgain = Console.ReadLine().ToLower();

                if (playAgain != "yes")
                {
                    Console.WriteLine("Thanks for playing!");
                    return (GameCounter, totalScore);
                }

            } while (true);
        }


        public int OpponentChoice(bool AgainstCPU = false)
        {
            string PlayerOneName;
            string PlayerTwoName;

            if (AgainstCPU)
            {
                do
                {
                    Console.WriteLine("Please enter your name Player 1: ");
                    PlayerOneName = Console.ReadLine();

                    if (string.IsNullOrEmpty(PlayerOneName))
                    {
                        Console.WriteLine("This name is invalid");
                    }

                } while (string.IsNullOrEmpty(PlayerOneName));

                int FinalScore = Play(PlayerOneName, "Computer");
            }
            else
            {
                do
                {
                    Console.WriteLine("Please enter your name Player 1: ");
                    PlayerOneName = Console.ReadLine();

                    if (string.IsNullOrEmpty(PlayerOneName))
                    {
                        Console.WriteLine("This name is invalid");
                    }

                } while (string.IsNullOrEmpty(PlayerOneName));

                do
                {
                    Console.WriteLine("Please enter your name Player 2: ");
                    PlayerTwoName = Console.ReadLine();

                    if (string.IsNullOrEmpty(PlayerTwoName))
                    {
                        Console.WriteLine("This name is invalid");
                    }

                } while (string.IsNullOrEmpty(PlayerTwoName));

                int FinalScore = Play(PlayerOneName, PlayerTwoName);
            }
            return 0;            

            
        }

        private int Play(string PlayerOneName, string PlayerTwoName)
        {
            int PlayerOneScore = 0;
            int PlayerTwoScore = 0;

            while (true)
            {
                Console.WriteLine($"{PlayerOneName} press Enter to roll the dice");
                Console.ReadKey();
                int PlayerOneRoll = dice.Roll();
                int PlayerOneRollTwo = dice.Roll();
                Console.WriteLine($"{PlayerOneName} you have rolled {PlayerOneRoll} and {PlayerOneRollTwo}");
                PlayerOneScore = PlayerOneScore + PlayerOneRoll + PlayerOneRollTwo;
                Console.WriteLine($"{PlayerOneName} current score is {PlayerOneScore}");

                if (PlayerOneRoll + PlayerOneRollTwo == 7)
                {
                    Console.WriteLine("A player has rolled a sum of 7");
                    stats.UpdateStatistics(GameCounter, Math.Max(PlayerOneScore, PlayerTwoScore));
                    break;
                }

                Console.WriteLine($"{PlayerTwoName} press Enter to roll the dice");
                Console.ReadKey();
                int PlayerTwoRoll = dice.Roll();
                int PlayerTwoRollTwo = dice.Roll();
                Console.WriteLine($"{PlayerTwoName} you have rolled {PlayerTwoRoll} and {PlayerTwoRollTwo}");
                PlayerTwoScore = PlayerTwoScore + PlayerTwoRoll + PlayerTwoRollTwo;
                Console.WriteLine($"{PlayerTwoName} current score is {PlayerTwoScore}");

                if (PlayerTwoRollTwo + PlayerTwoRollTwo == 7)
                {
                    Console.WriteLine("A player has rolled a sum of 7");
                    stats.UpdateStatistics(GameCounter, Math.Max(PlayerOneScore, PlayerTwoScore));
                    break;
                }

            }

            if (PlayerOneScore > PlayerTwoScore)
            {
                Console.WriteLine($"{PlayerOneName} wins with a score of {PlayerOneScore}!");
                return PlayerOneScore;
            }
            else if (PlayerTwoScore > PlayerOneScore)
            {
                Console.WriteLine($"{PlayerTwoName} wins with a score of {PlayerTwoScore}!");
                return PlayerTwoScore;
            }
            else
            {
                Console.WriteLine($"It's a tie with a score of {PlayerOneScore}");
                return PlayerOneScore;
            }


        }
    }
}