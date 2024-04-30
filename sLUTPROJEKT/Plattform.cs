using System.Numerics;
using System.Runtime.CompilerServices;
using Raylib_cs;

public class Plattform
{
    static Random random = new Random();

    public Rectangle Size = new Rectangle();

    public Plattform(int Height)
    {   
        // Platformens position ändras med höjden som är i i en forloop 
        Size = new(random.Next(0, 500 - 80), Height, 80, 5);
    }

    public void Draw()
    {
        Raylib.DrawRectangleRec(Size, Color.Green);
    }

}