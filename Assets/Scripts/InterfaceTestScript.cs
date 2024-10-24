using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InterfaceTestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        /*
         * The Circle Class
         */
        Circle circle = new Circle(14.0); // Pass in the Diameter
        Debug.Log("The radius of the circle is: " + circle.CalculateRadius());
        Debug.Log("The area of the circle is: " + circle.CalculateArea());
        Debug.Log("The perimeter of the circle is: " + circle.CalculatePerimeter());

        /*
         * The Trapezium Class
         */
        Trapezium trapezium = new Trapezium(10, 10, null, 6, 10);
        Debug.Log("The area of the trapezium is: " + trapezium.CalculateArea());
        Debug.Log("The missing side of the trapezium is: " + trapezium.CalculateUnknownSides(10,10, 10));
        Debug.Log("The perimeter of the trapezium is: " + trapezium.CalculatePerimeter());

        /*
         * The Nonagon Class
         */
        Nonagon nonagon = new Nonagon(9, 6);
        Debug.Log("The area of a nonagon is: " + nonagon.CalculateArea());
        Debug.Log("The perimeter of a nonagon is: " + nonagon.CalculatePerimeter());
    }

}

public interface IShape
{
    double CalculateArea();
    double CalculatePerimeter();
   
}

public class Trapezium : IShape
{
    private double base_1, base_2, side_1, side_2, height; // Parallel Side 1,Parallel Side 2, Non Parallel Side 1, Non Parallel Side 2, The Height
    public Trapezium(double a, double b, double? c, double d, double h)
    {
        if (!c.HasValue) 
        {
            c = CalculateUnknownSides(a,b,h);
        }
        this.base_1 = a;
        this.base_2 = b;
        this.side_1 = c.Value;
        this.side_2 = d;
        this.height = h;
    }
    public double CalculateUnknownSides(double a, double b, double h)
    {
        return Math.Sqrt(((b - a) / 2) * ((b - a) / 2) + (h * h));
    }

    public double CalculateArea()
    {
        return Math.Round((base_1 + base_2) * height * 0.5);
    }

    public double CalculatePerimeter()
    {
        return Math.Round(base_1 + base_2 + side_1 + side_2);
    }
}

public class Circle : IShape
{
    public double Radius { get; set; }
    private double diameter;
    public Circle(double D)
    {
        this.diameter = D;
    }

    public double CalculateArea()
    {
        return Math.Round(Math.PI * this.Radius * this.Radius);
    }

    public double CalculateRadius()
    {
        this.Radius = this.diameter / 2;
        return this.Radius;
    }

    public double CalculatePerimeter()
    {
        return Math.Round(Math.PI * this.diameter) ;
    }
}

public class Nonagon : IShape
{
    int numberOfSides;
    double h;
    public Nonagon(int sides, double side)
    {
        this.numberOfSides = sides;
        this.h = side;
    }
    public double CalculateArea()
    {
        return Math.Round(((9.0 / 4.0) * h * h * (1 / Math.Tan(Math.PI / 9))));
    }

    public double CalculatePerimeter()
    {
        return 9 * h;
    }

    public int CalculateNumberOfSides()
    {
        return numberOfSides;
    }
}
