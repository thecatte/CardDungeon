namespace CardDungeon.Game.Cards
{
    public abstract class Card : ICard
    {
        public abstract string GetTitle();
        public abstract bool Use(Player player);
        public ConsoleColor Color { get; set; }

        public Card(ConsoleColor color)
        {
            this.Color = color;
        }
    }
}