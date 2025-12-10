# Game Library & Player Stats Manager

Hey there! This is my C# console app for keeping track of games and player stats. It's a simple way to add players, update their progress, search for them, and sort by different stats. I built it as a fun project to practice some design patterns and .NET basics.

## What It Does

- Add new players, tweak their info, or remove them if needed
- Search for players by name or dive into their stats
- Sort the list however you like – by wins, playtime, whatever
- Saves everything to JSON files so your data sticks around
- Logs what you're doing, just in case you want to review

## How to Get It Running

You'll need .NET 8 or newer – grab it from the official site if you don't have it. Visual Studio works great, but the CLI is fine too.

1. Clone this repo:
   ```
   git clone https://github.com/bi86ox/GameLibraryManager.git
   cd GameLibraryManager
   ```

2. Build it:
   ```
   dotnet build
   ```

3. Fire it up:
   ```
   dotnet run
   ```

4. To run the tests (there are a few unit tests to check things like adding players and sorting):
   ```
   dotnet test
   ```

That's it! The menu in the console will guide you from there.

## Why I Did It This Way

I wanted to experiment with some patterns:
- **Singleton for GameLibrary**: Keeps one central spot for all the game and player data – no duplicates messing things up.
- **Factory for Players**: PlayerFactory handles creating players based on what you input, makes it flexible.
- **JSON for Storage**: Easy to read/write, and no fancy database needed for a console app.
- **Custom Logger**: Just a simple class to jot down actions – helpful for debugging.
- **Searches and Sorts**: Stuck with linear search for simplicity (it's small-scale), and a custom sort for stats to keep it efficient.

## What's Inside

- `Game.cs`: Basic game info.
- `Player.cs`: The player model.
- `PlayerStats.cs`: Tracks wins, losses, etc.
- `GameLibrary.cs`: The boss – manages everything.
- `PlayerFactory.cs`: Builds players on the fly.
- `IDataPersistence.cs` & `JsonDataPersistence.cs`: For saving/loading data.
- `Logger.cs`: Logs your moves.
- `Program.cs`: The main loop with the menu.

There's also a test project with some basics covered, like testing adds, updates, and file I/O.

## Contributing or Ideas?

If you spot something cool or want to add features (maybe a GUI?), fork it and send a PR. I'd love to see what you come up with!

## License

Just for learning – no restrictions, use it however for your own projects.
