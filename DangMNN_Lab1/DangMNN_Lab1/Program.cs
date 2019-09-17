using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DangMNN_Lab1
{
    class Program
    {
        static void Main(string[] args)
        {
            List<BookDTO> test = new List<BookDTO>();
            test.Add(new BookDTO() { Id = "1", Name = "Hacking for Dummies", Publisher = "abc", Price = "2.3" });
            test.Add(new BookDTO() { Id = "2", Name = "abc.xyz", Publisher = "abc", Price = "2.3" });

            foreach (BookDTO dto in test)
            {
                if (dto.Id.Equals("2"))
                {
                    test.Remove(new BookDTO() { Id = "2", })
                }
            }
            Console.WriteLine("thanh cong");
            Console.ReadLine();
        }
    }
}
