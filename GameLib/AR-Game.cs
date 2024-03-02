using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GameLib
{
    public class AR_Game:Game
    {
        static bool[] various = { true, false };

        #region Fields
        protected bool needARGlasses; // необходимость VR-очков
        protected bool needARControllers; // необходимость VR-контроллеров
        #endregion

        #region Properties
        public bool NeedARGlasses // автоматическое св-во для VR-очков
        {
            get { return needARGlasses; }
            set { needARGlasses = value; }
        }

        public bool NeedARControllers // автоматическое св-во для VR-контроллеров
        {
            get { return NeedARGlasses; }
            set { NeedARGlasses = value; }
        }
        
        #endregion

        #region Constructors
        public AR_Game():base() // конструктор по умолчанию
        {
            NeedARGlasses = true;
            NeedARControllers = true;
        }

        public AR_Game(string n, int minc, int maxc, int num, bool gl, bool cntr):base(n, minc, maxc, num) // конструктор с параметрами
        {
            NeedARGlasses = gl;
            NeedARControllers = cntr;
        }
        #endregion

        #region Methods
        [ExcludeFromCodeCoverage]
        public override void Show() // переопределение виртуального метода Show
        {
            base.Show();
            Console.WriteLine($"Наличие VR-очков: {needARGlasses}. Наличие VR-контроллеров: {NeedARControllers}");
        }

        [ExcludeFromCodeCoverage]
        public new void Show1() // переопределение не виртуального метода Show1
        {
            base.Show1();
            Console.WriteLine($"Наличие VR-очков: {needARGlasses}. Наличие VR-контроллеров: {NeedARControllers}");
        }

        public override bool Equals(object obj) // переопределение метода Equals
        {
            if (obj is AR_Game)
            {
                AR_Game arg = (AR_Game)obj;
                return arg.Name == this.Name
                    && arg.MinCount == this.MinCount
                    && arg.MaxCount == this.MaxCount
                    && arg.NeedARGlasses == this.NeedARGlasses
                    && arg.NeedARControllers == this.NeedARControllers;
            }
            return false;
        }

        [ExcludeFromCodeCoverage]
        public override void Init() // переопределение ручного ввода
        {
            base.Init();
            Console.WriteLine("Нужны ли VR-очки для игры?");
            try
            {
                NeedARGlasses = bool.Parse(Console.ReadLine());
            }
            catch
            {
                NeedARGlasses = false;
            }
            Console.WriteLine("Нужны ли VR-контроллеры для игры?");
            try
            {
                NeedARControllers = bool.Parse(Console.ReadLine());
            }
            catch
            {
                NeedARControllers = false;
            }
        }

        public override void RandomInit() // переопределение рандомного заполнения
        {
            base.RandomInit();
            NeedARGlasses = various[rnd.Next(various.Length)];
            NeedARControllers = various[rnd.Next(various.Length)];
        }
        #endregion
    }
}
