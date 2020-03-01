using System;

namespace Fitness_Life.BL.Model
{
    [Serializable]
    public class Activity
    {
        public string Name { get; set; }
        public double CalloriesPerMinute { get; set; }
        public Activity(string name, double calloriesPerMinute)
        {
            //TODO check
            Name = name;
            CalloriesPerMinute = calloriesPerMinute;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
