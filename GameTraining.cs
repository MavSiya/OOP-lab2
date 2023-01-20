using System;
using BoardLogic;

namespace Lab22
{
    class GameTraining : Game // Тренування для двох гравців
    {
        
        public GameTraining(GameAccount user1, GameAccount user2)
          : base(user1, user2)
        { }

        public override void Play()
        {
            Console.Clear();
            User1.UserTurn = -1;
            User2.UserTurn = -1;
           

            while (game.chekForWinner() == 0)
            {
                //get the valid input from the user
                while (User1.UserTurn == -1 || game.Grid[User1.UserTurn] != 0)
                {
                    Console.WriteLine("Please " + User1.UserName + " a number from 0 to 8");
                    User1.UserTurn = int.Parse(Console.ReadLine());
                    if (game.Grid[User1.UserTurn] != 0)
                    {
                        Console.WriteLine("The place is taken, please enter another number");
                    }
                   else
                    {
                        Console.WriteLine(User1.UserName + " typed " + User1.UserTurn);
                    }
                }
                game.Grid[User1.UserTurn] = 1;

                if (game.isBoardFull())
                    break;
                if (game.chekForWinner() == 1 || game.chekForWinner() == 2)
                    break;
                printBoard();
                //get a random move from the computer
                while (User2.UserTurn == -1 || game.Grid[User2.UserTurn] != 0)
                {
                    Console.WriteLine("Please " + User2.UserName + " enter a number from 0 to 8");
                    User2.UserTurn = int.Parse(Console.ReadLine());
                    if (game.Grid[User2.UserTurn] != 0)
                    {
                        Console.WriteLine("The place is taken, please enter another number");
                    }
                    else
                    {
                        Console.WriteLine(User2.UserName + " typed " + User2.UserTurn);
                    }
                }
                game.Grid[User2.UserTurn] = 2;
               
                if (game.isBoardFull())
                    break;
                if (game.chekForWinner() == 1 || game.chekForWinner() == 2)
                    break;
                printBoard();
            }

            if (game.chekForWinner() == 1)
            {
                User2.LoseGame(User1.UserName, this, this.ToString());
                User1.WinGame(User2.UserName, this, this.ToString());
                Console.Clear();
                Console.WriteLine("The game is over. Player " + User1.UserName + " won the game");
                game.uploadBoard();
                User1.UserTurn = -1;
                User2.UserTurn = -1;
            }
            else if (game.chekForWinner() == 2)
            {
                User2.WinGame(User1.UserName, this, this.ToString());
                User1.LoseGame(User2.UserName, this, this.ToString());
                Console.Clear();
                Console.WriteLine("The game is over. Player " + User2.UserName + " won the game");
                game.uploadBoard();
                User1.UserTurn = -1;
                User2.UserTurn = -1;
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
