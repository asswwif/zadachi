using System;
using System.Collections.Generic;

namespace ShapesExample
{
    interface IShape
    {
        void Draw();
    }

    interface IColoredShape : IShape
    {
        void SetColor(string color);
    }

    class Circle : IColoredShape
    {
        public string Color { get; private set; }

        public Circle(string color)
        {
            SetColor(color);
        }

        public void SetColor(string color)
        {
            Color = color;
        }

        public void Draw()
        {
            Console.WriteLine($"Коло кольору: {Color}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<IShape> shapes = new List<IShape>
            {
                new Circle("Рожевий"),
                new Circle("Зелений"),
                new Circle("Синій"),
                new Circle("Жовтий")
            };

            foreach (IShape shape in shapes)
            {
                shape.Draw();
            }
        }
    }
}
