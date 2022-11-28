using System;

namespace Lab22
{
    class Program
    {
        static void Main(string[] args)
        {
            var user1 = new GameAccount("Ivan");
            var user2 = new GameAccountLucky("Nastya");
            var user3 = new GameAccountUnlucky("Den");

            var game = GameFactory.GetGameSingle(user1, 2); //
            game.Play();
            game.Play();
            game.Play();

            var gameTrain = GameFactory.GetGameTraining(user2, user3);
            gameTrain.Play();
            gameTrain.Play();
            gameTrain.Play();

            var gameBase = GameFactory.GetGameBase(user2, user3, 2);
            gameBase.Play();
            gameBase.Play();
            gameBase.Play();

            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine(user1.GetStats());
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine(user3.GetStats());
            Console.WriteLine("------------------------------------------------------------------------");
            Console.WriteLine(user2.GetStats());

        }
    }
}
