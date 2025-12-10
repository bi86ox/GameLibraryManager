using System;

namespace GameLibraryManager
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }

        public Game(int id, string title, string genre)
        {
            Id = id;
            Title = title;
            Genre = genre;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Title: {Title}, Genre: {Genre}";
        }
    }
}
