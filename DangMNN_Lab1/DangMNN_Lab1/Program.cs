using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DangMNN_Lab1
{
    class Program
    {
        private static int menu()
        {
            Console.Clear();
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
            while (true)
            {
                switch (menu())
                {
                    case 1:
                        Console.Clear();
                        //
                        Console.WriteLine("Enter ID: ");
                        string id = Console.ReadLine();
                        if (id == "")
                        {
                            Console.WriteLine("Id must not be null");
                            Console.ReadLine();
                            break;
                        }
                        //
                        Console.WriteLine("Enter name of book: ");
                        string name = Console.ReadLine();
                        if (name == "")
                        {
                            Console.WriteLine("Name must not be null");
                            Console.ReadLine();
                            break;
                        }
                        //
                        Console.WriteLine("Enter publisher: ");
                        string publisher = Console.ReadLine();
                        if (publisher == "")
                        {
                            Console.WriteLine("Publisher must not be null");
                            Console.ReadLine();
                            break;
                        }
                        //
                        Console.WriteLine("Enter Price: ");
                        string price = Console.ReadLine();
                        if (price == "")
                        {
                            Console.WriteLine("Price must not be null");
                            Console.ReadLine();
                            break;
                        }
                        //regular expression
                        Regex r = new Regex("[1-9]");
                        if(!r.IsMatch(price))
                        {
                            Console.WriteLine("Price must be number");
                            Console.ReadLine();
                            break;
                        }

                        BookDTO dto = new BookDTO(id, name, publisher, double.Parse(price));
                        if (b.addBook(dto))
                        {
                            Console.WriteLine("Add Success ^^");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Add Fail!!!");
                            Console.ReadLine();
                        }
                        break;
                    case 2:
                        Console.Clear();
                        //
                        Console.WriteLine("Enter ID: ");
                         id = Console.ReadLine();
                        if (id == "")
                        {
                            Console.WriteLine("Id must not be null");
                            Console.ReadLine();
                            break;
                        }
                        //
                        Console.WriteLine("Enter name of book: ");
                         name = Console.ReadLine();
                        if (name == "")
                        {
                            Console.WriteLine("Name must not be null");
                            Console.ReadLine();
                            break;
                        }
                        //
                        Console.WriteLine("Enter publisher: ");
                         publisher = Console.ReadLine();
                        if (publisher == "")
                        {
                            Console.WriteLine("Publisher must not be null");
                            Console.ReadLine();
                            break;
                        }
                        //
                        Console.WriteLine("Enter Price: ");
                         price = Console.ReadLine();
                        if (price == "")
                        {
                            Console.WriteLine("Price must not be null");
                            Console.ReadLine();
                            break;
                        }
                        //regular expression
                         r = new Regex("[1-9]");
                        if (!r.IsMatch(price))
                        {
                            Console.WriteLine("Price must be number");
                            Console.ReadLine();
                            break;
                        }

                         dto = new BookDTO(id, name, publisher, double.Parse(price));
                        if (b.updateBook(dto))
                        {
                            Console.WriteLine("Update Success ^^");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("Update Fail!!!");
                            Console.ReadLine();
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Enter ID: ");
                        id = Console.ReadLine();
                        if (id == "")
                        {
                            Console.WriteLine("Id must not be null");
                            Console.ReadLine();
                            break;
                        }
                        dto = new BookDTO(id,null,null,0);
                        Console.WriteLine("Do you want delete ID: " + id);
                        string q = Console.ReadLine();

                        if(q.ToLower().Equals("y"))
                        {
                            if (b.deleteBook(dto))
                            {
                                Console.WriteLine("Delete success ^^");
                                Console.ReadLine();
                            }
                            else
                            {
                                Console.WriteLine("Delete Fail!!!");
                                Console.ReadLine();
                            }
                        }
                        break;
                    case 4:
                        Console.Clear();
                        b.listall();
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Enter price min: ");
                        string min = Console.ReadLine();
                        if(min == "")
                        {
                            Console.WriteLine("You must be enter price min!!");
                            Console.ReadLine();
                            break;
                        }

                        Console.WriteLine("Enter price max: ");
                        string max = Console.ReadLine();
                        if (max == "")
                        {
                            Console.WriteLine("You must be enter price max!!");
                            Console.ReadLine();
                            break;
                        }

                        b.findbyrankprice(double.Parse(max), double.Parse(min));
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("Bye Bye ^^");
                        Console.ReadLine();
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Must be in 1 - 6");
                        Console.ReadLine();
                        break;

                }
            }
            Console.ReadLine();
        }
    }
}
