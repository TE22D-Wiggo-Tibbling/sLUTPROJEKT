using System.Numerics;
using System.Runtime.CompilerServices;
using Raylib_cs;

public class Player
{

    public Vector2 movement = new Vector2(0, 0.1f);

    private float speed = 3;

    public float gravity = 0.1f;

    public Rectangle characterRec = new Rectangle(250, 800, 50, 50);

    public float bounce = -5;
    public void Rörelse()
    {
        movement.X = Vector2.Zero.X;
        if (Raylib.IsKeyDown(KeyboardKey.Left))
        {
            movement.X = -speed;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.Right))
        {
            movement.X = speed;
        }


        movement.Y += gravity;

        // if (characterRec.Y > 900)
        // {
        //     movement.Y = bounce;
        // }

        characterRec.X += movement.X;
        characterRec.Y += movement.Y;

        if (characterRec.Y < 490)
        {
            characterRec.Y -= movement.Y;
        }
    }

    public void Rita()
    {
        Raylib.DrawRectangleRec(characterRec, Color.Black);
    }
}



