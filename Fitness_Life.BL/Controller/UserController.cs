using Fitness_Life.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness_Life.BL.Controller
{
    public class UserController
    {
        public List<User> Users { get; }
        public User CurrentUser { get; }
        public bool IsNewUser { get; } = false;
    
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(userName));
            }
            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);
            if (CurrentUser==null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }


        }

        public List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();
            using (var file = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(file) is List<User> users)
                {
                    return users;
                }
                else
                {
                    return new List<User>();
                }
            }
        }
        public void SetNewUserData(string genderName, DateTime birthDate, double weight=1, double haight=1)
        {
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = haight;
            Save();
        }
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var file = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(file, Users);
            }
        }
       
    }
}
