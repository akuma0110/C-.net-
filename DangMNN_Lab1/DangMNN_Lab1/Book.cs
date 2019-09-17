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
        private List<BookDTO> list = new List<BookDTO>();
        private List<String> list1 = new List<string>();
        public void addBook(BookDTO dto)
        {
            //add theo kiểu truyền thống
            
            list.Add(new BookDTO() { Id = dto.Id,  Name = dto.Name, Publisher = dto.Publisher, Price = dto.Price});
            
            //add theo kiểu hashmap:  status:  quá nhiều công đoạn nên add theo kiểu truyền thống
        }
        public void updateBook(BookDTO dto)
        {

        }
        public void deleteBook(BookDTO dto)
        {
            //xóa theo ID --> chuyển qua dùng hashmap
            //xóa theo stt
        }
    }
}
