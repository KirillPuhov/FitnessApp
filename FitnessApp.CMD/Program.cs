using FitnessApp.BL.Controller;
using FitnessApp.BL.Model;
using System;
using System.Globalization;
using System.Resources;

namespace FitnessApp.CMD
{
    class Program
    {
        private static CultureInfo culture = CultureInfo.CreateSpecificCulture("ru-ru");
        private static ResourceManager resourceManager = new ResourceManager("FitnessApp.CMD.Languages.Messages", typeof(Program).Assembly);

        static void Main(string[] args)
        {
            Console.WriteLine(resourceManager.GetString("Greeting", culture));

            Console.WriteLine(resourceManager.GetString("EnterName", culture));
            var name = Console.ReadLine();

            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.WriteLine(resourceManager.GetString("EnterGender", culture));
                var gender = Console.ReadLine();
                var birthDate = ParseDateTime("дату рождения(dd.MM.yyyy):");
                var weight = ParseDouble(resourceManager.GetString("Weight", culture));
                var height = ParseDouble(resourceManager.GetString("Height", culture));

                userController.SetNewUserData(gender, birthDate, weight, height);
            }


            Console.WriteLine(userController.CurrentUser);

            while(true)
            {
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("E - ввести приём пищи");
                Console.WriteLine("A - ввести упражнение");
                Console.WriteLine("B - посмотреть выполненные упражнения");
                Console.WriteLine("D - посмотреть все приёмы пищи");
                Console.WriteLine("Q - выход");
                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);
                        break;
                    case ConsoleKey.A:
                        var exe = EnterExercise();
                        exerciseController.Add(exe.Activity, exe.Begin, exe.End);
                        break;
                    case ConsoleKey.B:
                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity} c {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()}");
                        }
                        break;
                    case ConsoleKey.D:
                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{item.Key.Name} - {item.Value}");
                        }
                        break;
                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }
                Console.ReadLine();
            }
        }

        private static (DateTime Begin, DateTime End, Activity Activity) EnterExercise()
        {
            Console.WriteLine("Введите название упражнения: ");
            var name = Console.ReadLine();

            var energy = ParseDouble("расход энергии в минуту");

            var begin = ParseDateTime("начало упражнения (dd.MM.yyyy hh:mm)");
            var end = ParseDateTime("окончание упражнения (dd.MM.yyyy hh:mm)");

            Console.ReadLine();
            var activity = new Activity(name, energy);
            return (begin, end, activity);
        }

        private static (Food Food, double Weight) EnterEating()

        {
            Console.WriteLine(resourceManager.GetString("EnterProductName", culture));
            var food = Console.ReadLine();

            var prots = ParseDouble(resourceManager.GetString("Prots", culture));
            var fats = ParseDouble(resourceManager.GetString("Fats", culture));
            var сarbs = ParseDouble(resourceManager.GetString("Carbs", culture));
            var сals = ParseDouble(resourceManager.GetString("Cals", culture));

            var weight = ParseDouble(resourceManager.GetString("WeightAPortion", culture));
            var product = new Food(food, prots, fats, сarbs, сals);

            return (Food: product, Weight : weight);
        }

        private static DateTime ParseDateTime(string value)
        {
            DateTime birthDate;
            while (true)
            {
                Console.WriteLine(resourceManager.GetString("Enter", culture) + $" { value }");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine(resourceManager.GetString("NoFormat", culture) + $" { value }");
                }
            }

            return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.WriteLine(resourceManager.GetString("Enter", culture) + $" { name }");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine(resourceManager.GetString("NoFormat", culture) + $" { name }");
                }
            }
        }
    }
}
