using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab
{
    public class MenuInterface
    {
        static List<string> MainMenu = new List<string>() { "=== ГЛАВНОЕ МЕНЮ ===",
            "1. Задание 1\n", "2. Задание 2\n", "3. Задание 3\n", "4. Выход", "\n\nВыберите пункт меню: " };
        static List<string> ExitMenu = new List<string>() { "Вы уверены, что хотите завершить работу?", "1. Да\n", "2. Нет", "\n\nВыберите пункт меню: " };
        static List<string> AdditionalMenu = new List<string>() { "=== ДОПОЛНИТЕЛЬНОЕ МЕНЮ ===", 
            "1. Вся информация об играх, в котором минимальное количество игроков не меньше " +
            "заданного и заданное число не превышает максимального количества игроков в игре.", 
            "\n2. Название видео игр, в которые можно играть на указанном устройстве.", 
            "\n3. Количество игр, в которые можно играть с использованием VR-очков.",
            "\n4. Вернуться в главное меню", "\n\nВыберите пункт меню: ",
            "1. Вывод объектов массива на экран и подсчёт кол-ва объектов определённого типа.", 
            "\n2. Бинарный поиск в отсортированном массиве при помощи IComparable.",
            "\n3. Бинарный поиск в отсортированном массиве при помощи ICompare.",
            "\n4. Клонирование и копирование.",
            "\n5. Вернуться в главное меню", "\n\nВыберите пункт меню: "};


        public static void ChangeColor(string str, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(str);
            Console.ResetColor();
        }

        public static void PrintMainMenu()
        {
            ChangeColor(MainMenu[0], ConsoleColor.Blue);
            for (int i = 1; i < MainMenu.Count; i++)
            {
                Console.Write(MainMenu[i]);
            }
        }

        static public void PrintAdditionalMenu(string task)
        {
            ChangeColor(AdditionalMenu[0], ConsoleColor.Blue);
            if (task == "task2")
            {
                for (int i = 1; i < 6; i++)
                {
                    Console.Write(AdditionalMenu[i]);
                }
            }
            else if (task == "task3")
            {
                for (int i = 6; i < 12; i++)
                {
                    Console.Write(AdditionalMenu[i]);
                }
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

        static public void ExitProgram()
        {
            ChangeColor("The program is over!\n", ConsoleColor.Red);
        }
    }
}
