using System;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    [Serializable]
    public class User
    {
        #region Свойство
        /// <summary>
        /// Имя.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Пол.
        /// </summary>
        public Gender Gender { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Вес.
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Рост.
        /// </summary>
        public double Height { get; set; }

        //DateTime nowDate = DateTime.Today;
        //int age = nowDate.Year - birthDate.Year;
        //if (birthDate > nowDate.AddYears(-age)) age--;

        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }

        #endregion

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        /// <param name="name"> Имя </param>
        /// <param name="gender"> Пол. </param>
        /// <param name="birthDate"> Дата рождения. </param>
        /// <param name="weight"> Вес. </param>
        /// <param name="height"> Рост. </param>
        public User(string name,
                    Gender gender,
                    DateTime birthDate,
                    double weight,
                    double height)
        {
            #region Проверки

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException($"\"{nameof(name)}\" не может быть пустым", nameof(name));
            }

            if (gender == null)
            {
#pragma warning disable IDE0016 // Использовать выражение "throw"
                throw new ArgumentNullException($"\"{nameof(gender)}\" не может быть пустым.", nameof(gender));
#pragma warning restore IDE0016 // Использовать выражение "throw"
            }

            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentNullException($"Не правильный формат \"{nameof(birthDate)}\".", nameof(birthDate));
            }

            if (weight <= 0)
            {
                throw new ArgumentNullException($"\"{nameof(weight)}\" не может быть меньше либо равен нулю.", nameof(weight));
            }

            if (height <= 0)
            {
                throw new ArgumentNullException($"\"{nameof(height)}\" не может быть меньше либо равен нулю.", nameof(height));
            }

            #endregion 

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException($"\"{nameof(name)}\" не может быть пустым", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return "  " + Name + " " + Age;
        }
    }
}
