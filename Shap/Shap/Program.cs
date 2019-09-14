using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shap
{
    class Program
    {
        static void Main(string[] args)
        {
            rectangular r = new rectangular();
            r.area(2, 5);
            Console.WriteLine(r);
            Console.ReadLine();
        }
    }
}
