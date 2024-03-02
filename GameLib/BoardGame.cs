using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

namespace GameLib
{
    public class BoardGame:Game
    {
        static string[] Attributes = { "Фишки", "Токены", "Игральная кость", "Фигуры", "Часы", "Инструкция", "Карты", "Картинки" };
        static bool[] SpecBoard = { true, false };

        #region Fields
        protected bool reqSpecBoard; // требуется спец. поле
        protected string addAttributes; // дополнительные атрибуты
        #endregion

        #region Propeties
        public bool ReqSpecBoard // св-во для спец. поля

        {
            get { return reqSpecBoard; }
            set { reqSpecBoard = value; }
        } 

        public string AddAttributes // св-во для доп. атрибутов
        {
            get { return addAttributes; }
            set { addAttributes = value; }
        } 
        #endregion

        #region Constructors
        public BoardGame() : base()
        {
            ReqSpecBoard = false;
            AddAttributes = "Фишки";
        }
        public BoardGame(string n, int minc, int maxc, int num, bool req, string attr) : base (n, minc, maxc, num)
        {
            ReqSpecBoard = req;
            AddAttributes = attr;
        }
        #endregion

        #region Methods
        [ExcludeFromCodeCoverage]
        public override void Show() // переопределение виртуального метода Show
        {
            base.Show();
            Console.WriteLine( $"Необходимость использования специального поля: {reqSpecBoard}. Дополнительные атрибуты: {addAttributes}" );
        }

        [ExcludeFromCodeCoverage]
        public new void Show1() // переопределение не виртуального метода Show1
        { 
            base.Show1();
            Console.WriteLine( $"Необходимость использования специального поля: {reqSpecBoard}.\n" +
                $"Дополнительные атрибуты: {addAttributes}");
        }

        public override bool Equals(object obj) // переопределение метода Equals
        {
            BoardGame bg = obj as BoardGame;
            if (bg != null)
                return bg.Name == this.Name
                    && bg.MinCount == this.MinCount
                    && bg.MaxCount == this.MaxCount
                    && bg.ReqSpecBoard == this.ReqSpecBoard
                    && bg.AddAttributes == this.AddAttributes;
            else
                return false;
        }

        [ExcludeFromCodeCoverage]
        public override void Init() // переопределение ручного ввода
        {
            base.Init();
            Console.WriteLine("Требуется ли специальное поле к игре?");
            try
            {
                ReqSpecBoard = bool.Parse(Console.ReadLine());
            }
            catch
            {
                ReqSpecBoard = false;
            }
            Console.WriteLine("Введите дополнительные атрибуты к игре: ");
            Regex regex = new Regex("^[a-zA-Z]+$"); // регекс только латинские буквы
            if (regex.IsMatch(Console.ReadLine()))
                AddAttributes = Console.ReadLine();
            else
                AddAttributes = "no attributes";
        }

        public override void RandomInit() // переопределение рандомного заполнения
        {
            base.RandomInit();
            AddAttributes = Attributes[rnd.Next(0, Attributes.Length)];
            ReqSpecBoard = SpecBoard[rnd.Next(0, SpecBoard.Length)];
        }
        #endregion
    }
}
