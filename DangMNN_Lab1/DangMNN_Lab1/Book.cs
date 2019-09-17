using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DangMNN_Lab1
{
    class Book
    {
        private List<BookDTO> listbook = new List<BookDTO>();
        public bool addBook(BookDTO dto)
        {
            bool check = false;
            foreach(BookDTO listdto in listbook)
            {
                if (listdto.Id.Equals(dto.Id))
                {
                    Console.WriteLine("ID is exíted");
                    return check;
                }
            }
            listbook.Add(new BookDTO() { Id = dto.Id, Name = dto.Name, Publisher = dto.Publisher, Price = dto.Price});
            check = true;
            return check;
        }
        public bool updateBook(BookDTO dto)
        {
            bool check = false;
            foreach(BookDTO b in listbook)
            {
                if (b.Id.Equals(dto.Id))
                {
                    b.Name = dto.Name;
                    b.Price = dto.Price;
                    b.Publisher = dto.Publisher;
                    check = true;
                    return check;
                }
            }
            return check;
        }
        public bool deleteBook(string id)
        {
            bool check = false;
            foreach (BookDTO lb in listbook)
            {
                if (lb.Id.Equals(id))
                {
                    listbook.Remove(lb.)
                }
            }
            return check;
        }
        public void listall()
        {

        }
    }
}
