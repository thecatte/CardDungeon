namespace CardDungeon.Game.Cards
{
    public class HealthCard : Card
    {
        public int Health { get; set; }
        private int Cost => Health;

        public HealthCard(int health) : base(ConsoleColor.Green)
        {
            this.Health = health;
        }

        public override bool Use(Player player)
        {
            if(player.Gold < Cost)
            {
                GameLog.Log("You don't have enough gold.");
                return false;
            }

            int playerHealthBefore = player.Health;
            player.Health = Math.Min(player.Health + Health, player.MaxHealth);
            player.Gold -= Health;

            GameLog.Log($"You heal for {player.Health - playerHealthBefore} and it costs {Health} gold.");
            return true;
        }

        public override string GetTitle()
        {
            return $"Health +{Health}";
        }
    }
}