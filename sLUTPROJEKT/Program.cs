using System.Numerics;
using System.Runtime.CompilerServices;
using Raylib_cs;


internal class Program
{
    private static void Main(string[] args)
    {
        Raylib.InitWindow(500, 900, "Hello World");
        Raylib.SetTargetFPS(60);

        player player1 = new player();

        while (!Raylib.WindowShouldClose())
        {

            player1.Rörelse();


            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Blue);

            player1.Rita();

           
            Raylib.DrawRectangle(20, 20, 20, 20, Color.Black);
            Raylib.EndDrawing();
        }
    }
}

