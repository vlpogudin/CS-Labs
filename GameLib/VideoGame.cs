using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GameLib
{
    public class VideoGame:Game
    {
        static string[] Devices = { "Телефон", "Компьютер", "PlayStation", "Nintendo Switch", "Xbox", "Ноутбук" };

        #region Fields
        protected string device; // устройство для игры
        protected int countLevels; // кол-во уровней в игре
        #endregion

        #region Properties
        public string Device // св-во для устройства
        {
            get { return device; }
            set 
            {
                Regex latinLetters = new Regex("^[a-zA-Zа-яА-Я\\s]+$");
                if (latinLetters.IsMatch(value))
                    device = value;
                else
                    device = "Устройства нет";
            }
        } 

        public int CountLevels // св-во для кол-ва уровней
        {
            get { return countLevels; }
            set
            {
                if (value < 0) // если число меньше нуля, присваиваем нуль
                    countLevels = 0;
                else
                    countLevels = value;
            }
        }
        #endregion

        #region Constructors
        public VideoGame():base()
        {
            Device = "Телефон";
            CountLevels = 1;
        }

        public VideoGame(string n, int minc, int maxc, int num, string dev, int levc) : base(n, minc, maxc, num)
        {
            Device = dev;
            CountLevels = levc;
        }
        #endregion

        #region Methods
        [ExcludeFromCodeCoverage]
        public override void Show() // переопределение виртуального метода Show
        {
            base.Show();
            Console.WriteLine( $"Устройство: {device}. Кол-во уровней: {countLevels}" );
        }

        [ExcludeFromCodeCoverage]
        public new void Show1() // переопределение не виртуального метода Show1
        {
            base.Show1();
            Console.WriteLine($"Устройство: {device}. Кол-во уровней: {countLevels}");
        }

        public override bool Equals(object obj) // переопределение метода Equals
        {
            if (obj is VideoGame)
            {
                VideoGame vg = (VideoGame)obj;
                return vg.Name == this.Name
                    && vg.MinCount == this.MinCount
                    && vg.MaxCount == this.MaxCount
                    && vg.Device == this.Device
                    && vg.CountLevels == this.CountLevels;
            }
            return false;
        }

        [ExcludeFromCodeCoverage]
        public override void Init() // переопределение ручного ввода
        {
            base.Init();
            Console.WriteLine("Введите устройство для игры: ");
            Regex regex = new Regex("^[a-zA-Z]+$"); // регекс только латинские буквы
            if (regex.IsMatch(Console.ReadLine()))
                Device = Console.ReadLine();
            else
                Device = "Computer";
            Console.WriteLine("Введите кол-во уровней игры: ");
            try
            {
                countLevels = int.Parse(Console.ReadLine());
            }
            catch
            {
                countLevels = 1;
            }
        }

        public override void RandomInit()
        {
            base.RandomInit();
            Device = Devices[rnd.Next(0, Devices.Length)];
            CountLevels = rnd.Next(1, 300);
        }
        #endregion
    }
}
