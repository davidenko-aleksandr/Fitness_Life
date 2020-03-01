using Fitness_Life.BL.Controller;
using Fitness_Life.BL.Model;
using System;
using System.Globalization;
using System.Resources;


namespace Fitness_Life.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("en-us");
            var resourceManager = new ResourceManager("Fitness_Life.CMD.Languages.Messages", typeof(Program).Assembly);
            Console.WriteLine(resourceManager.GetString("Hello", culture));
            Console.WriteLine(resourceManager.GetString("EnterName", culture));
            var name = Console.ReadLine();            
            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.Write(resourceManager.GetString("EnterGender", culture));
                var gender = Console.ReadLine();
                var birthDate = ParceDateTime(resourceManager.GetString("EnterBirthdate", culture));
                var weight = ParceDouble(resourceManager.GetString("EnterWeight", culture));
                var height = ParceDouble(resourceManager.GetString("EnterHeight", culture));
                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);

            while (true)
            {
                Console.WriteLine(resourceManager.GetString("WhatToDo", culture));
                Console.WriteLine(resourceManager.GetString("AddFood", culture));
                Console.WriteLine(resourceManager.GetString("AddExercise", culture));
                Console.WriteLine(resourceManager.GetString("Exit", culture));
                Console.WriteLine();
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.D:
                        var foods = EnterEating();
                        eatingController.Add(foods.Food, foods.Weight);
                        foreach (var item in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"{item.Key} - {item.Value}");
                        }
                        break;
                    case ConsoleKey.L:
                        var exe = EnterExercise();
                        exerciseController.Add(exe.Activity, exe.Begin,  exe.End);
                        foreach(var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"{item.Activity} c {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()}");
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
            var culture = CultureInfo.CreateSpecificCulture("en-us");
            var resourceManager = new ResourceManager("Fitness_Life.CMD.Languages.Messages", typeof(Program).Assembly);
            Console.WriteLine(resourceManager.GetString("ExerciseName", culture));
            var name = Console.ReadLine();
            var energy = ParceDouble(resourceManager.GetString("EnergyMin", culture));
            var begin = ParceDateTime(resourceManager.GetString("ExerciseStart", culture));
            var end = ParceDateTime(resourceManager.GetString("ExerciseFinish", culture));
            var activity = new Activity(name, energy);
            return (begin, end, activity);
        }

        private static (Food Food, double Weight) EnterEating()
        {
            var culture = CultureInfo.CreateSpecificCulture("en-us");
            var resourceManager = new ResourceManager("Fitness_Life.CMD.Languages.Messages", typeof(Program).Assembly);
            Console.WriteLine(resourceManager.GetString("EnterProductName", culture));
            var name = Console.ReadLine();            
            var weight = ParceDouble(resourceManager.GetString("WeightProducts", culture));            
            var calories = ParceDouble(resourceManager.GetString("CaloriesProduct", culture));
            var proteins = ParceDouble(resourceManager.GetString("ProteinsProduct", culture));
            var fats = ParceDouble(resourceManager.GetString("FatsProduct", culture));
            var carbohydrates = ParceDouble(resourceManager.GetString("Capbohydrates", culture));

            var product = new Food(name, proteins, fats, calories,  carbohydrates);
            return (Food: product, Weight: weight);
        }

        private static DateTime ParceDateTime(string name)
        {
            var culture = CultureInfo.CreateSpecificCulture("en-us");
            var resourceManager = new ResourceManager("Fitness_Life.CMD.Languages.Messages", typeof(Program).Assembly);
            DateTime birthDate;
            while (true)
            {
                Console.Write(resourceManager.GetString("EnterBirthdate", culture));
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine(resourceManager.GetString("WrongFormat", culture));
                }
            }
            return birthDate;
        }
        private static double ParceDouble(string name)
        {
            while (true)
            {
                Console.Write($"{name}  ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;                                       
                }
                else
                {
                    Console.WriteLine("Неверный формат записи");
                    Console.WriteLine("Wrong format");
                }
            }
        }
        
    }
}
