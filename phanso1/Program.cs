using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace phanso1
{
    class Program
    {
        static void Main(string[] args)
        {
            //nhap phan so thu 1
            Console.WriteLine("Nhap tu cua phan so 1: ");
            int tu1 = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap mau cua phan so 1: ");
            int mau1 = int.Parse(Console.ReadLine());

            //nhap phan so thu 2
            Console.WriteLine("Nhap tu cua phan so 2: ");
             int tu2 = int.Parse(Console.ReadLine());
            Console.WriteLine("Nhap mau cua phan so 2: ");
            int mau2 = int.Parse(Console.ReadLine());

            //cong phan so
            cong c = new cong();
             c.printss(tu1,tu2,mau1,mau2);

            Console.ReadLine();
        }
    }
    class cong {
        public void printss( int tu1, int tu2, int mau1, int mau2)
        {
            int tuc = tu1 * mau2 + mau1 * tu2;
            int mauc = mau1 * mau2;
            Console.WriteLine("Ket qua phep cong: " + tuc + "/" + mauc);
        }
    }
}
