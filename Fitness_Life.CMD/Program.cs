using Fitness_Life.BL.Controller;
using Fitness_Life.BL.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

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
            if (userController.IsNewUser)
            {
                Console.Write(resourceManager.GetString("EnterGender", culture));
                var gender = Console.ReadLine();
                var birthDate = ParceDateTime();
                var weight = ParceDouble(resourceManager.GetString("EnterWeight", culture));
                var height = ParceDouble(resourceManager.GetString("EnterHeight", culture));
                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);
            Console.WriteLine(resourceManager.GetString("WhatToDo", culture));
            Console.WriteLine(resourceManager.GetString("AddFood", culture));
            Console.WriteLine();
            var key = Console.ReadKey();
            if (key.Key==ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);
                foreach(var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"{item.Key} - {item.Value}");
                }
            }
            Console.ReadLine();         
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

        private static DateTime ParceDateTime()
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
