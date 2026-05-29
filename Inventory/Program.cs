using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Inventory
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InventoryManager inventory = new InventoryManager();
            IndexList nrIndexList = new IndexList();
            inventory.BuildIndex(nrIndexList);
            DisplayOptions();
            int choice = int.Parse(ReadLine());
            
            ProcessOption(inventory, nrIndexList, choice);
            while (choice != 6)
            {
                DisplayOptions();
                choice = int.Parse(ReadLine());
                ProcessOption(inventory, nrIndexList, choice);
            }
            ReadLine();
        }

        static void DisplayOptions()
        {
            WriteLine("Choose one of the following options: ");
            WriteLine("1. Add a new inventory item");
            WriteLine("2. Delete an inventory item");
            WriteLine("3. Update inventory item quantity");
            WriteLine("4. Calculate inventory value");
            WriteLine("5. Display all inventory items");
            WriteLine("6. Quit");
            Write("Choice: ");
        }

        static void ProcessOption(InventoryManager inventory, IndexList nrIndexList, int choice)
        {
            WriteLine();

            switch (choice)
            {
                case 1:
                    AddInventoryItem(inventory, nrIndexList);
                    WriteLine();
                    break;
                case 2:
                    DeleteInventoryItem(inventory, nrIndexList);
                    WriteLine();
                    break;
                case 3:
                    UpdateQuantity(inventory, nrIndexList);
                    WriteLine();
                    break;
                case 4:
                    CalculateInventory(inventory,nrIndexList);
                    WriteLine();
                    break;
                case 5:                   
                    inventory.Display();
                    //add method call(s) here
                    WriteLine();
                    break;
                default:
                    WriteLine("Goodbye");
                    break;
            }
        }
        static void AddInventoryItem(InventoryManager inventory, IndexList nrIndexList)
        {
            Write("Enter the item number: ");
            int itemNo=int.Parse(ReadLine());
            Write("Enter the inventory name: ");
            string name=ReadLine();
            Write("Enter the quantity amount: ");
            int qty=int.Parse(ReadLine());
            Write("Enter the unit price: ");
            double unitPrice=double.Parse(ReadLine());

            InventoryItem inventory1=new InventoryItem(itemNo,name,qty,unitPrice);
            inventory.Add(inventory1,nrIndexList);
            WriteLine("Inventory added successfully!.");
        }

        static void DeleteInventoryItem(InventoryManager inventory, IndexList nrIndexList)
        {
            Write("Enter the item number of inventory to be deleted: ");
            int itemNo=int.Parse(ReadLine());

            int pos=nrIndexList.FindIndex(itemNo);
            if(pos!=-1)
            {
                int newPos=nrIndexList.GetIndex(pos).GetPosition();
                nrIndexList.DeleteIndexObj(pos, newPos);
                inventory.Delete(newPos);
                WriteLine("Inventory deleted successfully from position {0} indexlis and {1} in MainList!.",pos,newPos);
            }
            else
            {
                WriteLine("Car not found");
            }
        }
        
        static void UpdateQuantity(InventoryManager inventory, IndexList nrIndexList)
        {
            Write("Enter the inventory number of item to be updated.");
            int itemNo = int.Parse(ReadLine());
            int pos = nrIndexList.FindIndex(itemNo);
            if(pos!=-1)
            {
                WriteLine("Enter the quantity value from position {0} : ",pos);
                int qty=int.Parse(ReadLine());
                int newPos=nrIndexList.GetIndex(pos).GetPosition();
                InventoryItem item=inventory.GetInventory(newPos);
                item.SetQty(qty);
                WriteLine("Updated successfully!.");
            }
            else
            {
                WriteLine("Inventory number not found.");
            }
        }
        static void CalculateInventory(InventoryManager inventory,IndexList nrIndexList)
        {
            Write("Enter the inventory number you want to calculate: ");
            int itemNo=int.Parse(ReadLine());
            int pos = nrIndexList.FindIndex(itemNo);

            if (pos != -1)
            { 
                int newPos=nrIndexList.GetIndex(pos).GetPosition();
                InventoryItem item=inventory.GetInventory(newPos);
                int x = item.GetQty();
                double y = item.GetUnitPrice();
                double z = inventory.InventoryValue(x, y);

                WriteLine("The inventory value of inventory number {0} is {1}", itemNo, z);
            }
			else
			{
				WriteLine("Inventory number not found.");
			}
		}
    }
}
