using System;

namespace FitnessApp.BL.Model
{
    /// <summary>
    /// Продукты
    /// </summary>
    [Serializable]
    public class Food
    {
        #region Свойства
        /// <summary>
        /// Название продукта
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Белки
        /// </summary>
        public double Proteins { get; }

        /// <summary>
        /// Жиры
        /// </summary>
        public double Fats { get; }

        /// <summary>
        /// Углероды
        /// </summary>
        public double Carbohydrates { get; }

        /// <summary>
        /// Калории
        /// </summary>
        public double Calories { get; set; }
        #endregion

        public Food(string name) : this(name, 0, 0, 0, 0) { }

        public Food(string name, double proteins, double fats, double carbohydrates, double calories)
        {
            //TODO Проверка

            Name = name;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
            Calories = calories / 100.0;
        }
    }
}
