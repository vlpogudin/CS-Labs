using System;
using System.Diagnostics.Metrics;
using System.Linq;
using GameLib;
using lab9_Dish;
using static System.Net.Mime.MediaTypeNames;

namespace lab
{
    internal class Program
    {
        static string[] Devices = { "Телефон", "Компьютер", "PlayStation", "Nintendo Switch", "Xbox", "Ноутбук" };
        static void Main(string[] args)
        {
            Game[] array = new Game[20];
            for (int i = 0; i < 20; i++)
            {
                switch (i / 5)
                {
                    case 0:
                        array[i] = new Game();
                        break;
                    case 1:
                        array[i] = new BoardGame();
                        break;
                    case 2:
                        array[i] = new VideoGame();
                        break;
                    case 3:
                        array[i] = new AR_Game();
                        break;
                }
                array[i].RandomInit();
            }

            int mainAnswer;
            do
            {
                Console.Clear();
                MenuInterface.PrintMainMenu();
                mainAnswer = Interface.GetInt();
                Console.Clear();
                switch (mainAnswer)
                {
                    case 1:
                        {
                            for (int i = 0; i < array.Length; i++)
                            {
                                if (i % 5 == 0) Console.WriteLine(new String('-', 100));
                                Interface.ChangeColor($"Игра {i+1}: ", ConsoleColor.Green);
                                array[i].Show();
                                array[i].Show1();
                            }
                            Console.WriteLine(new String('-', 100));
                            Interface.ChangeColor("\nНажмите для продолжения...", ConsoleColor.Yellow);
                            Console.ReadKey();
                            break;
                        }

                    case 2:
                        {
                            int taskTwoAnswer;
                            do
                            {
                                Console.Clear();
                                MenuInterface.PrintAdditionalMenu("task2");
                                taskTwoAnswer = Interface.GetInt();
                                switch (taskTwoAnswer)
                                {
                                    case 1:
                                        {
                                            Request1(array);
                                            Interface.ChangeColor("\nНажмите для продолжения...", ConsoleColor.Yellow);
                                            Console.ReadKey();
                                            break;
                                        }

                                    case 2:
                                        {
                                            Request2(array);
                                            Interface.ChangeColor("\nНажмите для продолжения...", ConsoleColor.Yellow);
                                            Console.ReadKey();
                                            break;
                                        }

                                    case 3:
                                        {
                                            Request3(array);
                                            Interface.ChangeColor("\nНажмите для продолжения...", ConsoleColor.Yellow);
                                            Console.ReadKey();
                                            break;
                                        }

                                    case 4:
                                        {
                                            Console.Clear();
                                            break;
                                        }

                                    default:
                                        {
                                            Console.Clear();
                                            Interface.TypeError("menu");
                                            break;
                                        }
                                }
                            } while (taskTwoAnswer != 4);
                            break;
                        }

                    case 3:
                        {
                            int taskThreeAnswer;
                            do
                            {
                                Console.Clear();
                                MenuInterface.PrintAdditionalMenu("task3");
                                taskThreeAnswer = Interface.GetInt();
                                switch (taskThreeAnswer)
                                {
                                    case 1:
                                        {
                                            IInit[] arr = new IInit[12];
                                            for (int i = 0; i < 12; i++)
                                            {
                                                if (i < 4) arr[i] = new Dish();
                                                else if (i < 7) arr[i] = new BoardGame();
                                                else if (i < 11) arr[i] = new VideoGame();
                                                else arr[i] = new AR_Game();
                                                arr[i].RandomInit();
                                            }

                                            Interface.ChangeColor("Вывод объектов массива: ", ConsoleColor.Green);
                                            int countDish = 0, countBG = 0, countVG = 0, countARG = 0;
                                            foreach (IInit item in arr)
                                            {
                                                if (item is Dish) { countDish++; }
                                                else if (item is  BoardGame) { countBG++; }
                                                else if (item is AR_Game) { countARG++; }
                                                else { countVG++; }
                                                item.Show();
                                                Console.WriteLine();
                                            }
                                            Interface.ChangeColor($"Кол-во объектов Dish: {countDish}," +
                                                $" BoardGame: {countBG}," +
                                                $" VideoGame: {countVG}," +
                                                $" AR_Game: {countARG}.", ConsoleColor.Green);
                                            Interface.ChangeColor("\nНажмите для продолжения...", ConsoleColor.Yellow);
                                            Console.ReadKey();
                                            break;
                                        }

                                    case 2:
                                        {
                                            Game g1 = new Game("Прятки", 2, 10, 1);
                                            array[2] = g1;
                                            Array.Sort(array);
                                            Interface.ChangeColor("\nОтсортированный массив по именам: ", ConsoleColor.Green);
                                            foreach (Game item in array) { item.Show(); Console.WriteLine(); }
                                            int pos = Array.BinarySearch(array, new Game("Прятки", 2, 10, 1));
                                            if (pos < 0) Interface.ChangeColor("Такого элемента нет.", ConsoleColor.Red);
                                            else Interface.ChangeColor($"Игра \"{(g1.Name)}\" находится на {pos+1} позиции.", ConsoleColor.Green);
                                            Interface.ChangeColor("\nНажмите для продолжения...", ConsoleColor.Yellow);
                                            Console.ReadKey();
                                            break;
                                        }

                                    case 3:
                                        {
                                            Game g2 = new Game("Стоп солдатик", 2, 4, 1);
                                            array[5] = g2;
                                            Array.Sort(array, new SortByMaxPlayers());
                                            Interface.ChangeColor("\nОтсортированный массив по макс. кол-ву игроков: ", ConsoleColor.Green);
                                            foreach (Game item in array) { item.Show(); Console.WriteLine(); }
                                            int pos1 = Array.BinarySearch(array, g2, new SortByMaxPlayers());
                                            if (pos1 < 0) Interface.ChangeColor("Такого элемента нет.", ConsoleColor.Red);
                                            else Interface.ChangeColor($"Игра \"{(g2.Name)}\" находится на {pos1+1} позиции.", ConsoleColor.Green);
                                            Interface.ChangeColor("\nНажмите для продолжения...", ConsoleColor.Yellow);
                                            Console.ReadKey();
                                            break;
                                        }

                                    case 4:
                                        {
                                            Interface.ChangeColor("\nКлонирование", ConsoleColor.Green);
                                            Game real = new Game("Гонки на спорткарах", 1, 5, 2);
                                            real.Show();
                                            Game clone = (Game)real.Clone();
                                            clone.Name = "(clone)" + clone.Name;
                                            clone.id.number = 999;
                                            Console.WriteLine();
                                            clone.Show();
                                            Console.WriteLine();
                                            real.Show();

                                            Interface.ChangeColor("\nКопирование", ConsoleColor.Green);
                                            Game copy = (Game)real.ShallowCopy();
                                            copy.Show();
                                            Console.WriteLine();
                                            copy.Name = "(copy)" + copy.Name;
                                            copy.id.number = 333;
                                            copy.Show();
                                            Console.WriteLine();
                                            real.Show();
                                            Interface.ChangeColor("\nНажмите для продолжения...", ConsoleColor.Yellow);
                                            Console.ReadKey();
                                            break;
                                        }

                                    case 5:
                                        {
                                            Console.Clear();
                                            break;
                                        }

                                    default:
                                        {
                                            Console.Clear();
                                            Interface.TypeError("menu");
                                            break;
                                        }
                                }

                            } while (taskThreeAnswer != 5);
                            break;
                        }

                    case 4:
                        {
                            Console.Clear();
                            int exitAnswer;
                            do
                            {
                                MenuInterface.PrintExitMenu();
                                exitAnswer = Interface.GetInt();
                                switch (exitAnswer)
                                {
                                    case 1:
                                        {
                                            Console.Clear();
                                            MenuInterface.ExitProgram();
                                            System.Environment.Exit(0);
                                            break;
                                        }
                                    case 2:
                                        {
                                            Console.Clear();
                                            break;
                                        }
                                    default:
                                        {
                                            Console.Clear();
                                            Interface.TypeError("menu");
                                            break;
                                        }
                                }
                            } while (exitAnswer != 2);
                            break;
                        }

                    default:
                        {
                            Console.Clear();
                            Interface.TypeError("menu");
                            break;
                        }
                }
            } while (true);

            #region Methods
            static void Request2(Game[] arr)                                        
            {
                int countVG = 0;
                Interface.ChangeColor("\nДоступные устройства: " + string.Join(", ", Devices), ConsoleColor.Yellow);
                string device = "";
                while (!Devices.Contains(device))
                {
                    Interface.ChangeColor("Введите устройство из списка: ", ConsoleColor.White);
                    device = Console.ReadLine();
                }
                foreach (Game item in arr)
                    if (item is VideoGame)
                    {
                        VideoGame gv = new VideoGame();
                        gv = item as VideoGame;
                        if (gv.Device == device)
                        {
                            countVG++;
                            if (countVG == 1) Console.WriteLine($"\nИгры, в которые можно играть на {device}'е: ");
                            Console.WriteLine($"{countVG}. {gv.Name}");
                        }
                    }
                if (countVG == 0) Console.WriteLine($"\nНет игр, в которые можно играть на {device}'е");
            }

            static void Request1(Game[] arr)
            {
                Interface.ChangeColor("\nНайденные игры: ", ConsoleColor.Green);
                Type gameType = typeof(Game);
                foreach (Game item in arr)
                    if (gameType.IsInstanceOfType(item) && item.MinCount >= 2 && item.MaxCount >= 2)
                        item.Show();
            }

            static void Request3(Game[] arr)
            {
                int gameWithGlassesCount = 0;
                foreach (Game item in arr)
                {
                    AR_Game arg = item as AR_Game;
                    if (arg != null)
                        if (arg.NeedARGlasses == true) { gameWithGlassesCount++; }
                }
                Interface.ChangeColor($"\nКоличество игр, в которые можно играть с использованием VR-очков: {gameWithGlassesCount}", ConsoleColor.DarkGreen);
            }
            #endregion
        }
    }
}
