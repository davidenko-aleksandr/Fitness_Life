using System;

namespace Fitness_Life.BL.Model
{
    [Serializable]
    public class Food
    {
        public string Name { get; }
        public double Proteins { get; }
        public double Fats { get; }
        public double Carbohydrates { get; }
        public double Calorie { get; }
        private double CalloriesOneGramm { get { return Calorie / 100.0; } }
        private double ProteinsOneGramm { get { return Proteins / 100.0; } }
        private double FatsOneGramm { get { return Fats / 100.0; } }
        private double CarbohydratesOnwGramm { get { return Carbohydrates / 100.0; } }
        public Food(string name) : this(name, 0, 0, 0, 0) { }
        public Food(string name, double proteins, double fats, double carbohydrates, double calories)
        {
            //TODO create check
            Name = name;
            Proteins = proteins /100.0;
            Fats = fats /100.0;
            Carbohydrates = carbohydrates /100.0;
            Calorie = calories /100.0;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
