using Fitness_Life.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness_Life.BL.Controller
{
    public class ExerciseController : ControllerBase
    {
        private const string FILE_EXERCIZE_ACTIVITY_NAME = "exercises.txt";
        private readonly User user;
        public List<Exercise> Exercises { get; set; }
        public List<Activity> Activities { get; set; }

        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));
            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }

        public void Add(Activity activity, DateTime begin, DateTime end)
        {
            var act = Activities.SingleOrDefault(a => a.Name == activity.Name);
            if (act==null)
            {
                Activities.Add(activity);
                var exercise = new Exercise(begin, end, activity, user);
                Exercises.Add(exercise);           
            }
            else
            {
                Activities.Add(activity);
                var exercise = new Exercise(begin, end, act, user);
                Exercises.Add(exercise);              
            }
            Save();
        }
        private List<Activity> GetAllActivities()
        {
            return Load<List<Activity>>(FILE_EXERCIZE_ACTIVITY_NAME) ?? new List<Activity>();
        }

        private List<Exercise> GetAllExercises()
        {
            return Load<List<Exercise>>(FILE_EXERCIZE_ACTIVITY_NAME) ?? new List<Exercise>();
        }
        private void Save()
        {
            Save(FILE_EXERCIZE_ACTIVITY_NAME, Exercises);
        }
    }
}
