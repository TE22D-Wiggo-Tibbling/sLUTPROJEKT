using System.Numerics;
using System.Runtime.CompilerServices;
using Raylib_cs;

public class Player
{

    public Vector2 movement = new Vector2(0, 0);

    private float speed = 6;

    private float gravity = 0.35f;

    public Rectangle characterRec = new Rectangle(250, 459, 50, 50);

    public float bounce = -13;
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

        characterRec.X += movement.X;
        characterRec.Y += movement.Y;

        movement.Y += gravity;

        if (characterRec.Y > 900)
        {
            movement.Y = bounce;
        }

        if(Raylib.IsKeyDown(KeyboardKey.W)){
            bounce--;
        }
        if(Raylib.IsKeyDown(KeyboardKey.S)){
            bounce++;
        }


    }

    public void Rita()
    {
        Raylib.DrawRectangleRec(characterRec, Color.Black);
    }
}