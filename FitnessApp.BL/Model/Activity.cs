using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BL.Model
{
    [Serializable]
    public class Activity
    {
        #region Свойства
        /// <summary>
        /// Название активности
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Калории в минуту
        /// </summary>
        public double CaloriesPerMinute { get; set; }
        #endregion

        public Activity(string name, double caloriesPerMinute)
        {
            //TODO Проверка

            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
