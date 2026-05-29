using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory
{
    internal class IndexList
    {
        ArrayList itemNoIndexList;
        int sortedState = 0;
        public IndexList()
        {
            itemNoIndexList = new ArrayList();
        }
        public void AddIndex(Index addIndex)
        {
            if(sortedState == 0)
            {
                itemNoIndexList.Add(addIndex);
            }
            else
            {
                insertSorted(addIndex, itemNoIndexList.Count - 1);
            }
        }
        public void insertSorted(Index addIndex,int Last)
        {
            int pos = 0;
            bool found = false;

            while(pos<Last&&!found)
            {
                if (addIndex.GetItemNo() < ((Index)itemNoIndexList[pos]).GetItemNo())
                {
                    found = true;
                }
                else
                {
                    pos++;
                }
            }
            itemNoIndexList.Insert(pos, addIndex);
        }
        public void DeleteIndexObj(int pos1,int pos2)
        {
			pos1--;

			itemNoIndexList.RemoveAt(pos1);

			for (int x = 0; x < itemNoIndexList.Count; x++)
			{
				Index temp = (Index)itemNoIndexList[x];

				if (temp.GetPosition() > pos2)
				{
					temp.SetPosition(temp.GetPosition() - 1);
				}
			}
		}
		public int FindIndex(int wantedItemNo)
		{
				return BinarySearch(wantedItemNo) + 1;
		}
        private int BinarySearch(int wantedItemNo)
        {
			 int first = 0;
			 int last=itemNoIndexList.Count-1;

			 while(first < last)
			 {
				 int mid=(first+last)/2;
				 Index index = (Index)itemNoIndexList[mid];

				 if(index.GetItemNo()==wantedItemNo)
				 {
					 return mid;
				 }
				 else if(index.GetItemNo()<wantedItemNo)
				 {
					 first = mid+1;
				 }
				 else
				 {
					 last = mid-1;
				 }

			 }
			 return -1;
			
		}
		public Index GetIndex(int pos)
        {
            pos--;
            if(pos >=0 && pos < itemNoIndexList.Count)
            {
                return (Index)itemNoIndexList[pos];
            }
            else
            {
                return null;
            }
        }
        public void SortAsc()
        {
            InsertionSort();
            sortedState = 1;
        }
        private void InsertionSort()
        {

			for (int x = 1; x < itemNoIndexList.Count; x++)
			{
				Index newOne = (Index)itemNoIndexList[x];
				int curPos = x - 1;
				Index currentOne = (Index)itemNoIndexList[curPos];

				while ((curPos != -1) && (newOne.GetItemNo() < currentOne.GetItemNo()))
				{
					curPos--;
					if (curPos != -1)
					{
						currentOne = (Index)itemNoIndexList[curPos];
					}
				}
				itemNoIndexList.RemoveAt(x);
				itemNoIndexList.Insert(curPos + 1, newOne);

			}
		}
    }
}
