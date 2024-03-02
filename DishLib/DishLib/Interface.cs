using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lab9_Dish
{
    class Interface
    {
        #region Lists
        static List<string> MainMenu = new List<string>() { "=-=-= MAIN MENU =-=-=", "\n1. Task num. 1", "\n2. Task num. 2", 
            "\n3. Task num. 3", "\n4. Exit", "\n\nSelect a menu item: " };
        static List<string> AdditionalMenu = new List<string>() { "=-=-= ADDITIONAL MENU =-=-=", "\n1. Random filling", "\n2. Manual input",
            "\n3. Find the most-caloric dish", "\n4. Try-catch", "\n5. Count objects and collections", "\n6. Go back", "\n\nSelect a menu item: "};
        static List<string> ExitMenu = new List<string>() { "Are you sure you want to exit?", "\n1. Yes",
            "\n2. No, go back", "\n\nSelect a menu item: "};
        #endregion

        #region Print Methods
        static public void PrintMainMenu()
        {
            ChangeColor(MainMenu[0], ConsoleColor.Blue);
            for (int i = 1; i < MainMenu.Count; i++)
            {
                Console.Write(MainMenu[i]);
            }
        }

        static public void PrintAdditionalMenu()
        {
            ChangeColor(AdditionalMenu[0], ConsoleColor.Blue);
            for (int i = 1; i < AdditionalMenu.Count; i++)
            {
                Console.Write(AdditionalMenu[i]);
            }
        }

        static public void PrintExitMenu()
        {
            ChangeColor(ExitMenu[0], ConsoleColor.Blue);
            for (int i = 1; i < ExitMenu.Count; i++)
            {
                Console.Write(ExitMenu[i]);
            }
        }

        static public void PrintNumberCalories(double numberCalories)
        {
            if (numberCalories > 0)
                Console.WriteLine($"\nСalorie content of the dish is {numberCalories} kcal.\n");
            else
                Console.WriteLine("\nThe dish has zero calories.\n");
        }

        static public void PrintPercentageCalories(double percentage)
        {
            ChangeColor($"Calorie content is {percentage}% of the daily rate.\n\n", ConsoleColor.Green);
        }

        static public void PrintIsIdeal(bool isIdeal)
        {
            ChangeColor($"Is the dish ideal: {isIdeal}.\n\n", ConsoleColor.Green);
        }

        static public void PrintDishDetails(string details)
        {
            ChangeColor(details, ConsoleColor.Cyan);
        }

        static public void PrintTotalCalorieContent(int total)
        {
            ChangeColor($"The total calorie content of the dish: {total}.\n\n", ConsoleColor.Green);
        }

        static public void PrintDishComparison(bool isHigher, bool isLower)
        {
            ChangeColor($"The calorie content of the first dish is higher than the calorie content of the second: {isHigher}\n", ConsoleColor.Yellow);
            ChangeColor($"The calorie content of the first dish is lower than the calorie content of the second: {isLower}\n\n", ConsoleColor.Yellow);
        }

        static public void TypeError(int a)
        {
            if (a == 1)
                ChangeColor("\nAn incorrect number or out of range. \nRepeat the input, please: ", ConsoleColor.Red);
            if (a == 2)
                ChangeColor("\nAn incorrect menu item. \nTry again.", ConsoleColor.Red);
            else
                ChangeColor("\nThe number must be non-negative!", ConsoleColor.Red);
        }

        static public void ExitProgramm()
        {
            ChangeColor("The program is over!\n", ConsoleColor.Red);
        }

        static public void PrintMostCaloric(DishArray arr)
        {
            ChangeColor("The most caloric dish: ", ConsoleColor.Yellow);
            Console.Write(arr.FindMostCaloricFood());
        }

        static public void PrintCountObjects(int a)
        {
            if (a == 1)
                ChangeColor($"A total of {Dish.count} objects were created.\n\n", ConsoleColor.Green);
            if (a == 2)
            {
                Console.Clear();
                ChangeColor($"A total of {DishArray.countObjects} objects were created.\n", ConsoleColor.Yellow);
                ChangeColor($"A total of {DishArray.countCollections} collections were created.\n\n", ConsoleColor.Yellow);
            }
        }
        #endregion

        #region Enter Methods
        static public void EnterFields(int a)
        {
            if (a == 1)
                Console.WriteLine("\nEnter the number of proteins: ");
            else if (a == 2)
                Console.WriteLine("\nEnter the number of fats: ");
            else if (a == 3)
                Console.WriteLine("\nEnter the number of carbohydrates: ");
        }

        static public int GetInt()
        {
            int intNumber;
            bool isConvert;
            do
            {
                isConvert = int.TryParse(Console.ReadLine(), out intNumber);
                if (!isConvert)
                    TypeError(1);
            } while (!isConvert);
            return intNumber;
        }

        static public double GetDouble(int a)
        {
            Interface.EnterFields(a);
            double doubleNumber;
            bool isConvert;
            do
            {
                isConvert = double.TryParse(Console.ReadLine(), out doubleNumber);
                if (!isConvert || doubleNumber < 0)
                    TypeError(1);
            } while (!isConvert || doubleNumber < 0);
            return doubleNumber;
        }
        #endregion

        #region Color
        static public void ChangeColor(string str, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(str);
            Console.ResetColor();
        }
        #endregion
    }
}
