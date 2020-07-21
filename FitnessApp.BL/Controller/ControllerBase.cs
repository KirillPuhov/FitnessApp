using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FitnessApp.BL.Controller
{
    public abstract class ControllerBase
    {
        protected const string FOODS_FILE_NAME = "foods.dat";
        protected const string USERS_FILE_NAME = "users.dat";
        protected const string EATINGS_FILE_NAME = "eatings.dat";
        protected const string EXERCISES_FILE_NAME = "exercises.dat";
        protected const string ACTIVITIES_FILE_NAME = "activities.dat";

        protected void Save(string fileName, object item)
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, item);
            }
        }

        protected T Load<T>(string fileName)
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream(fileName, FileMode.OpenOrCreate))
            {
                if (fs.Length > 0 && formatter.Deserialize(fs) is T items)
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
