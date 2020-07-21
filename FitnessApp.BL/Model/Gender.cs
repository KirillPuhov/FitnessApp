using System;

namespace FitnessApp.BL.Model
{
    /// <summary>
    /// Пол
    /// </summary>
    [Serializable]
    public class Gender
    {
        #region Свойства
        /// <summary>
        /// Название пола
        /// </summary>
        public string GenderName { get; }
        #endregion

        /// <summary>
        /// Создать новый пол 
        /// </summary>
        /// <param name="name"> Имя пола </param>
        public Gender(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пола не может быть пустым или null", nameof(name));
            }

            GenderName = name;
        }

        public override string ToString()
        {
            return GenderName;
        }
    }
}
