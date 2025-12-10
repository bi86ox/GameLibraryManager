using System.Collections.Generic;

namespace GameLibraryManager
{
    public class GameLibrary
    {
        private static GameLibrary? _instance;
        private static readonly object _lock = new object();

        public List<Player> Players { get; private set; }
        public List<Game> Games { get; private set; }
        private IDataPersistence _dataPersistence;
        private Logger _logger;

        private GameLibrary()
        {
            Players = new List<Player>();
            Games = new List<Game>();
            _dataPersistence = new JsonDataPersistence();
            _logger = new Logger();
            LoadData();
        }

        public static GameLibrary Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new GameLibrary();
                    }
                    return _instance;
                }
            }
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
            _logger.Log($"Player added: {player.Username}");
            SaveData();
        }

        public void UpdatePlayerStats(int playerId, int hours, int score)
        {
            var player = Players.Find(p => p.Id == playerId);
            if (player != null)
            {
                player.Stats.UpdateStats(hours, score);
                _logger.Log($"Player stats updated: {player.Username}");
                SaveData();
            }
        }

        public Player? SearchPlayerById(int id)
        {
            return Players.Find(p => p.Id == id);
        }

        public List<Player> SortPlayersByHighScore()
        {
            var sorted = new List<Player>(Players);
            sorted.Sort((p1, p2) => p2.Stats.HighScore.CompareTo(p1.Stats.HighScore));
            return sorted;
        }

        private void LoadData()
        {
            try
            {
                Players = _dataPersistence.LoadPlayers();
                Games = _dataPersistence.LoadGames();
            }
            catch
            {
                // Handle errors, perhaps log
            }
        }

        private void SaveData()
        {
            try
            {
                _dataPersistence.SavePlayers(Players);
                _dataPersistence.SaveGames(Games);
            }
            catch
            {
                // Handle errors
            }
        }
    }
}
