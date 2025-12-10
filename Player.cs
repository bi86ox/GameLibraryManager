using System;

namespace GameLibraryManager
{
    public class Player
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public PlayerStats Stats { get; set; }

        public Player(int id, string username, string email)
        {
            Id = id;
            Username = username;
            Email = email;
            Stats = new PlayerStats();
        }

        public override string ToString()
        {
            return $"ID: {Id}, Username: {Username}, Email: {Email}";
        }
    }
}
