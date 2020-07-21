using System;

namespace FitnessApp.BL.Model
{
    /// <summary>
    /// Пользователь
    /// </summary>
    [Serializable]
    public class User
    {
        #region Свойства
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Пол
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Вес
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Рост
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Возрост
        /// </summary>
        public int Age { get { return DateTime.UtcNow.Year - DateOfBirth.Year; } }
        #endregion 

        /// <summary>
        /// Создать нового пользователя
        /// </summary>
        /// <param name="name"> Имя </param>
        /// <param name="gender"> Пол </param>
        /// <param name="date"> Дата рождения </param>
        /// <param name="weight"> Вес </param>
        /// <param name="height"> Рост </param>
        public User(string name,
                    Gender gender,
                    DateTime date,
                    double weight,
                    double height)
        {
            #region проверка условий
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null", nameof(name));
            }

            if (gender == null)
            {
                throw new ArgumentNullException("Имя пола не может быть пустым или null", nameof(gender));
            }

            if (date < DateTime.Parse("01.01.1900") || date >= DateTime.Now)
            {
                throw new ArgumentException("Невозможная дата рождения", nameof(date));
            }

            if (weight <= 0)
            {
                throw new ArgumentException("Вес не может быть меньше либо равен нулю", nameof(weight));
            }

            if (height <= 0)
            {
                throw new ArgumentException("Рост не может быть меньше либо равен нулю", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            DateOfBirth = date;
            Weight = weight;
            Height = height;
        }

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name + "  " + Age;
        }
    }
}
