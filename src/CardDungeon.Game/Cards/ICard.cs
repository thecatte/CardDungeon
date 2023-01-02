namespace CardDungeon.Game.Cards
{
    public interface ICard
    {
        bool Use(Player player);
        string GetTitle();
    }
}