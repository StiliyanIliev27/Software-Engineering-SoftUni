using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P03.Shapes
{
    internal class Rectangle : Shape
    {
        private double height;
        private double width;
        public Rectangle(double height, double width)
        {
            this.height = height;
            this.width = width;
        }
      //  public int MyProperty { get; set; }
        public override double CalculateArea()
        {
            return height * width;
        }
        public override double CalculatePerimeter()
        {
            return (2 * height) + (2 * width);
        }
    }
}
