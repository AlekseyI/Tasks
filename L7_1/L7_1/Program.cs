using System;
using System.Collections.Generic;

namespace L7_1
{
    class Program
    {
        static void Main(string[] args)
        {

            // Реализуйте класс произвольной фигуры (треугольник, квадрат, круг), 
            // определите CompareTo<T>, сравнение производим по площади фигуры, затем
            // генерируйте 10 объектов и отсортируйте в порядке убывания.
            // IComparer реализовать пример

            var count = 10;
            var figures = new List<IFigure>(count);
            var rand = new Random();

            for (int i = 0; i < count; i++)
            {
                int figId = rand.Next(3);
                IFigure figure;

                if (figId == 0)
                {

                    figure = new Triangle(rand.Next(1, 10), rand.Next(1, 10));
                }
                else if (figId == 1)
                {
                    figure = new Quad(rand.Next(1, 10));
                }
                else
                {
                    figure = new Circle(rand.Next(1, 10));
                }

                figures.Add(figure);
            }

            figures.Sort(new FigureComparer());

            figures.ForEach((v) => Console.WriteLine(v));

            // Метод Sort по умолчанию работает только для наборов примитивных типов(int, string, double и др.), для остальных
            // нужно применять интерфейс IComparable
        }
    }
}
