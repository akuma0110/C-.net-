using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DangMNN_Lab1
{
    class Program
    {
        private static int menu()
        {
            Console.WriteLine("1. Add new book");
            Console.WriteLine("2. Update a book");
            Console.WriteLine("3. Delete a book");
            Console.WriteLine("4. List all books");
            Console.WriteLine("5. List books of which price is in given range");
            Console.WriteLine("6. Quit");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Choice: ");
            int c = int.Parse(Console.ReadLine());
            return c;
        }
        static void Main(string[] args)
        {
            Book b = new Book();
            switch (menu())
            {
                case 1:
                    
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;

            }
            Console.ReadLine();
        }
    }
}
