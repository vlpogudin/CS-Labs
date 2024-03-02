using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
{
    public class SortByMaxPlayers : IComparer
    {
        public int Compare(object? x, object? y)
        {
            if (x == null || y == null) return -1;
            if (x is not Game || y is not Game) return -1;
            Game g1 = x as Game;
            Game g2 = y as Game;
            if (g1.MaxCount < g2.MaxCount) return -1;
            else if (g1.MaxCount == g2.MaxCount) return 0;
            else return 1;
        }
    }
}
