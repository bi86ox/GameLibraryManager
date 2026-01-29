using System.Collections.Generic;
using System.Linq;

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

        // Initialize factories / ids after loading persisted data
        private void InitializeAfterLoad()
        {
            int nextPlayerId = 1;
            if (Players != null && Players.Any())
            {
                nextPlayerId = Players.Max(p => p.Id) + 1;
            }
            PlayerFactory.Initialize(nextPlayerId);
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
                InitializeAfterLoad();
            }
            catch
            {
                // Handle errors, perhaps log
            }
        }

        public void AddGame(Game game)
        {
            Games.Add(game);
            _logger.Log($"Game added: {game.Title}");
            SaveData();
        }

        public Game? SearchGameById(int id)
        {
            return Games.Find(g => g.Id == id);
        }

        public bool RemovePlayerById(int id)
        {
            var player = Players.Find(p => p.Id == id);
            if (player != null)
            {
                Players.Remove(player);
                _logger.Log($"Player removed: {player.Username}");
                SaveData();
                return true;
            }
            return false;
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
