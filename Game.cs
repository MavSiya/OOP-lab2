using System;
using System.Collections.Generic;
using System.Text;
using BoardLogic;

namespace Lab22
{
    
    public  abstract class Game
    {
        public static Board game = new Board();
        public int Rating { get; }
        public readonly GameAccount User1;
        public readonly GameAccount User2;
        
        public abstract void Play();
        public Game(GameAccount user1, GameAccount user2, int rating)
        {
            User1 = user1;
            User2 = user2;
            Rating = rating;
        }

        public Game(GameAccount user1, int rating)
        {
            User1 = user1;
            Rating = rating;
        }

        public Game(GameAccount user1, GameAccount user2)
        {
            User1 = user1;
            User2 = user2;
            Rating = 0;
        }

    }
}
