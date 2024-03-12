using System.Numerics;
using System.Runtime.CompilerServices;
using Raylib_cs;

public class player
{



    private Vector2 movement = new Vector2(0, 0);


    private float gravity = 0.35f;

    Rectangle characterRec = new Rectangle(250, 459, 50, 50);

    public void Rörelse()
    {
        movement.X = Vector2.Zero.X;
        if (Raylib.IsKeyDown(KeyboardKey.Left))
        {
            movement.X = -1;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.Right))
        {
            movement.X = 1;
        }

        characterRec.X += movement.X;
        characterRec.Y += movement.Y;

        movement.Y += gravity;

        if (characterRec.Y > 900)
        {
            movement.Y = -13;
        }
    }

    public void Rita()
    {
        Raylib.DrawRectangleRec(characterRec, Color.Black);
    }
}