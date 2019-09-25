using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBookLibrary
{
    public class BookDTO
    {
        private string id, name, publisher;
        private double price;

        public BookDTO()
        {
        }

        public BookDTO(string id, string name, string publisher, double price)
        {
            this.id = id;
            this.name = name;
            this.publisher = publisher;
            this.price = price;
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Publisher { get => publisher; set => publisher = value; }
        public double Price { get => price; set => price = value; }
    }
    public class BookDAO
    {
        private List<BookDTO> listbook = new List<BookDTO>();
        public bool Add(BookDTO dto)
        {
            bool check = false;
            foreach (BookDTO listdto in listbook)
            {
                if (listdto.Id.Equals(dto.Id))
                {
                    Console.WriteLine("ID is existed");
                    return check;
                }
            }
            listbook.Add(new BookDTO() { Id = dto.Id, Name = dto.Name, Publisher = dto.Publisher, Price = dto.Price });
            check = true;
            return check;
        }
        public bool Update(BookDTO dto)
        {
            bool check = false;
            foreach (BookDTO b in listbook)
            {
                if (b.Id == dto.Id)
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
        public bool Delete(BookDTO dto)
        {
            bool check = false;
            for (int i = 0; i < listbook.Count; i++)
            {
                if (dto.Id.Equals(listbook[i].Id))
                {
                    listbook.RemoveAt(i);
                    return check = true;
                }
            }
            return check;
        }
        public void Listall()
        {
            foreach (BookDTO dto in listbook)
            {
                Console.WriteLine("{0}    {1}    {2}    {3}", dto.Id, dto.Name, dto.Publisher, dto.Price);
            }
        }

        public void Findbyrankprice(double max, double min)
        {
            if (min > max)
            {
                double temp = min;
                min = max;
                max = temp;
            }
            foreach (BookDTO dto in listbook)
            {
                if (dto.Price > min && dto.Price < max)
                {
                    Console.WriteLine(dto.Id + " " + dto.Name + " " + dto.Publisher + " " + dto.Price);
                }
            }
        }
    }
}
