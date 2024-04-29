using System.Numerics;
using System.Runtime.CompilerServices;
using Raylib_cs;

public class Plattform
{
    static Random random = new Random();

    public Rectangle size = new Rectangle();

    public Plattform(int height)
    {
        size = new(random.Next(0, 500 - 80), height, 80, 5);
    }

    public void Draw()
    {
        Raylib.DrawRectangleRec(size, Color.Green);
    }

}