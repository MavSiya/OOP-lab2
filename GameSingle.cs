using System;
using System.Collections.Generic;
using System.Text;

namespace Lab22
{
    public class GameSingle : Game // Гра для одного на рейтинг
    {
       
        public GameSingle(GameAccount user1, int rating)
            : base(user1, rating)
        {
        }

        public override void Play()
        {
            Random rnd = new Random();
            int answer = rnd.Next(0, 2);
            int answUser1 = rnd.Next(0, 2);

            if (answUser1 == answer)
            {
                User1.WinGame(User1.UserName, this, this.ToString());
                
            }
            else
            {
                User1.LoseGame(User1.UserName, this, this.ToString());

            }
        }

    }
}
