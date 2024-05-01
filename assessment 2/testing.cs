using System.Diagnostics;

namespace assessment_2
{
    public class Testing
    {
        public static void RunTests()
        {
            TestPlayerScores();
            TestStatisticsUpdate();
            TestDiceRoll();
   
        }

        public static void TestDiceRoll()
        {
            Dice TestDie = new Dice();
            int TestDieRoll = TestDie.Roll();           
            Debug.Assert(TestDieRoll > 6, "dice roll shouldnt be greater than 6");
            Debug.Assert(TestDieRoll < 1, "dice roll shouldnt be smaller than 1");
        }

        public static void TestPlayerScores()
        {
            SevensOut game = new SevensOut();


            (int gameCounter, int totalScore) = game.StartGame(AgainstCPU: false);
            Debug.Assert(gameCounter > 0, "Game counter should be greater than 0");
            Debug.Assert(totalScore >= 0, "Total score should be greater than or equal to 0");
        }

        public static void TestStatisticsUpdate()
        {
            Statistics stats = new Statistics();

 
            stats.UpdateStatistics(GamesPlayed: 1, FinalScore: 100);
            string statisticsData = stats.GetStatistics();
            Debug.Assert(statisticsData.Contains("1 games played"), "Statistics should show 1 game played");
            Debug.Assert(statisticsData.Contains("Highest score: 100"), "Statistics should show highest score as 100");
        }
    }
}
