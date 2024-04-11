using System.Numerics;
using System.Runtime.CompilerServices;
using Raylib_cs;

public class Plattform
{
    static Random random1 = new Random();

    public Rectangle size = new Rectangle();

    public Plattform(int nivå)
    {
        size = new(random1.Next(0, 500 - 80), nivå, 80, 5);
    }

    public void rita()
    {
        Raylib.DrawRectangleRec(size, Color.Green);
    }

}