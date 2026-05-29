using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    internal class Index
    {
        int itemNo;
        int position;

        public Index(int itemNo, int position)
        {
            this.itemNo = itemNo;
            this.position = position;
        }

        public int GetItemNo()
        {
            return itemNo;
        }

        public int GetPosition()
        {
            return position;
        }
        public void SetPosition(int position)
        {
            this.position = position;
        }
        public void DisplayNrIndex()
        {
            Console.WriteLine("{0}, {1}", itemNo, position);
        }
    }
}
