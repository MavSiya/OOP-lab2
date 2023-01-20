using System;
using System.Collections.Generic;
using System.Text;
using BoardLogic;

namespace Lab22
{
    public class GameVsCPU : Game // Гра для одного на рейтинг
    {
        

        public GameVsCPU(GameAccount user1, int rating)
            : base(user1, rating)
        {
        }


        public override void Play()
        {
            Console.Clear();
            User1.UserTurn = -1;

            Random random = new Random();
            int computerTurn = -1;

            while (game.chekForWinner() == 0)
            {
                //get the valid input from the user
                while (User1.UserTurn == -1 || game.Grid[User1.UserTurn] != 0)
                {
                    Console.WriteLine("Please enter a number from 0 to 8");
                    User1.UserTurn = int.Parse(Console.ReadLine());
                    if (game.Grid[User1.UserTurn] != 0)
                    {
                        Console.WriteLine("The place is taken, please enter another number");
                    }
                    else
                    {
                        Console.WriteLine("You typed " + User1.UserTurn);
                    }
                }
                game.Grid[User1.UserTurn] = 1;
                if (game.isBoardFull())
                    break;
                if (game.chekForWinner() == 1 || game.chekForWinner() == 2)
                    break;
                //get a random move from the computer
                while (computerTurn == -1 || game.Grid[computerTurn] != 0)
                {
                    computerTurn = random.Next(9);
                }
                game.Grid[computerTurn] = 2;

                if (game.isBoardFull())
                    break;
                printBoard();
            }


            if (game.chekForWinner() == 1)
            {
                User1.WinGame("Computer", this, this.ToString());
                Console.Clear();
                Console.WriteLine("The game is over. Player " + User1.UserName + " won the game");
                User1.UserTurn = -1;

                game.uploadBoard();

            }
            else if (game.chekForWinner() == 2)
            {
                User1.LoseGame("Computer", this, this.ToString());
                Console.Clear();
                Console.WriteLine("The game is over. Computer won the game");
                User1.UserTurn = -1;

                game.uploadBoard();


            }

        }


        private static void printBoard()
        {

            for (int i = 0; i < 9; i++)
            {
                // Console.WriteLine("Squre " + i + " contains " + board[i]);
                if (game.Grid[i] == 0)
                {
                    Console.Write("| - |");
                }
                if (game.Grid[i] == 1)
                {
                    Console.Write("| X |");
                }
                if (game.Grid[i] == 2)
                {
                    Console.Write("| O |");
                }
                if (i == 2 || i == 5 || i == 8)
                {
                    Console.WriteLine();
                }
            }
        }


    }
}
