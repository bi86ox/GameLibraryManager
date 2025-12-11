using System;

namespace GameLibraryManager
{
    class Program
    {
        static void Main(string[] args)
        {
            var library = GameLibrary.Instance;

            while (true)
            {
                Console.WriteLine("\nGame Library & Player Stats Manager");
                Console.WriteLine("1. Add Player");
                Console.WriteLine("2. Update Player Stats");
                Console.WriteLine("3. Search Player by ID");
                Console.WriteLine("4. Sort Players by High Score");
                Console.WriteLine("5. Display All Players");
                Console.WriteLine("6. Add Game");
                Console.WriteLine("7. Display All Games");
                Console.WriteLine("8. Search Game by ID");
                Console.WriteLine("9. Remove Player by ID");
                Console.WriteLine("10. Exit");
                Console.Write("Choose an option: ");

                string? input = Console.ReadLine();
                if (input == null) 
                {
                    Console.WriteLine("Invalid input. Try again.");
                    continue;
                }
                string choice = input;

                switch (choice)
                {
                    case "1":
                        AddPlayer(library);
                        break;
                    case "2":
                        UpdatePlayerStats(library);
                        break;
                    case "3":
                        SearchPlayer(library);
                        break;
                    case "4":
                        SortPlayers(library);
                        break;
                    case "5":
                        DisplayAllPlayers(library);
                        break;
                    case "6":
                        AddGame(library);
                        break;
                    case "7":
                        DisplayAllGames(library);
                        break;
                    case "8":
                        SearchGame(library);
                        break;
                    case "9":
                        RemovePlayer(library);
                        break;
                    case "10":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
            }
        }

        static void AddPlayer(GameLibrary library)
        {
            Console.Write("Enter username: ");
            string? username = Console.ReadLine();
            Console.Write("Enter email: ");
            string? email = Console.ReadLine();

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(email))
            {
                var player = PlayerFactory.CreatePlayer(username, email);
                library.AddPlayer(player);
                Console.WriteLine("Player added successfully.");
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }

        static void UpdatePlayerStats(GameLibrary library)
        {
            Console.Write("Enter player ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Console.Write("Enter hours played: ");
                if (int.TryParse(Console.ReadLine(), out int hours))
                {
                    Console.Write("Enter score: ");
                    if (int.TryParse(Console.ReadLine(), out int score))
                    {
                        library.UpdatePlayerStats(id, hours, score);
                        Console.WriteLine("Stats updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid score.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid hours.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }

        static void AddGame(GameLibrary library)
        {
            Console.Write("Enter game title: ");
            string? title = Console.ReadLine();
            Console.Write("Enter genre: ");
            string? genre = Console.ReadLine();

            if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(genre))
            {
                int nextId = 1;
                if (library.Games != null && library.Games.Count > 0)
                    nextId = library.Games.Max(g => g.Id) + 1;

                var game = new Game(nextId, title, genre);
                library.AddGame(game);
                Console.WriteLine("Game added successfully.");
            }
            else
            {
                Console.WriteLine("Invalid input.");
            }
        }

        static void DisplayAllGames(GameLibrary library)
        {
            foreach (var game in library.Games)
            {
                Console.WriteLine(game);
            }
        }

        static void SearchGame(GameLibrary library)
        {
            Console.Write("Enter game ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var game = library.SearchGameById(id);
                if (game != null)
                {
                    Console.WriteLine(game);
                }
                else
                {
                    Console.WriteLine("Game not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }

        static void RemovePlayer(GameLibrary library)
        {
            Console.Write("Enter player ID to remove: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                if (library.RemovePlayerById(id))
                {
                    Console.WriteLine("Player removed successfully.");
                }
                else
                {
                    Console.WriteLine("Player not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }

        static void SearchPlayer(GameLibrary library)
        {
            Console.Write("Enter player ID: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var player = library.SearchPlayerById(id);
                if (player != null)
                {
                    Console.WriteLine(player);
                    Console.WriteLine(player.Stats);
                }
                else
                {
                    Console.WriteLine("Player not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid ID.");
            }
        }

        static void SortPlayers(GameLibrary library)
        {
            var sorted = library.SortPlayersByHighScore();
            Console.WriteLine("Players sorted by high score:");
            foreach (var player in sorted)
            {
                Console.WriteLine($"{player.Username}: {player.Stats.HighScore}");
            }
        }

        static void DisplayAllPlayers(GameLibrary library)
        {
            foreach (var player in library.Players)
            {
                Console.WriteLine(player);
                Console.WriteLine(player.Stats);
                Console.WriteLine();
            }
        }
    }
}