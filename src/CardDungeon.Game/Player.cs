namespace CardDungeon.Game
{
    public class Player
    {
        public int Health { get; set; }
        public int MaxHealth { get; set; }

        public int Attack { get; set; }

        public int Gold { get; set; }
        public bool IsDead => Health <= 0;

        public Player(int health, int maxHealth, int attack, int gold)
        {
            this.Health = health;
            this.MaxHealth = maxHealth;
            this.Attack = attack;
            this.Gold = gold;
        }
    }
}