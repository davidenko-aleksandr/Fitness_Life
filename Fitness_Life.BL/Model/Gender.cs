using System;


namespace Fitness_Life.BL.Model
{
    [Serializable]
    public class Gender
    {
        public string Name { get; }

        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пола не может быть пустым или null", nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
               return Name;
        }    
    }
}
