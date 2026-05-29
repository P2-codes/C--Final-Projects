using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    internal class InventoryManager
    {
        ArrayList MainList;

        public InventoryManager() 
        {
            MainList = new ArrayList();
            ReadData();
        }
        private void ReadData()
        {
            string inputline;
            using (StreamReader reader = new StreamReader("InventoryData.txt"))
            {
                int itemNo;
                String name;
                int qty;
                double unitPrice;


                while (!reader.EndOfStream)
                {
                    string[] field;
                    inputline = reader.ReadLine();
                    field = inputline.Split('-');
                    itemNo = int.Parse(field[0]);
                    name = field[1];
                    qty = int.Parse(field[2]);
                    unitPrice = double.Parse(field[3]);

                    InventoryItem item = new InventoryItem(itemNo, name, qty, unitPrice);
                    MainList.Add(item);
                }
                reader.Close();
            }
		}
        public void Add(InventoryItem item,IndexList listOfindexes)
        {
            MainList.Add(item);
            Index newIndex = new Index(item.GetItemNo(), MainList.Count - 1);
            listOfindexes.AddIndex(newIndex);
        }
        public void Delete(int pos)
        {
            
            MainList.RemoveAt(pos);
        }
        public InventoryItem GetInventory(int pos)
        {
            
            if(pos>0 && pos<MainList.Count)
            {
                return (InventoryItem)MainList[pos];
            }
            else
            {
                return null;
            }
        }
        public void Display()
        {
            for(int i = 0; i < MainList.Count; i++)
            {
                ((InventoryItem)MainList[i]).DisplayItem();
            }
        }
        public void BuildIndex(IndexList addIndex)
        {
            for(int i=0;i<MainList.Count;i++)
            {
                InventoryItem item=(InventoryItem)MainList[i];
                Index index= new Index(item.GetItemNo(),i);
                addIndex.AddIndex(index);
            }
            addIndex.SortAsc();
        }
        public double InventoryValue(int qty,double unitPrice)
        {
            return qty*unitPrice;
        }
    }
}
