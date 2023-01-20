﻿using System;
using System.Collections.Generic;
using System.Text;
using BoardLogic;

namespace Lab22
{
    public class GameBase : Game // Базова гра, якак є дочірнею від класу Game
    {
        
        public GameBase(GameAccount user1, GameAccount user2, int rating)
           : base(user1, user2, rating)
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
                printBoard();
                if (game.isBoardFull())
                    break;
                if (game.chekForWinner() == 1 || game.chekForWinner() == 2)
                    break;
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
                printBoard();
                if (game.isBoardFull())
                    break;
                if (game.chekForWinner() == 1 || game.chekForWinner() == 2)
                    break;
            }


            if (game.chekForWinner() == 2)
            {
                User2.WinGame(User1.UserName, this, this.ToString());
                User1.LoseGame(User2.UserName, this, this.ToString());
                Console.Clear();
                Console.WriteLine("The game is over. Player " + User2.UserName + " won the game");
                User1.UserTurn = -1;
                User2.UserTurn = -1;
                game.uploadBoard();
            }
            else if (game.chekForWinner() == 1)
            {
                User2.LoseGame(User1.UserName, this, this.ToString());
                User1.WinGame(User2.UserName, this, this.ToString());
                Console.Clear();
                Console.WriteLine("The game is over. Player " + User1.UserName + " won the game");
                User1.UserTurn = -1;
                User2.UserTurn = -1;
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
