using System;

namespace Lab22
{
    class GameAccountUnlucky : GameAccount // Створюю акаунт, у якому при поразці рейтинг знімається в двічі більше. Клас є дочірнім від GameAccount
    {

        public GameAccountUnlucky() { }
        public GameAccountUnlucky(string userName, int userTurn)
                : base(userName, userTurn)
        { }

        public override void LoseGame(string oponnent, Game game, string type)
        {

            if (game.Rating < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(game.Rating), "Rating must be positive");
            }
            if (SumRating - game.Rating < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(game.Rating), "Rating must be positive");
            }

            var loseGame = new DataPlayer(1, oponnent, "Lose", -(game.Rating * 2), type);
            dataPlayer.Add(loseGame);
        }



    }
}