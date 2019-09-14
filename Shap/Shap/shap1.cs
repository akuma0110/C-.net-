using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shap
{
    abstract class shap1
    {
        public abstract double perimeter();
        public abstract double area(double weigth, double length);
    }
    
    class rectangular : shap1
    {
        double weigth;
        double length;

        public rectangular()
        {
        }

        public rectangular(double weigth, double length)
        {
            this.weigth = weigth;
            this.length = length;
        }

        public double Weigth { get => weigth; set => weigth = value; }
        public double Length { get => length; set => length = value; }

        public override double area(double weigth, double length)
        {
            return weigth * length;
        }

        public override double perimeter()
        {
            return (weigth + length) * 2;
        }
    }

}
