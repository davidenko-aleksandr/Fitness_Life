using Fitness_Life.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness_Life.BL.Controller
{
    public class EatingController: ControllerBase
    {
        private const string FOODS_FILE_NAME = "foods.dat";
        private const string EATINGS_FILE_NAME = "eatings.dat";
        private readonly User user;
        public List<Food> Foods { get; }
        public Eating Eating { get; }
        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException("Пользователь не может быть пустыи", nameof(user));
            Foods = GetAllFods();
            Eating = GetEating();
        }
        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }
        }
        private Eating GetEating()
        {
            return Load<Eating>(EATINGS_FILE_NAME) ?? new Eating(user);
        }
        private void Save()
        {
            Save(EATINGS_FILE_NAME, Eating);
        }

        private List<Food> GetAllFods()
        {
            return Load<List<Food>>(FOODS_FILE_NAME) ?? new List<Food>();          
        }    
    }
}
