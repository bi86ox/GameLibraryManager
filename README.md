# Game Library & Player Stats Manager

This is a small C# console application for managing a collection of games and player statistics. It supports adding/removing players, updating player stats, basic game management, and persisting data to JSON files.

## Features

- Add players and games
- Update player stats (hours played, high score)
- Search players and games by ID
- Sort players by high score
- Remove players by ID
- JSON persistence via `JsonDataPersistence`
- Simple logging to `application.log`

## Quickstart

Requirements: .NET 8 SDK or newer.

Clone, build, run:

```bash
git clone https://github.com/bi86ox/GameLibraryManager.git
cd GameLibraryManager
dotnet build
dotnet run
```

Run tests:

```bash
dotnet test
```

The console app shows a menu with options for players and games.

## Project Layout

- `Game.cs` — game model
- `Player.cs` — player model
- `PlayerStats.cs` — player statistics
- `GameLibrary.cs` — core manager (singleton)
- `PlayerFactory.cs` — creates players and manages IDs
- `IDataPersistence.cs`, `JsonDataPersistence.cs` — persistence layer (JSON)
- `Logger.cs` — simple logger
- `Program.cs` — CLI/menu
- `GameLibraryManagerTests/` — unit tests

## Recent Changes

- Added game-management features (`AddGame`, `SearchGameById`) and player removal (`RemovePlayerById`).
- Initialized `PlayerFactory` next ID from persisted data to avoid ID collisions.
- Added unit tests for `GameLibrary` (add/search/remove) and updated `.gitignore` to ignore `players.json`, `games.json`, and `application.log`.

## Notes & Recommendations

- Data files (`players.json`, `games.json`) and `application.log` are ignored by `.gitignore` by default.
- Consider adding more unit tests (edge cases, persistence failures) and input validation for the CLI.

## Contributing

Feel free to open a PR — I created `feature/tests-and-gitignore` with tests and `.gitignore` updates. You can also create issues for feature requests or bugs.

---
Thanks for checking this out — let me know if you want a GUI, API, or persistence to a database.
