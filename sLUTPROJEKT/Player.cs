using System.Numerics;
using System.Runtime.CompilerServices;
using Raylib_cs;

public class Player
{
    public Vector2 Movement = new Vector2(0, 0.1f);

    private float Speed = 3;

    public float Gravity = 0.1f;

    public Rectangle CharacterRec = new Rectangle(250, 800, 50, 50);

    public float Bounce = -5;
    public void Controls()
    {
        // läser in vänster och höger knampp och ändrar movement beroende på vad man trycker
        Movement.X = Vector2.Zero.X;
        if (Raylib.IsKeyDown(KeyboardKey.Left))
        {
            Movement.X = -Speed;
        }
        else if (Raylib.IsKeyDown(KeyboardKey.Right))
        {
            Movement.X = Speed;
        }

        // Gravitation: lägger till movement ner så spelare börjar falla
        Movement.Y += Gravity;

        // flyttar spelare
        CharacterRec.X += Movement.X;
        CharacterRec.Y += Movement.Y;

        // När spelaren kommer förbi 490 stannar spelaren i mitten
        if (CharacterRec.Y < 490)
        {
            CharacterRec.Y -= Movement.Y;
        }
    }

    public void Draw()
    {
        Raylib.DrawRectangleRec(CharacterRec, Color.Black);
    }
}



