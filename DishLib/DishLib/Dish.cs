using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lab9_Dish
{
    public class Dish : GameLib.IInit
    {
        Random rnd = new Random();

        #region Fields
        double proteins; // the amount of proteins per 100 grams of the dish
        double fats; // the amount of fats per 100 grams of the dish
        double carbohydrates; // the amount of carbohydrates per 100 grams of the dish
        public static int count = 0; // the number of class object created
        public double numberCalories;
        #endregion

        #region Properties   

        public double Proteins // propetry for proteins
        {
            get => proteins;
            set 
            {
                if (value < 0)
                    proteins = 0;
                else 
                    proteins = value;
            }
        }

        public double Fats // propetry for fats
        {
            get => fats;
            set
            {
                if (value < 0)
                    fats = 0;
                else 
                    fats = value;
            }
        }

        public double Carbohydrates // propetry for carbohydrates
        {
            get => carbohydrates;
            set 
            {
                if (value < 0)
                    carbohydrates = 0;
                else 
                    carbohydrates = value;
            }
        }

        //public double Proteins { get; set; } // automatic property for proteins
        //public double Fats { get; set; } // automatic property for fats
        //public double Carbohydrates { get; set; } // automatic property for carbohydrates
        #endregion

        #region Constructors
        public Dish(double proteins, double fats, double carbohydrates) // parameterized constructor
        {
            this.proteins = proteins;
            this.fats = fats;
            this.carbohydrates = carbohydrates;
            count++;
        }

        public Dish() // parameterless constructor
        {
            proteins = 0;
            fats = 0;
            carbohydrates = 0;
            count++;
        }

        public Dish(Dish d) // copy constructor
        {
            proteins = d.proteins;
            fats = d.fats;
            carbohydrates = d.carbohydrates;
            count++;
        }
        #endregion

        #region Methods
        public void Show(string name) // information about fields
        {
            Interface.ChangeColor($"The {name} contains: {proteins} g. proteins, {fats} g. fats, {carbohydrates} g. carbohydrates.", ConsoleColor.Cyan);
        }

        public void Show() // information about fields
        {
            Console.WriteLine($"Блюдо содержит: {proteins} г. белков, {fats} г. жиров, {carbohydrates} г. углеводов.", ConsoleColor.Cyan);
        }

        public double NumberCalories() // class method of calculate calories 
        {
            numberCalories = Math.Round(4 * proteins + 9 * fats + 4 * carbohydrates, 2);
            return numberCalories;
        }

        public static double CalculateCalories(Dish d) // static method of calculate calories
        {
            d.numberCalories = Math.Round(4 * d.proteins + 9 * d.fats + 4 * d.carbohydrates, 2);
            return d.numberCalories;
        }

        public override bool Equals(object obj) 
        {
            if(obj == null) return false;
            if(obj is not Dish) return false;
            return ((Dish)obj).Proteins == this.Proteins && ((Dish)obj).Fats == this.Fats && ((Dish)obj).Carbohydrates == this.Carbohydrates;
        }

        public void Init()
        {
            Console.WriteLine("Введите количество белков: ");
            try
            {
                Proteins = double.Parse(Console.ReadLine());
            }
            catch
            {
                Proteins = 10;
            }
            Console.WriteLine("Введите количество жиров: ");
            try
            {
                Fats = double.Parse(Console.ReadLine());
            }
            catch
            {
                Fats = 5;
            }
            Console.WriteLine("Введите количество углеводов: ");
            try
            {
                Carbohydrates = double.Parse(Console.ReadLine());
            }
            catch
            {
                Carbohydrates = 1;
            }
        }

        public void RandomInit()
        {
            Proteins = Math.Round(rnd.Next(1, 300) + rnd.NextDouble(),2);
            Fats = Math.Round(rnd.Next(1, 300) + rnd.NextDouble(),2);
            Carbohydrates = Math.Round(rnd.Next(1, 300) + rnd.NextDouble(),2);
        }


        #endregion

        #region Unary operations
        public static Dish operator ++(Dish d) // unary operator ++
        {
            Dish result = new Dish(d);
            result.Proteins = d.Proteins + 1;
            result.Fats = d.Fats + 1;
            result.Carbohydrates = d.Carbohydrates + 1;
            return result;
        }

        public static double operator ~(Dish d) // unary operator ~
        {
            return Math.Round(CalculateCalories(d) / 2000 * 100, 2);
        }
        #endregion

        #region Type convertions
        public static explicit operator bool(Dish d) // explicit convert to bool operator
        {
            if (d.Proteins == d.Fats && 4 * d.Proteins == 3 * d.Carbohydrates)
                return true;
            else
                return false;
        }

        public static implicit operator string(Dish d)
        {
            return $"Proteins - {d.Proteins} g., fats - {d.Fats} g., carbohydrates - {d.Carbohydrates} g.\n\n";
        }
        #endregion

        #region Binary operations
        public static int operator *(Dish d, double portion)
        {
            return (int)(d.numberCalories * portion);
        }

        public static int operator *(double portion, Dish d)
        {
            return (int)(portion * d.numberCalories);
        }

        public static bool operator >(Dish d1, Dish d2)
        {
            return d1.numberCalories > d2.numberCalories;
        }

        public static bool operator <(Dish d1, Dish d2)
        {
            return d1.numberCalories < d2.numberCalories;
        }
        #endregion
    }
}
