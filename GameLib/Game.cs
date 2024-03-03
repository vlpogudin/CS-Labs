using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace GameLib
{
    public class Game:IInit, IComparable, ICloneable
    {
        public class IdNumber
        {
            public int number;
            public IdNumber(int number)
            {
                this.number = number;
            }

            public override string ToString()
            {
                return number.ToString();
            }

            public int Number
            {
                get { return number; }
                set 
                { 
                    if (value < 0)
                        number = 0; 
                    else
                        number = value;
                }
            }

            public override bool Equals(object? obj)
            {
                if(obj is IdNumber n) return this.number == n.number;
                return false;
            }
        }

        protected Random rnd = new Random();
        static string[] Names = { "Монополия", "Салки", "Шахматы", "Уно", "Fall Guys", "Гуси лебеди", 
            "CS VR", "Нарды", "Mario", "Minecraft", "Находка для шпиона" }; // мб закинуть все в файл

        #region Fields
        public IdNumber id;
        protected string name; // название игры
        protected int minCount; // мин. кол-во игроков
        protected int maxCount; // макс кол-во игроков
        #endregion

        #region Properties
        public string Name // свойство для названия игры (мб использовать регекс)
        {
            get { return name; }
            set 
            {
                Regex latinLetters = new Regex("^[a-zA-Zа-яА-Я\\s]+$");
                if (latinLetters.IsMatch(value))
                    name = value; 
                else
                    name = "Названия нет";
            }
        }

        public int MinCount // свойство для мин. кол-ва людей
        {
            get { return minCount; }
            set 
            {
                if (value < 0) // если число меньше нуля, присваиваем нуль
                    minCount = 0;
                else
                    minCount = value;
            }
        }

        public int MaxCount // свойство для макс. кол-ва людей
        {
            get { return maxCount; }
            set 
            {
                if (value < 0) // если число меньше нуля, присваиваем нуль
                    maxCount = 0;
                else
                    maxCount = value;
            }
        }
        #endregion

        #region Constructors
        public Game() // конструктор по умолчанию
        {
            Name = string.Empty;
            MinCount = 0;
            MaxCount = 0;
            id = new IdNumber(1);
        }

        public Game(string n, int minc, int maxc, int number) // конструктор с параметрами 
        {
            Name = n;
            MinCount = minc;
            MaxCount = maxc;
            id = new IdNumber(number);
        }
        #endregion

        #region Methods
        [ExcludeFromCodeCoverage]
        public virtual void Show() // виртуальный метод
        {
            Console.WriteLine( $"ID: {id}. Название: {Name}. Мин. кол-во игроков: {MinCount}. Макс. кол-во игроков: {maxCount}.");
        }

        [ExcludeFromCodeCoverage]
        public void Show1() // не виртуальный метод
        {
            Console.WriteLine( $"ID: {id}. Название: {Name}. Мин. кол-во игроков: {MinCount}. Макс. кол-во игроков: {maxCount}." );
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj is Game g)
                return this.Name == g.Name && this.MinCount == g.MinCount && this.MaxCount == g.MaxCount;
            return false;
        }

        [ExcludeFromCodeCoverage]
        public virtual void Init() // метод для ввода информации об объектах с клавиатуры
        {
            Console.WriteLine("Введите id: ");
            try
            {
                id.number = int.Parse(Console.ReadLine());
            }
            catch
            {
                id.number = 0;
            }
            Console.WriteLine("Введите название игры: ");
            Name = Console.ReadLine();
            Console.WriteLine("Введите мин. кол-во игроков: ");
            try
            {
                MinCount = int.Parse(Console.ReadLine());
            }
            catch
            {
                MinCount = 1;
            }
            Console.WriteLine("Введите макс. кол-во игроков: ");
            try
            {
                MaxCount = int.Parse(Console.ReadLine());
            }
            catch
            {
                MaxCount = 10;
            }
        }

        public virtual void RandomInit() // метод для рандомного формирования объектов
        {
            Name = Names[rnd.Next(0, Names.Length)];
            MinCount = rnd.Next(1, 3);
            MaxCount = rnd.Next(3, 10);
            id.number = rnd.Next(1, 100);
        }

        public int CompareTo(object? obj) // метод сравнение объектов (IComparable)
        {
            if (obj == null) return -1;
            if (obj is not Game) return -1;
            Game g = obj as Game;
            return String.Compare(this.Name, g.Name);
        }

        public object Clone() // метод клонирования объектов (ICloneable)
        {
            return new Game(Name, MinCount, MaxCount, id.number);
        }

        public object ShallowCopy() // метод копирования объектов (ICloneable)
        {
            return this.MemberwiseClone();
        }
        #endregion
    }
}