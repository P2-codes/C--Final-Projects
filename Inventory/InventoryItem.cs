using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    internal class InventoryItem
    {
        int itemNo;
        String name;
        int qty;
        double unitPrice;

        public InventoryItem(int num, String name, int qty, double price)
        {
            itemNo = num;
            this.name = name;
            this.qty = qty;
            unitPrice = price;
        }

        public void DisplayItem()
        {
            Console.WriteLine("{0}, {1}, quantity in stock: {2}, unit price: {3}", itemNo, name, qty, unitPrice);
        }

        public int GetItemNo()
        {
            return itemNo;
        }
        public String GetName() 
        {
            return name;
        }

        public int GetQty() 
        {
            return qty;
        }

        public double GetUnitPrice()
        {
            return unitPrice;
        }

        public void SetQty(int quantity) 
        { 
            this.qty = quantity;
        }
    }
}
