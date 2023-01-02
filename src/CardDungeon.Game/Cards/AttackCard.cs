namespace CardDungeon.Game.Cards
{
    public class AttackCard : Card
    {
        public int Attack { get; set; }
        private int Cost => Attack;

        public AttackCard(int attack) : base(ConsoleColor.Blue)
        {
            this.Attack = attack;
        }

        public override bool Use(Player player)
        {
            if (player.Gold < Cost)
            {
                GameLog.Log("You don't have enough gold.");
                return false;
            }
            player.Attack += Attack;
            player.Gold -= Cost;
            GameLog.Log($"You gain {Attack} attack for {Cost} gold.");
            return true;
        }

        public override string GetTitle()
        {
            return $"Attack +{Attack}";
        }
    }
}