using System;

namespace Lab22
{
    class GameAccountLucky : GameAccount // Створюю акаунт, у якому при перемозі рейтинг подвоюється. Клас є дочірнім від GameAccount
    {
        public GameAccountLucky() { }
        public GameAccountLucky(string userName)
                : base(userName)
        { }

        public override void WinGame(string oponnent, Game game, string type)
        {

            if (game.Rating < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(game.Rating), "Rating must be positive");
            }
            var winGame = new DataPlayer(1, oponnent, "Win", game.Rating * 2, type);
            dataPlayer.Add(winGame);
        }

    }
}
