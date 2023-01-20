using System;

namespace Lab22
{
    class Program
    {
        static void Main(string[] args)
        {
            var user1 = new GameAccount("Ivan", 0);
            var user2 = new GameAccountUnlucky("Leva", 0);
            var user3 = new GameAccountLucky("Anna", 0);
            var user4 = new GameAccount("Cris", 0);

            var gameTrain = GameFactory.GetGameTraining(user4, user1);
            var gameBase = GameFactory.GetGameBase(user2, user3, 2);
            var game = GameFactory.GetGameVsCPU(user1, 2); //

            string[] menuItems = new string[] { "Base game against a player with a rating", "Game against the computer", "Training game against the player", "Show rating", "Clean console", "Exit" };

            Console.WriteLine("Меню");
            Console.WriteLine();

            int row = Console.CursorTop;
            int col = Console.CursorLeft;
            int index = 0;
            while (true)
            {
                DrawMenu(menuItems, row, col, index);
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.DownArrow:
                        if (index < menuItems.Length - 1)
                            index++;
                        break;
                    case ConsoleKey.UpArrow:
                        if (index > 0)
                            index--;
                        break;
                    case ConsoleKey.Enter:
                        switch (index)
                        {
                            case 0:
                                gameBase.Play();
                                break;
                            case 1:
                                game.Play();
                                break;
                            case 2:
                                gameTrain.Play();
                                break;
                            case 4:
                                Console.Clear();
                                break;
                            case 3:
                                Console.WriteLine(user1.GetStats());
                                Console.WriteLine(user2.GetStats());
                                Console.WriteLine(user3.GetStats());
                                Console.WriteLine(user4.GetStats());
                                break;
                            case 5:
                                Console.WriteLine("Выбран выход из приложения");
                                return;
                        }

                        break;
                }
            }

        }
        private static void DrawMenu(string[] items, int row, int col, int index)
        {
            Console.SetCursorPosition(col, row);
            for (int i = 0; i < items.Length; i++)
            {
                if (i == index)
                {
                    Console.BackgroundColor = Console.ForegroundColor;
                    Console.ForegroundColor = ConsoleColor.Black;
                }
                Console.WriteLine(items[i]);
                Console.ResetColor();
            }
            Console.WriteLine();
        }
    }

}
