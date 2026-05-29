using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Library
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LibraryCatalog catalogue = new LibraryCatalog("BookData.txt");

            DisplayOptions();
            int choice = int.Parse(ReadLine());
            ProcessOption(catalogue, choice);
            while (choice != 8)
            {
                DisplayOptions();
                choice = int.Parse(ReadLine());
                ProcessOption(catalogue, choice);
            }
            ReadLine();
        }

        static void DisplayOptions()
        {
            WriteLine("Choose one of the following options: ");
            WriteLine("1. Add a new book");
            WriteLine("2. Delete a book");
            WriteLine("3. Display book details");
            WriteLine("4. List all books");
            WriteLine("5. Sort catalogue in ascending order of ISBN number, then display list");
            WriteLine("6. Sort catalogue in ascending order of Author then display list");
            WriteLine("7. Sort catalogue in ascending order of publication year, then display list");
            WriteLine("8. Save data and quit");
            Write("Choice: ");
        }

        static void ProcessOption(LibraryCatalog catalogue, int choice)
        {
            WriteLine();

            switch (choice)
            {
                case 1:
                    AddBook(catalogue);
                    WriteLine();
                    break;
                case 2:
                    DeleteBook(catalogue);
                    WriteLine();
                    break;
                case 3:
                    DisplayBookDetail(catalogue);
                    WriteLine();
                    break;
                case 4:
                    catalogue.Display();
                    WriteLine();
                    break;
                case 5:
                    catalogue.BubbleSortAscISBN();
                    catalogue.Display();
                    WriteLine();
                    break;
                case 6:
                    catalogue.SelectionSortAscAuthor();
                    catalogue.Display();
                    WriteLine();
                    break;
                case 7:
                    catalogue.InsertionSort();
                    catalogue.Display();
                    WriteLine();
                    break;
                default:
                    WriteLine("Goodbye, the data will now be written to the text file");
                    catalogue.Close();
                    break;
            }
        }
        static void AddBook(LibraryCatalog catalogue)
        {
            Write("Enter ISBN number:");
            int isbn = int.Parse(ReadLine());
            Write("Enter book title:");
            string title=ReadLine();
			Write("Enter book author:");
			string author = ReadLine();
            Write("Enter publicaion year:");
            int pubYear=int.Parse(ReadLine());

            Book book=new Book(isbn, title, author,pubYear);
            catalogue.AddBook(book);
		}

        static void DeleteBook(LibraryCatalog catalogue)
        {
            Write("Enter the ISBN number for book to be deleted:");
            int isbn = int.Parse(ReadLine());

            int pos=catalogue.Find(isbn);
            if(pos>=1)
            {
                catalogue.DeleteBook(pos);
            }
            else
            { //invalid
             }
        }
        static void DisplayBookDetail(LibraryCatalog catalogue)
        {
            Write("Enter ISBN number to search: ");
            int isbn = int.Parse(ReadLine());

            int pos=catalogue.Find(isbn);

            if (pos>=1)
            {
                Book book = (Book)catalogue.GetBook(pos);
                book.DisplayBook();
            }
            else
            {
                //
            }

        }

           
    }
}
