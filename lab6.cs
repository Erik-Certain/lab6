
using System;

public interface IAreaCalculator
{
    double CalculateArea(double a, double b, double c);
}

public class RightTriangleAreaCalculator : IAreaCalculator
{
    public double CalculateArea(double a, double b, double c)
    {
        // Площадь прямоугольного треугольника
        return 0.5 * a * b;
    }
}

public class HeronTriangleAreaCalculator : IAreaCalculator
{
    public double CalculateArea(double a, double b, double c)
    {
        // Формула Герона
        double semiPerimeter = (a + b + c) / 2;
        return Math.Sqrt(semiPerimeter * (semiPerimeter - a) * (semiPerimeter - b) * (semiPerimeter - c));
    }
}

public class Triangle
{
    private IAreaCalculator _areaCalculator;

    public Triangle(IAreaCalculator areaCalculator)
    {
        _areaCalculator = areaCalculator;
    }

    public double GetArea(double a, double b, double c)
    {
        return _areaCalculator.CalculateArea(a, b, c);
    }
}

class Program
{
    static void Main()
    {
        double a = 3; // длина первого катета
        double b = 4; // длина второго катета
        double c = 5; // длина гипотенузы

        // Создаем треугольник с прямоугольным типом
        Triangle rightTriangle = new Triangle(new RightTriangleAreaCalculator());
        double rightArea = rightTriangle.GetArea(a, b, c);
        Console.WriteLine($"Площадь прямоугольного треугольника: {rightArea}");

        // Создаем треугольник с использованием формулы Герона
        Triangle heronTriangle = new Triangle(new HeronTriangleAreaCalculator());
        double heronArea = heronTriangle.GetArea(a, b, c);
        Console.WriteLine($"Площадь треугольника по формуле Герона: {heronArea}");
    }
}
