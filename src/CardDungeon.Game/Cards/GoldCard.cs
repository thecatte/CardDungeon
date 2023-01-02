namespace CardDungeon.Game.Cards
{
    public class GoldCard : Card
    {
        public int Gold { get; set; }

        public GoldCard(int gold) : base(ConsoleColor.Yellow)
        {
            this.Gold = gold;
        }

        public override bool Use(Player player)
        {
            player.Gold += Gold;
            GameLog.Log($"You gain {Gold} gold.");
            return true;
        }

        public override string GetTitle()
        {
            return $"Gold +{Gold}";
        }
    }
}