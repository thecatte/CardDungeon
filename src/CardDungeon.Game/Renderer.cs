using CardDungeon.Game.Cards;

namespace CardDungeon.Game
{
    public static class Renderer
    {
        public static void RenderLine(string text = "", ConsoleColor textColor = ConsoleColor.White)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = textColor;
            System.Console.WriteLine(text);
            Console.ForegroundColor = color;
        }

        public static void RenderPlayerStats(int level, int health, int maxHealth, int attack, int gold)
        {
            Console.WriteLine($"LEVEL: {level}");
            Console.WriteLine($"HP:  {health}/{maxHealth} ATK: {attack} GLD: {gold}");
        }

        public static void RenderPossibleCards(List<Card> cards)
        {
            var color = Console.ForegroundColor;
            for (int i = 0; i < cards.Count; i++)
            {
                Console.ForegroundColor = cards[i].Color;
                Console.WriteLine($"{i + 1}) {cards[i].GetTitle()}");
            }
            Console.ForegroundColor = color;
        }

        public static void RenderChooseCardPrompt()
        {
            Console.WriteLine("Choose card:");
        }

        public static void ClearScreen()
        {
            Console.Clear();
        }

        public static void RenderGameLogs()
        {
            var logs = GameLog.GetLatestLogs();

            if(logs.Count > 0)
            {
                RenderLine(string.Join('\n', logs) + Environment.NewLine, ConsoleColor.Gray);
            }
        }
    }
}