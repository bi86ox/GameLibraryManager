using System.Collections.Generic;

namespace GameLibraryManager
{
    public interface IDataPersistence
    {
        List<Player> LoadPlayers();
        void SavePlayers(List<Player> players);
        List<Game> LoadGames();
        void SaveGames(List<Game> games);
    }
}
