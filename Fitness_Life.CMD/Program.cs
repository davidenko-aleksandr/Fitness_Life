using Fitness_Life.BL.Controller;
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
            if (userController.IsNewUser)
            {
                Console.Write("Введите пол: ");
                var gender = Console.ReadLine();
                var birthDate = ParceDateTime();
                var weight = ParceDouble("Введите вес");
                var height = ParceDouble("Введите рост (м.)");
                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();         

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
                Console.Write($"(пример ''85.00''): {name} ");
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
