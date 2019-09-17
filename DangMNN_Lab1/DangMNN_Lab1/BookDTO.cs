using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DangMNN_Lab1
{
    class BookDTO
    {
        private String id, name, publisher, price;

        public BookDTO()
        {
        }

        public BookDTO(string id, string name , string publisher, string price)
        {
            this.id = id;
            this.name = name;
            this.publisher = publisher;
            this.price = price;
        }

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Publisher { get => publisher; set => publisher = value; }
        public string Price { get => price; set => price = value; }
        
        
    }
}
