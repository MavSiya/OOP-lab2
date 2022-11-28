using System;
using System.Collections.Generic;
using System.Text;

namespace Lab22
{
    public class DataPlayer
    {
        public int NumberOfGames { get; }
        public string Opponent { get; }
        public string Note { get; }
        public int Amount { get; }
        public string TypeGame { get; }


        public DataPlayer(int index, string oponnent, string note, int amount, string type)
        {
            NumberOfGames = index;
            Note = note;
            Opponent = oponnent;
            Amount = amount;
            TypeGame = type;
        }

    }
}
