using System;

class Program
{
    static void Main(string[] args)
    {
        List <Shape> shapes= new List <Shape> ();

        Square square = new Square("Blue", 10);
        shapes.Add(square);

        Rectangle rectangle = new Rectangle("Green", 2, 3);
        shapes.Add(rectangle);

        Circle circle = new Circle("Yellow", 4);
        shapes.Add(circle);

        foreach (Shape shape in shapes) {
            string color = shape.GetColor();
            double area = shape.GetArea();

            Console.WriteLine($"The {color} shape has an area of {area}.");
        }
    }
}