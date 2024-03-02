using System.Diagnostics.CodeAnalysis;

namespace GameLib
{
    [ExcludeFromCodeCoverage]
    public class Interface
    {
        static public int GetInt()
        {
            int intNumber;
            bool isConvert;
            do
            {
                isConvert = int.TryParse(Console.ReadLine(), out intNumber);
                if (!isConvert)
                    TypeError();
            } while (!isConvert);
            return intNumber;
        }

        static public void TypeError(string str = "repeat")
        {
            if (str == "repeat")
                ChangeColor("\nНекорректный ввод или число выходит за пределы. \nПовторите ввод: ", ConsoleColor.Red);
            if (str == "menu")
                ChangeColor("Некорректный пункт меню. \nПопробуйте снова.\n\n", ConsoleColor.Red);
            if (str == "empty")
                ChangeColor("Массив пуст.\n\n", ConsoleColor.Red);
        }

        public static void ChangeColor(string str, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(str);
            Console.ResetColor();
        }
    }
}
