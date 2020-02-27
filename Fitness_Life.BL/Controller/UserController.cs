using Fitness_Life.BL.Model;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness_Life.BL.Controller
{
    public class UserController
    {
        public User User { get; }
        public UserController(string userName, string genderName, DateTime birthDay, double weidht, double height)
        {
            var gender = new Gender(genderName);
            User = new User(userName, gender, birthDay, weidht, height);
        }
        public UserController()
        {
            var formatter = new BinaryFormatter();
            using (var file = new FileStream("user.data", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(file) is User user)
                {
                    User = user;
                    //TODO что делать если пользователя не прочитали
                }

            }
        }
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var file = new FileStream("user.data", FileMode.OpenOrCreate))
            {
                formatter.Serialize(file, User);
            }
        }
       
    }
}
