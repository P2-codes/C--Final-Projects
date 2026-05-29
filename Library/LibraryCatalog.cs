using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.Reflection;
using static System.Console;

namespace Library
{
    internal class LibraryCatalog
    {
        ArrayList BookList;
        int sortedState = 0;

        public LibraryCatalog(string File)
        {
            BookList = new ArrayList();
            ReadData(File);
            sortedState = 0;
        }
        public void AddBook(Book newBook)
        {
            BookList.Add(newBook);
        }
        public void DeleteBook(int pos)
        {
            BookList.RemoveAt(pos-1);
            
        }
        public void Display()
        {
            for(int x=0; x<BookList.Count; x++)
            {
                Book newBook= (Book)BookList[x];    
                newBook.DisplayBook();
            }
        }
        private void ReadData(string File)
        {
            const char DELIM = ',';
            string inputLine;
            string[] fields;
            int isbn,publicationYear;
            string title, author;

            StreamReader sr=new StreamReader(File);
            inputLine = sr.ReadLine();

            while (inputLine != null)
            {
                fields = inputLine.Split(DELIM);
                isbn = int.Parse(fields[0]);
                title = fields[1];
                author = fields[2];
                publicationYear = int.Parse(fields[3]);

                Book newBook=new Book(isbn,title,author,publicationYear);
                BookList.Add(newBook);
                inputLine = sr.ReadLine();
            }
            sr.Close();
        }
        public void Close()
        {
            WriteData();
        }
        private void WriteData()
        {
            StreamWriter sw = new StreamWriter("Output.txt");

            for(int x=0;x<BookList.Count;x++)
            {
                Book book = (Book)BookList[x];
                Write(book.getIsbn() + ",");
                Write(book.getTitle() + ",");
                Write(book.getAuthor() + ",");
                WriteLine(book.getPublicationYear());              
            }
            sw.Close();
        }

        private int linearSearch(int wantedisb)
        {
            int pos = -1;
            for(int i = 0; i < BookList.Count; i++)
            {
                Book current = (Book)BookList[i];
                if(current.getIsbn()==wantedisb)
                {
                    pos = i;
                }
            }
            return pos;
        }
        private int BinarySearch(int wantedisb)
        {
            int first=0;
            int last=BookList.Count-1;

            while(first <= last)
            {
                int mid=(first+last)/2;
                Book book = (Book)BookList[mid];

                if(book.getIsbn()==wantedisb)
                {
                    return mid;
                }
                else if(wantedisb.CompareTo(book.getIsbn())>0)
                {
                    last = mid-1;
                }
                else
                {
                    first = mid+1;
                }
            }
            return -1;
        }
		public int Find(int wanted)
		{
            int pos;
            if (sortedState == 1)
            {
                WriteLine("Using binary search");
                pos=BinarySearch(wanted);
                
            }
            else
            { 
				WriteLine("Using linear search");
				pos= linearSearch(wanted);
			}
            return pos+1;
		}
		public void BubbleSortAscISBN()
        {
            BubbleSortAsc();
            sortedState = 2;
        }
        public void SelectionSortAscAuthor()
        {
            SelectionSort();
            sortedState = 0;
        }
        public void InsertionSort()
        {
            InsertionSortPub();
            sortedState = 1;
        }
		private void swop(int swop1, int swop2)
		{
			Book book = (Book)BookList[swop2];
			BookList[swop2] = BookList[swop1];
			BookList[swop1] = book;
		}

		public void BubbleSortAsc()
		{
			for (int pass = 1; pass < BookList.Count; pass++)
			{
				for (int compare = 1; compare <= BookList.Count-1; compare++)
				{
					Book first = (Book)BookList[compare - 1];
					Book second = (Book)BookList[compare];

					if (first.getIsbn() > second.getIsbn())
					{
						swop(compare - 1, compare);
					}
				}
			}
		}
		private void SelectionSort()
		{
			int minPos = 0;

			for (int pass = 1; pass < BookList.Count; pass++)
			{
				for (int x = pass; x < BookList.Count; x++)
				{
					Book first = (Book)BookList[x];
					Book second = (Book)BookList[minPos];

					if (first.getAuthor().CompareTo(second.getAuthor()) < 0)
					{
						minPos = x;
					}
				}
				swop(pass - 1, minPos);
				minPos = pass;
			}
		}
		private void InsertionSortPub()
		{
			for (int pass = 1; pass < BookList.Count; pass++)
			{
				Book book = (Book)BookList[pass];
				int currentPos = pass - 1;
				Book currentbook = (Book)BookList[currentPos];

				while ((currentPos != -1) && (book.getPublicationYear() < currentbook.getPublicationYear()))
				{
					currentPos--;
					if (currentPos != -1)
					{
                        currentbook = (Book)BookList[currentPos];
					}
				}
				BookList.RemoveAt(pass);
				BookList.Insert(currentPos + 1,book);
			}
		}
        public Book GetBook(int pos)
        {
            pos--;
            if(pos>=0)
            {
                return (Book)BookList[pos]; 
            }
            else
            {
                return null;    
            }
        }
	}
}
