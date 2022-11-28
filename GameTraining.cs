using System;

namespace Lab22
{
    class GameTraining : Game // Тренування для двох гравців
    {
        public GameTraining(GameAccount user1, GameAccount user2)
          : base(user1, user2)
        { }

        public override void Play()
        {
            Random rnd = new Random();
            int answer = rnd.Next(0, 2);
            int answUser1 = rnd.Next(0, 2);
            int answUser2 = 0;
            if (answUser1 == 0)
            {
                answUser2 = 1;
            }

            if (answUser2 == answer)
            {
                User2.WinGame(User1.UserName, this, this.ToString());
                User1.LoseGame(User2.UserName, this, this.ToString());

            }
            else if (answUser1 == answer)
            {
                User1.WinGame(User2.UserName, this, this.ToString());
                User2.LoseGame(User1.UserName, this, this.ToString());

            }
        }

    }
}
