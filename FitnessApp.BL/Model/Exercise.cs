using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessApp.BL.Model
{
    [Serializable]
    public class Exercise
    {
        #region Свойства
        /// <summary>
        /// Старт упражнения
        /// </summary>
        public DateTime Start { get; }

        /// <summary>
        /// финиш упрожнения
        /// </summary>
        public DateTime Finish { get; }

        /// <summary>
        /// Активность во время упрожнения
        /// </summary>
        public Activity Activity { get; }

        /// <summary>
        /// Ползьзователь приложения
        /// </summary>
        public User User { get; }
        #endregion

        public Exercise(DateTime start, DateTime finish, Activity activity, User user)
        {
            //TODO Проверка

            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;
        }
    }
}
