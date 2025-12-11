using Xunit;
using GameLibraryManager;

namespace GameLibraryManagerTests;

public class PlayerTests
{
    [Fact]
    public void Player_Constructor_InitializesPropertiesCorrectly()
    {
        // Arrange
        int expectedId = 1;
        string expectedUsername = "TestPlayer";
        string expectedEmail = "test@example.com";

        // Act
        var player = new Player(expectedId, expectedUsername, expectedEmail);

        // Assert
        Assert.Equal(expectedId, player.Id);
        Assert.Equal(expectedUsername, player.Username);
        Assert.Equal(expectedEmail, player.Email);
        Assert.NotNull(player.Stats);
    }

    [Fact]
    public void Player_ToString_ReturnsFormattedString()
    {
        // Arrange
        var player = new Player(1, "TestPlayer", "test@example.com");

        // Act
        var result = player.ToString();

        // Assert
        Assert.Contains("ID: 1", result);
        Assert.Contains("Username: TestPlayer", result);
        Assert.Contains("Email: test@example.com", result);
    }
}
