using assessment_2;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;

namespace assessment_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SevensOut game = new SevensOut();
            Statistics stats = new Statistics();
            Console.WriteLine("Welcome to Sevens out, a game where you take it in turns to roll two dice");
            Console.WriteLine("If the sum of the dice rolls is 7, the game ends and the player with the higher score wins");

            while (true)
            {
                int UserChoice;

                do
                {
                    Console.WriteLine("Would you like to play (1) multiplayer (2) against the computer or (3) view game statistics or (4) to exit or (5) to run tests");
                    string choice = Console.ReadLine();

                    if (int.TryParse(choice, out UserChoice))
                    {
                        if (UserChoice == 1 || UserChoice == 2)
                        {
                            bool againstComputer = (UserChoice == 2);
                            (int gameCounter, int totalScore) = game.StartGame(againstComputer);
                            Console.WriteLine($"You played {gameCounter} games and scored a total of {totalScore}!");
                        }
                        else if (UserChoice == 3)
                        {
                           
                            DisplayStatistics();
                        }
                        else if (UserChoice == 4)
                        {
                            Environment.Exit(0);
                        }
                        else if (UserChoice == 5)
                        {
                            Testing.RunTests();
                        }
                        else
                        {
                            Console.WriteLine("Invalid input. Please enter (1) for multiplayer (2) to play against the computer or (3) to view game statistics.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter (1) for multiplayer (2) to play against the computer or (3) to view game statistics.");
                    }
                } while (UserChoice < 6);

            }
            static void DisplayStatistics()
            {
                Statistics stats = new Statistics();
                string statisticsData = stats.GetStatistics();
                Console.WriteLine("Game Statistics:");
                Console.WriteLine(statisticsData);
            }


        }


    }


}

