using GameLib;
using static GameLib.Game;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        #region Class Game
        [TestMethod]
        public void TestParamlessConstr_SetName() // конструктор по умолчанию, св-во имени 
        {
            Game g1 = new Game();
            g1.Name = "Test";
            Assert.AreEqual("Test", g1.Name);
        }

        [TestMethod]
        public void TestParamConstr_SetMinCount() // конструктор с параметрами, св-во мин. кол-ва игроков 
        {
            Game g1 = new Game("123 TEST", 1, 4, 1);
            g1.MinCount = 2;
            Assert.AreEqual(2, g1.MinCount);
        }

        [TestMethod]
        public void TestMethodClone_SetMaxCount() // метод клонирования, св-во макс. кол-ва игроков
        {
            Game g1 = new Game("test", 2, 6, 1);
            Game g2 = (Game)g1.Clone();
            Assert.AreNotSame(g2, g1);
            g2.MaxCount = 10;
            Assert.AreEqual(10, g2.MaxCount);
        }

        [TestMethod]
        public void TestMethodCopy() // метод копирования
        {
            Game g1 = new Game("Test", 1, 5, 20);
            Game g2 = (Game)g1.ShallowCopy();
            Assert.IsTrue(g2.Equals(g1));
        }

        [TestMethod]
        public void TestGMethodRandomInit() // случайное заполнение элементов
        {
            Game g1 = new Game();
            g1.RandomInit();
            Assert.IsNotNull(g1.Name);
            Assert.IsTrue(g1.MinCount >= 1 && g1.MinCount <= 3);
            Assert.IsTrue(g1.MaxCount >= 3 && g1.MaxCount <= 10);
            Assert.IsTrue(g1.id.number >= 1 && g1.id.number <= 100);
        }

        [TestMethod]
        public void TestMethodCompareTo() // сравнение объектов
        {
            Game g1 = new Game { Name = "AA" };
            Game g2 = new Game { Name = "BB" };
            Assert.IsTrue(g1.CompareTo(g2) < 0);
        }

        [TestMethod]
        public void TestErrorSetID() // присваивание отрицательного значения в id -> возвращение нуля
        {
            IdNumber id = new IdNumber(5);
            id.Number = -10;
            Assert.AreEqual(0, id.Number);
        }

        [TestMethod]
        public void TestCorrectSetID_EqualsID() // корректное присваивание id, сравнение одинаковых объектов
        {
            IdNumber id1 = new IdNumber(10);
            IdNumber id2 = new IdNumber(10);
            Assert.IsTrue(id1.Equals(id2));
        }

        [TestMethod]
        public void TestDifferentID() // сравнение разных объектов, присваивание отрицательного id -> возвращение нуля
        {
            IdNumber id1 = new IdNumber(10);
            IdNumber id2 = new IdNumber(-5);
            Assert.IsFalse(id1.Equals(id2));
        }

        [TestMethod]
        public void TestToStringMethod()
        {
            IdNumber id1 = new IdNumber(41);
            Assert.AreEqual("41", id1.ToString());
        }
        #endregion

        #region Class BoardGame
        [TestMethod]
        public void TestBGParamlessConstr() // конструктор без параметров
        {
            BoardGame bg = new BoardGame();
            Assert.IsFalse(bg.ReqSpecBoard);
            Assert.AreEqual("Фишки", bg.AddAttributes);
        }

        [TestMethod]
        public void TestBGParamConstr_SetAttr() // конструктор с параметрами, св-во атрибутов
        {
            BoardGame bg = new BoardGame("test", 1, 6, 1, true, "test attr");
            bg.AddAttributes = "attr test";
            Assert.IsTrue(bg.ReqSpecBoard);
            Assert.AreEqual("attr test", bg.AddAttributes);
        }

        [TestMethod]
        public void TestBGMethodRandomInit() // случайное заполнение элементов
        {
            BoardGame bg1 = new BoardGame();
            bg1.RandomInit();
            Assert.IsNotNull(bg1.Name);
            Assert.IsTrue(bg1.MinCount >= 1 && bg1.MinCount <= 3);
            Assert.IsTrue(bg1.MaxCount >= 3 && bg1.MaxCount <= 10);
            Assert.IsTrue(bg1.id.number >= 1 && bg1.id.number <= 100);
            Assert.IsNotNull(bg1.ReqSpecBoard);
            Assert.IsNotNull(bg1.AddAttributes);
        }

        [TestMethod]
        public void TestBGMethodEqualsObjects() // одинаковые объекты
        {
            BoardGame bg1 = new BoardGame("Test", 2, 7, 11, true, "Test attr");
            BoardGame bg2 = new BoardGame("Test", 2, 7, 11, true, "Test attr");
            Assert.IsTrue(bg1.Equals(bg2));
        }

        [TestMethod]
        public void TestBGMethodDifferentObjects() // разные объекты
        {
            BoardGame bg1 = new BoardGame("Test", 2, 7, 11, true, "Test attr");
            BoardGame bg2 = new BoardGame("Test", 2, 7, 11, false, "Test attr");
            Assert.IsFalse(bg1.Equals(bg2));
        }
        #endregion

        #region Class VideoGame
        [TestMethod]
        public void TestVGParamlessConstr() // конструктор без параметров
        {
            VideoGame vg = new VideoGame();
            Assert.AreEqual("Телефон", vg.Device);
            Assert.AreEqual(1, vg.CountLevels);
        }

        [TestMethod]
        public void TestVGParamConstr_SetDevice() // конструктор с параметрами, св-во устройств
        {
            VideoGame vg = new VideoGame("test", 1, 6, 1, "test", 2);
            vg.Device = "dev test";
            Assert.AreEqual(2, vg.CountLevels);
            Assert.AreEqual("dev test", vg.Device);
        }

        [TestMethod]
        public void TestVGMethodRandomInit() // случайное заполнение элементов
        {
            VideoGame vg1 = new VideoGame();
            vg1.RandomInit();
            Assert.IsNotNull(vg1.Name);
            Assert.IsTrue(vg1.MinCount >= 1 && vg1.MinCount <= 3);
            Assert.IsTrue(vg1.MaxCount >= 3 && vg1.MaxCount <= 10);
            Assert.IsTrue(vg1.id.number >= 1 && vg1.id.number <= 100);
            Assert.IsNotNull(vg1.Device);
            Assert.IsTrue(vg1.CountLevels >= 1 && vg1.CountLevels <= 300);
        }

        [TestMethod]
        public void TestVGMethodEqualsObjects() // одинаковые объекты
        {
            VideoGame vg1 = new VideoGame("Test", 2, 7, 11, "Test dev", 64);
            VideoGame vg2 = new VideoGame("Test", 2, 7, 11, "Test dev", 64);
            Assert.IsTrue(vg1.Equals(vg2));
        }

        [TestMethod]
        public void TestVGMethodDifferentObjects() // разные объекты
        {
            VideoGame vg1 = new VideoGame("Test", 2, 7, 11, "Test dev", 64);
            VideoGame vg2 = new VideoGame("Test", 2, 7, 11, "dev", 64);
            Assert.IsFalse(vg1.Equals(vg2));
        }
        #endregion

        #region Class AR_Game
        [TestMethod]
        public void TestARGParamlessConstr() // конструктор без параметров
        {
            AR_Game arg = new AR_Game();
            Assert.IsTrue(arg.NeedARGlasses);
            Assert.IsTrue(arg.NeedARControllers);
        }

        [TestMethod]
        public void TestARGParamConstr_SetNeedGlasses() // конструктор с параметрами, св-во очков
        {
            AR_Game arg = new AR_Game("test", 1, 6, 1, "Телефон", 12, false, false);
            arg.NeedARGlasses = true;
            Assert.IsTrue(arg.NeedARGlasses);
        }

        [TestMethod]
        public void TestARGGMethodRandomInit() // случайное заполнение элементов
        {
            AR_Game arg1 = new AR_Game();
            arg1.RandomInit();
            Assert.IsNotNull(arg1.Name);
            Assert.IsTrue(arg1.MinCount >= 1 && arg1.MinCount <= 3);
            Assert.IsTrue(arg1.MaxCount >= 3 && arg1.MaxCount <= 10);
            Assert.IsTrue(arg1.id.number >= 1 && arg1.id.number <= 100);
            Assert.IsNotNull(arg1.NeedARControllers);
            Assert.IsNotNull(arg1.NeedARGlasses);
        }

        [TestMethod]
        public void TestARGGMethodEqualsObjects_SetNeedControllers() // одинаковые объекты, св-во контроллеров
        {
            AR_Game arg1 = new AR_Game("Test", 2, 7, 11, "Dev", 10, false, false);
            AR_Game arg2 = new AR_Game("Test", 2, 7, 11, "Dev", 10, false, true);
            arg1.NeedARControllers = true;
            Assert.IsTrue(arg1.Equals(arg2));
        }

        [TestMethod]
        public void TestARGMethodDifferentObjects() // разные объекты
        {
            AR_Game arg1 = new AR_Game("Test", 2, 7, 11, "Dev", 10, false, false);
            AR_Game arg2 = new AR_Game("Test", 2, 7, 11, "Dev", 10, false, true);
            Assert.IsFalse(arg1.Equals(arg2));
        }
        #endregion

        #region Class SortByMaxPlayers
        [TestMethod]
        public void TestMethodCompare_Null() // x, y - null 
        {
            SortByMaxPlayers comparer = new SortByMaxPlayers();
            Assert.AreEqual(-1, comparer.Compare(null, null));
        }

        [TestMethod]
        public void TestMethodCompare_NotType() // x, y - не объекты нужного класса
        {
            SortByMaxPlayers comparer = new SortByMaxPlayers();
            Assert.AreEqual(-1, comparer.Compare(new object(), new object()));
        }

        [TestMethod]
        public void TestMethodCompare_XMaxCountLessYMaxCount() // x < y
        {
            Game g1 = new Game { MaxCount = 6 };
            Game g2 = new Game { MaxCount = 8 };
            SortByMaxPlayers comparer = new SortByMaxPlayers();
            Assert.AreEqual(-1, comparer.Compare(g1, g2));
        }

        [TestMethod]
        public void TestMethodCompare_XMaxCountEqualYMaxCount() // x = y
        {
            Game g1 = new Game { MaxCount = 7 };
            Game g2 = new Game { MaxCount = 7 };
            SortByMaxPlayers comparer = new SortByMaxPlayers();
            Assert.AreEqual(0, comparer.Compare(g1, g2));
        }

        [TestMethod]
        public void TestMethodCompare_XMaxCountGreaterYMaxCount() // x > y
        {
            Game g1 = new Game { MaxCount = 12 };
            Game g2 = new Game { MaxCount = 4 };
            SortByMaxPlayers comparer = new SortByMaxPlayers();
            Assert.AreEqual(1, comparer.Compare(g1, g2));
        }
        #endregion
    }
}