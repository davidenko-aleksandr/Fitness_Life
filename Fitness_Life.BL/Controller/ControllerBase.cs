using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness_Life.BL.Controller
{
    public abstract class ControllerBase
    {
        protected void Save(string fileName, object item)
        {
            var formatter = new BinaryFormatter();
            using (var file = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(file, item);
            }
        }
        protected T Load<T>(string fileName)
        {
            var formatter = new BinaryFormatter();
            using (var file = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (file.Length < 0 && formatter.Deserialize(file) is T items)
                {
                    return items;
                }
                else
                {
                    return default(T);
                }
            }
        }
    }
}
