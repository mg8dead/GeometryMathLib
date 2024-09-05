using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryMathLib
{
    public class Circle
    {
        private double Radius;
        private float p = 3.14f;
        /// <summary>
        /// Создание круга
        /// </summary>
        /// <param name="radius"></param>
        public Circle(double radius)
        {
            Radius = radius;
        }
        /// <summary>
        /// Вычисляет площадь заданного круга
        /// </summary>
        /// <returns></returns>
        public double GetArea()
        {
            return p * Math.Pow(Radius, 2);
        }
    }
}