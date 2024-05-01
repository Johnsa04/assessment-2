using System;
using System.IO;

namespace assessment_2
{
    public class Statistics
    {
        private string filePath;

        public Statistics()
        {
            filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "statistics.txt");
            InitializeFile();
        }

        private void InitializeFile()
        {
            if (!File.Exists(filePath))
            {
                using (StreamWriter writer = File.CreateText(filePath))
                {
                    writer.WriteLine("Games Played: 0");
                    writer.WriteLine("Highest Score: 0");
                }
            }
        }

        public void UpdateStatistics(int GamesPlayed, int FinalScore)
        {
            int TotalGamesPlayed = 0;
            int HighestScore = 0;

            using (StreamReader reader = File.OpenText(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("Games Played:"))
                    {
                        TotalGamesPlayed = int.Parse(line.Split(':')[1].Trim());
                    }
                    else if (line.StartsWith("Highest Score:"))
                    {
                        HighestScore = int.Parse(line.Split(':')[1].Trim());
                    }
                }
            }

            TotalGamesPlayed += GamesPlayed;
            HighestScore = Math.Max(HighestScore, FinalScore);

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"Games Played: {TotalGamesPlayed}");
                writer.WriteLine($"Highest Score: {HighestScore}");
            }
        }

        public string GetStatistics()
        {
            string statisticsData = "";

            using (StreamReader reader = File.OpenText(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    statisticsData += line + "\n";
                }
            }

            return statisticsData;
        }
    }
}