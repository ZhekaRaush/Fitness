using System;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Пища.
    /// </summary>
    [Serializable]
    public class Food
    {
        /// <summary>
        /// Наименование.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Белки за 100 грамм продукта.
        /// </summary>
        public double Proteins { get; }

        /// <summary>
        /// Жиры за 100 грамм продукта.
        /// </summary>
        public double Fats { get; }

        /// <summary>
        /// Углеыоды за 100 грамм продукта.
        /// </summary>
        public double Сarbohydrates { get; }

        /// <summary>
        /// Колории за 100 грамм продукта.
        /// </summary>
        public double Calories { get; }

        /// <summary>
        /// Белки за 1 грамм продукта.
        /// </summary>
        private double ProteinsOneGramm { get { return Proteins / 100.0; } }

        /// <summary>
        /// Жиры за 1 грамм продукта.
        /// </summary>
        private double FatsOneGramm { get { return Fats / 100.0; } }

        /// <summary>
        /// Углеыоды за 1 грамм продукта.
        /// </summary>
        private double СarbohydratesOneGramm { get { return Сarbohydrates / 100.0; } }

        /// <summary>
        /// Калории за 1 грамм продукта.
        /// </summary>
        private double CaloriesOneGramm { get { return Calories / 100.0; } }

        public Food(string name) : this(name, 0, 0, 0, 0) { }

        public Food(string name, double proteins, double fats, double carbohydrates, double calories)
        {
            // TODO: проверки.
            Name = name;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Сarbohydrates = carbohydrates / 100.0;
            Calories = calories / 100.0;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
