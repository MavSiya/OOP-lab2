using System;
using System.Collections.Generic;
using System.Text;

namespace Lab22
{
    class GameFactory // створюю клас у якому буде знаходитись метод створення певного виду гри.
                      // Можна було створити окрім классу GameFactory, ще три методи дочірних "фабрик" для кожної гри, але використаний метод здався більш лаконічним
    {
        public static Game GetGameBase(GameAccount user1, GameAccount user2, int rating) //Створюю метод типу классу Game, який повертає створений об'єкт потрібної гри
        {
            return new GameBase(user1, user2, rating);
        }

        public static Game GetGameSingle(GameAccount user1, int rating)
        {
            return new GameSingle(user1, rating);
        }

        public static Game GetGameTraining(GameAccount user1, GameAccount user2)
        {
            return new GameTraining(user1, user2);
        }
    }
}
