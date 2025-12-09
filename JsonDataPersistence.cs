using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace GameLibraryManager
{
    public class JsonDataPersistence : IDataPersistence
    {
        private const string PlayersFile = "players.json";
        private const string GamesFile = "games.json";

        public List<Player> LoadPlayers()
        {
            if (!File.Exists(PlayersFile))
            {
                return new List<Player>();
            }
            string json = File.ReadAllText(PlayersFile);
            return JsonConvert.DeserializeObject<List<Player>>(json) ?? new List<Player>();
        }

        public void SavePlayers(List<Player> players)
        {
            string json = JsonConvert.SerializeObject(players, Formatting.Indented);
            File.WriteAllText(PlayersFile, json);
        }

        public List<Game> LoadGames()
        {
            if (!File.Exists(GamesFile))
            {
                return new List<Game>();
            }
            string json = File.ReadAllText(GamesFile);
            return JsonConvert.DeserializeObject<List<Game>>(json) ?? new List<Game>();
        }

        public void SaveGames(List<Game> games)
        {
            string json = JsonConvert.SerializeObject(games, Formatting.Indented);
            File.WriteAllText(GamesFile, json);
        }
    }
}
