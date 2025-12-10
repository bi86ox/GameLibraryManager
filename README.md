# Game Library & Player Stats Manager

This is a C# console application that allows users to manage a collection of games and track player statistics. The application provides functionality to add, update, search, and sort players, as well as manage game data.

## Features

- Add, update, and remove players
- Search players by name or stats
- Sort players by various criteria
- Persistent data storage using JSON
- Logging of operations

## Setup Instructions

1. **Prerequisites**:
   - .NET 8.0 or later
   - Visual Studio 2022 or .NET CLI

2. **Clone the Repository**:
   ```
   git clone https://github.com/bi86ox/GameLibraryManager.git
   cd GameLibraryManager
   ```

3. **Build the Project**:
   ```
   dotnet build
   ```

4. **Run the Application**:
   ```
   dotnet run
   ```

5. **Run Tests**:
   ```
   cd ../GameLibraryManagerTests
   dotnet test
   ```

## Design Choices

- **Singleton Pattern**: Used for the GameLibrary class to ensure a single instance manages the game data.
- **Factory Pattern**: PlayerFactory creates Player objects based on input.
- **Data Persistence**: JSON files for storing games and players data.
- **Logging**: Custom Logger class for recording operations.
- **Search and Sort Algorithms**: Linear search for players, custom sort for stats.

## Project Structure

- `Game.cs`: Represents a game entity.
- `Player.cs`: Represents a player entity.
- `PlayerStats.cs`: Handles player statistics.
- `GameLibrary.cs`: Manages the collection of games and players.
- `PlayerFactory.cs`: Creates player instances.
- `IDataPersistence.cs`: Interface for data persistence.
- `JsonDataPersistence.cs`: JSON implementation of data persistence.
- `Logger.cs`: Logging utility.
- `Program.cs`: Main entry point with menu-driven interface.

## Contributing

Feel free to fork the repository and submit pull requests for improvements.

## License

This project is for educational purposes.
