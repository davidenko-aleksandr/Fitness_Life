using Fitness_Life.BL.Controller;
using Fitness_Life.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fitness_Life.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует приложение Fitness Life!");
            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();
            
            var userController = new UserController(name);
            var eatingController = new EatingController(userController.CurrentUser);
            if (userController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();
                var birthDate = ParceDateTime();
                var weight = ParceDouble("Введите вес ");
                var height = ParceDouble("Введите рост (cм.) ");
                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);
            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("E - ввести прием пищи");
            Console.WriteLine();
            var key = Console.ReadKey();
            if (key.Key==ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);
                foreach(var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"/t{item.Key} - {item.Value}");
                }
            }
            Console.ReadLine();         

        }

        private static (Food Food, double Weight) EnterEating()
        {
            Console.WriteLine("Введите имя продукта: ");
            var name = Console.ReadLine();            
            var weight = ParceDouble("вес порции ");            
            var calories = ParceDouble("введите каллорийность: ");
            var proteins = ParceDouble("введите белки: ");
            var fats = ParceDouble("Введите жири: ");
            var carbohydrates = ParceDouble("Введите углеводы: ");

            var product = new Food(name, proteins, fats, calories,  carbohydrates);
            return (Food: product, Weight: weight);
        }

        private static DateTime ParceDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write("Введите дату рождения (пример ''22.11.1990''): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный формат записи");
                }
            }
            return birthDate;
        }
        private static double ParceDouble(string name)
        {
            while (true)
            {
                Console.Write($"{name} (пример ''85''):  ");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;                                       
                }
                else
                {
                    Console.WriteLine("Неверный формат записи");
                }
            }
        }
    }
}
