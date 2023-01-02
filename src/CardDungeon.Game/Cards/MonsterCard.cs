namespace CardDungeon.Game.Cards
{
    public class MonsterCard : Card
    {
        public int Attack { get; set; }
        public int Health { get; set; }
        public int MaxHealth { get; set; }
        public int GoldReward { get; set; }

        public MonsterCard(int attack, int health, int goldReward) : base(ConsoleColor.Red)
        {
            this.Attack = attack;
            this.Health = health;
            this.MaxHealth = health;
            this.GoldReward = goldReward;
        }

        public override string GetTitle()
        {
            return $"Monster ATK:{Attack} HP:{Health}/{MaxHealth} Reward: {GoldReward}";
        }

        public override bool Use(Player player)
        {
            Health -= player.Attack;

            if (Health <= 0)
            {
                player.Gold += GoldReward;
                GameLog.Log($"You attack the creature for {player.Attack} and defeat it. You gain {GoldReward} gold as reward.");

                return true;
            }

            player.Health -= Attack;
            GameLog.Log($"You attack the creature for {player.Attack}. You lose {Attack} health.{(player.IsDead ? " You are dead." : "")}");

            return false;
        }
    }
}