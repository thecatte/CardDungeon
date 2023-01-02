namespace CardDungeon.Game
{
    public static class GameLog
    {
        private static List<string> Logs { get; set; }

        static GameLog()
        {
            Logs = new List<string>();
        }

        public static void Log(string logEntry)
        {
            Logs.Add(logEntry);
        }

        public static List<string> GetLatestLogs()
        {
            return Logs.TakeLast(3).ToList();
        }
    }
}