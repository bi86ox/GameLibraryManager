using System;

namespace GameLibraryManager
{
    public static class PlayerFactory
    {
        private static int _nextId = 1;

        public static Player CreatePlayer(string username, string email)
        {
            var player = new Player(_nextId++, username, email);
            return player;
        }

        public static void Initialize(int startId)
        {
            if (startId > 0)
            {
                _nextId = startId;
            }
        }
    }
}
