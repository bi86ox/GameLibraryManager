using System.Collections.Generic;

namespace GameLibraryManager
{
    public class PlayerStats
    {
        public int TotalHoursPlayed { get; set; }
        public int HighScore { get; set; }
        public List<Game> FavoriteGames { get; set; }

        public PlayerStats()
        {
            TotalHoursPlayed = 0;
            HighScore = 0;
            FavoriteGames = new List<Game>();
        }

        public void UpdateStats(int hours, int score)
        {
            TotalHoursPlayed += hours;
            if (score > HighScore)
            {
                HighScore = score;
            }
        }

        public override string ToString()
        {
            return $"Total Hours: {TotalHoursPlayed}, High Score: {HighScore}, Favorite Games: {FavoriteGames.Count}";
        }
    }
}
