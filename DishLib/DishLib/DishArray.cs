using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace lab9_Dish
{
    public class DishArray
    {
        Dish[] arr;
        public static int countObjects = 0;
        public static int countCollections = 0;

        static Random rnd = new Random();

        public int Length
        {
            get
            {
                return arr.Length;
            }
        }

        #region Constructors
        public DishArray() // parameterless constructor
        {
            arr = new Dish[3];
            arr[0] = new Dish(1, 1, 1);
            arr[1] = new Dish(2, 2, 2);
            arr[2] = new Dish(3, 3, 3);
            countObjects += 3;
            countCollections++;
        }

        public DishArray(int Length) // parameterized constructor (random)
        {
            arr = new Dish[Length];
            for (int i = 0; i < Length; i++)
            {
                arr[i] = new Dish(rnd.Next(50), rnd.Next(50), rnd.Next(50));
            }
            countObjects += Length;
            countCollections++;
        }

        public DishArray(int Length, int a) // parameterized constructor (manual input)
        {
            arr = new Dish[Length];
            for (int i = 0; i < Length; i++)
            {
                arr[i] = new Dish(Interface.GetDouble(1), Interface.GetDouble(2), Interface.GetDouble(3));
            }
            countObjects += Length;
            countCollections++;
        }

        public DishArray(DishArray other) // copy constructor
        {
            arr = new Dish[other.Length];
            for (int i = 0; i < Length; i++)
            {
                arr[i] = new Dish(other.arr[i]);
            }
            countObjects += Length;
            countCollections++;
        }
        #endregion
        public void Show()
        {
            for (int i = 0;i < this.Length;i++)
            {
                arr[i].Show();
            }
            Console.WriteLine();
        }

        public Dish this[int index]
        {
            get
            {
                if (index >= 0 && index < arr.Length)
                    return arr[index];

                throw new IndexOutOfRangeException();
            }

            set 
            {
                if (index >= 0 && index < arr.Length)
                    arr[index] = value;
                else
                    Interface.ChangeColor("Array index out of bounds!\n\n", ConsoleColor.Red);
            }
        }

        public Dish FindMostCaloricFood()
        {
            Dish mostCaloric = arr[0];
            for (int i = 1; i < this.Length; i++)
            {
                if (arr[i].NumberCalories() > mostCaloric.NumberCalories())
                    mostCaloric = arr[i];
            }
            countObjects++;
            return mostCaloric;
        }
    }
}
