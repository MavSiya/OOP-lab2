using System;
using System.Collections.Generic;

namespace Lab22
{
    public class GameAccount // батьківський акаунт для інших видів акаунтів   
    {

        public string UserName { get; }
        public int UserTurn { get; set; }
        public GameAccount() { }
        public GameAccount(string UserName, int UserTurn)
        {
            this.UserName = UserName;
            this.UserTurn = UserTurn;
        }

        public int GamesCount //Метод допомагає порахувати кількість зіграних ігор на цьому аккаунті
        {
            get
            {
                int index = 0;
                foreach (var item in dataPlayer)
                {
                    index += item.NumberOfGames;
                }
                return index;
            }
        }



        public virtual int SumRating 
        {
            get
            {
                int rating = 20;
                foreach (var item in dataPlayer)
                {

                    rating += item.Amount;

                }

                return rating;
            }
        }



        protected List<DataPlayer> dataPlayer = new List<DataPlayer>(); // Список у якому зберігається вся історія ігор на акаунті

        public virtual void WinGame(string oponnent, Game game, string type) // Метод на випадок якщо гравець виграв. У нього передаю ім'я опонента, об'єкт гри й тип гри
        {
            if (game.Rating < 0)                                             // Рейтинг передаю за допомогою об'єкту базової гри,де є метод для визначення потрібного рейтингу
            {
                throw new ArgumentOutOfRangeException(nameof(game.Rating), "Rating must be positive");
            }
            var winGame = new DataPlayer(1, oponnent, "Win", game.Rating, type);
            dataPlayer.Add(winGame);
        }

        public virtual void LoseGame(string oponnent, Game game, string type)
        {
            if (game.Rating < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(game.Rating), "Rating must be positive");
            }
            if (SumRating - game.Rating < 0)
            {
                throw new InvalidOperationException("Rating must be positive");
            }
            var loseGame = new DataPlayer(1, oponnent, "Lose", -game.Rating, type);
            dataPlayer.Add(loseGame);
        }

        public virtual string GetStats()
        {
            var report = new System.Text.StringBuilder();

            int sumRating = 20;
            int index = 0;
            report.AppendLine("#\tName\tOpponent\tRating\t\tNote\t\tAmount\t\tType Game");
            foreach (var item in dataPlayer)
            {
                sumRating += item.Amount;
                index += item.NumberOfGames;
                report.AppendLine($"{index}\t{UserName}\t{item.Opponent}\t\t{sumRating}\t\t{item.Note}\t\t{item.Amount}\t\t{item.TypeGame}");
            }
            return report.ToString();
        }
    }
}
