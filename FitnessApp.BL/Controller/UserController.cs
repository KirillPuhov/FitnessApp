using FitnessApp.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;

namespace FitnessApp.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя
    /// </summary>
    public class UserController : ControllerBase
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

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }
        }

        /// <summary>
        /// Получить сохраненный список пользователей
        /// </summary>
        /// <returns> Пользователь приложения </returns>
        private List<User> GetUsersData()
        {
            return Load<List<User>>(USERS_FILE_NAME) ?? new List<User>();
        }

        /// <summary>
        /// Сохранить данные пользователя
        /// </summary>
        public void Save()
        {
            Save(USERS_FILE_NAME, Users);
        }

        /// <summary>
        ///  Сохранить данные нового пользователя
        /// </summary>
        /// <param name="gender"> Пол </param>
        /// <param name="birthDate"> Дата рождения </param>
        /// <param name="weight"> Вес </param>
        /// <param name="height"> Рост </param>
        public void SetNewUserData(string gender, DateTime birthDate, double weight = 1, double height = 1)
        {
            //TODO: Сделать проверку

            CurrentUser.Gender = new Gender(gender);
            CurrentUser.DateOfBirth = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }
    }
}
