using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wuerfel
{
    public class Dice
    {
        public int Size { get; private set; }
        public List<int> Rolles { get; set; }

        public Dice(int size)
        {
            Size = size;
            Rolles = new List<int>();
        }

    }

}
