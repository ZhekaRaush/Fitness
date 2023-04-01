using Fitness.BL.Controller;
using Fitness.BL.Model;
using System;

namespace Fitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            Console.WriteLine("\n\n");
            Console.WriteLine("\t\t\tВас приветствует приложение \"Fitness\"");
            Console.WriteLine("\n\n");
            Console.Write("  Имя пользователя: ");
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.Write("  Какого вы пола: ");
                var gender = Console.ReadLine();
                var birthDate = ParseDataTime();
                var weight = ParseDouble("вес");
                var height = ParseDouble("рост");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);


            Console.WriteLine("  Что вы хотите сделать?");
            Console.WriteLine("  E - ввести прием пищи");
            var key = Console.ReadKey();

            if (key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);

                foreach(var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t {item.Key} - {item.Value}");
                }
            }

            Console.ReadLine();
        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.Write("  Название продукта: ");
            var food = Console.ReadLine();

            var calories = ParseDouble("калорийность");
            var prots = ParseDouble("белки");
            var fats = ParseDouble("жиры");
            var carbs = ParseDouble("углеводы");

            var weight = ParseDouble("вес порции");
            var product = new Food(food, calories, prots, fats, carbs);

            return (Food: product, Weight: weight);
        }

        private static DateTime ParseDataTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write("  Дата рождения (дд.мм.гггг): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("  Формат даты должен быть дд.мм.гггг");
                }
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"  Введите {name}: ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"  Неверный формат {name}");
                }
            }
        }
    }
}
