using CardDungeon.Game.Cards;

namespace CardDungeon.Game
{
    public class Game
    {
        private int _level;
        private Player _player;
        private List<Card> _cards;

        private Random _rand;
        private bool _isRunning;
        public void Start()
        {
            Init();
            while (_isRunning)
            {
                Run();
            }
        }

        private void Init()
        {
            _level = 1;
            _player = new Player(16, 16, 5, 10);
            _cards = new List<Card>();
            _rand = new Random();
            _isRunning = true;

            RerollCards();
        }

        private void RerollCards()
        {
            _cards.Clear();

            for (int i = 0; i < 3; i++)
            {
                int rng = _rand.Next(4);

                if (rng == 0)
                {
                    _cards.Add(new GoldCard(_rand.Next(2, 4) * _level));
                }
                else if (rng == 1)
                {
                    _cards.Add(new HealthCard(_rand.Next(4, 8) * _level));
                }
                else if (rng == 2)
                {
                    _cards.Add(new AttackCard(_rand.Next(2, 4) * _level));
                }
                else if (rng == 3)
                {
                    int health = _rand.Next(8, 20) * _level;
                    _cards.Add(new MonsterCard(_rand.Next(4, 6) * _level, health, health / 2));
                }
            }

            // _cards.Add(new GoldCard(_rand.Next(1, 5)));
            // _cards.Add(new HealthCard(_rand.Next(1, 7)));
            // // _cards.Add(new AttackCard(_rand.Next(1, 3)));
            // _cards.Add(new MonsterCard(3, 15, 5));
        }

        private void Run()
        {
            Renderer.ClearScreen();

            Renderer.RenderGameLogs();
            Renderer.RenderPlayerStats(_level, _player.Health, _player.MaxHealth, _player.Attack, _player.Gold);

            if (_player.IsDead)
            {
                Environment.Exit(0);
            }

            Renderer.RenderPossibleCards(_cards);
            Renderer.RenderChooseCardPrompt();

            string input = Console.ReadLine();
            if (!int.TryParse(input, out int chosenCardIndex))
            {
                if (input.Equals("q"))
                {
                    Environment.Exit(0);
                }
                GameLog.Log($"Invalid input: {input}");
                return;
            }
            chosenCardIndex -= 1;
            if (chosenCardIndex < 0 || chosenCardIndex >= _cards.Count)
            {
                GameLog.Log($"Invalid card #: {chosenCardIndex + 1}");
                return;
            }

            var chosenCard = _cards[chosenCardIndex];

            if (IsChosenCardMonster(chosenCard))
            {
                _cards.RemoveAll(x => x != chosenCard);
            }

            if (UseCard(chosenCard))
            {
                _level++;
                RerollCards();
            }
        }

        private bool IsChosenCardMonster(Card chosenCard)
        {
            return chosenCard.GetType() == typeof(MonsterCard);
        }

        private bool UseCard(Card card)
        {
            return card.Use(_player);
        }
    }
}