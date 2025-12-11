using System;
using System.IO;
using Xunit;
using GameLibraryManager;
using System.Linq;

namespace GameLibraryManagerTests
{
    public class GameLibraryTests
    {
        private const int TestGameId = 999999;
        private const int TestPlayerId = 999998;
        private const string PlayersFile = "players.json";
        private const string GamesFile = "games.json";

        private void BackupFiles(out string? playersBackup, out string? gamesBackup)
        {
            playersBackup = File.Exists(PlayersFile) ? File.ReadAllText(PlayersFile) : null;
            gamesBackup = File.Exists(GamesFile) ? File.ReadAllText(GamesFile) : null;
        }

        private void RestoreFiles(string? playersBackup, string? gamesBackup)
        {
            if (playersBackup != null)
                File.WriteAllText(PlayersFile, playersBackup);
            else if (File.Exists(PlayersFile))
                File.Delete(PlayersFile);

            if (gamesBackup != null)
                File.WriteAllText(GamesFile, gamesBackup);
            else if (File.Exists(GamesFile))
                File.Delete(GamesFile);
        }

        [Fact]
        public void AddGame_AddsGameAndCanBeFound()
        {
            BackupFiles(out var playersBackup, out var gamesBackup);
            var lib = GameLibrary.Instance;
            try
            {
                int initialCount = lib.Games.Count;
                var game = new Game(TestGameId, "UTGame", "UTGenre");
                lib.AddGame(game);

                var found = lib.SearchGameById(TestGameId);
                Assert.NotNull(found);
                Assert.Equal("UTGame", found.Title);
                Assert.Equal(initialCount + 1, lib.Games.Count);
            }
            finally
            {
                // Remove in-memory entry
                lib.Games.RemoveAll(g => g.Id == TestGameId);
                RestoreFiles(playersBackup, gamesBackup);
            }
        }

        [Fact]
        public void RemovePlayerById_RemovesExistingPlayer()
        {
            BackupFiles(out var playersBackup, out var gamesBackup);
            var lib = GameLibrary.Instance;
            try
            {
                var player = new Player(TestPlayerId, "UTPlayer", "ut@local");
                lib.AddPlayer(player);

                bool removed = lib.RemovePlayerById(TestPlayerId);
                Assert.True(removed);
                Assert.Null(lib.SearchPlayerById(TestPlayerId));
            }
            finally
            {
                // Ensure in-memory cleanup and restore files
                lib.Players.RemoveAll(p => p.Id == TestPlayerId);
                RestoreFiles(playersBackup, gamesBackup);
            }
        }

        [Fact]
        public void SearchGameById_ReturnsNullForMissingAndGameForExisting()
        {
            BackupFiles(out var playersBackup, out var gamesBackup);
            var lib = GameLibrary.Instance;
            try
            {
                // Ensure missing returns null
                var missing = lib.SearchGameById(-1);
                Assert.Null(missing);

                var game = new Game(TestGameId, "SearchGame", "Genre");
                lib.AddGame(game);
                var found = lib.SearchGameById(TestGameId);
                Assert.NotNull(found);
                Assert.Equal("SearchGame", found.Title);
            }
            finally
            {
                lib.Games.RemoveAll(g => g.Id == TestGameId);
                RestoreFiles(playersBackup, gamesBackup);
            }
        }
    }
}
