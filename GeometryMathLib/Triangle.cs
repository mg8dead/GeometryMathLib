using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryMathLib
{
    public class Triangle
    {
        private double SideA;
        private double SideB;
        public double MostLengthSide;
        public TriangleTypes Type { get; private set; }
        public enum TriangleTypes
        {
            Прямоугольный,
            Непрямоугольный
        }

        /// <summary>
        /// Создание треугольника
        /// </summary>
        /// <param name="sideA">Сторона A</param>
        /// <param name="sideB">Сторона B</param>
        /// <param name="sideC">Сторона C</param>
        public Triangle(double side1, double side2, double side3)
        {
            //проверка внесенных значений,
            //одна сторона не может быть больше суммы оставшихся двух
            if(side1 + side2 > side3 && side1 + side3 > side2 && side2 + side3 > side1)
            {
                //собираем элементы в массив
                double[] triangleSides = { side1, side2, side3 };
                //сортируем элементы,
                //последний элемент будет с самым большим значением
                Array.Sort(triangleSides);
                MostLengthSide = triangleSides[2];

                SideA = triangleSides[0];
                SideB = triangleSides[1];

                //по формуле проверям прямоугольный ли треугольник
                if (Math.Pow(MostLengthSide,2) == Math.Pow(SideA, 2) + Math.Pow(SideB,2))
                {
                    Type = TriangleTypes.Прямоугольный;
                }
                else
                {
                    Type = TriangleTypes.Непрямоугольный;
                }
            }
            else
            {
                throw new ArgumentException("Треугольник не существует");
            }
        }
        /// <summary>
        /// Вычисляет площадь заданного треугольника
        /// </summary>
        /// <returns></returns>
        public double GetArea()
        {
            //вычисляем половину периметра
            double HalfP = (SideA + SideB + MostLengthSide) / 2;
            //по формуле вычисляем площадь
            return Math.Sqrt(HalfP * (HalfP - SideA) * (HalfP - SideB) * (HalfP - MostLengthSide));
        }
    }
}