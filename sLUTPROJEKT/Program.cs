using System.Numerics;
using System.Runtime.CompilerServices;
using Raylib_cs;


        int screenWidth = 500;
        int screenHeight = 900;

        Raylib.InitWindow(screenWidth, screenHeight, "Hello World");
        Raylib.SetTargetFPS(60);

        Player player = new Player();


        Rectangle platform = new Rectangle(screenWidth/2,800,80,5);


        while (!Raylib.WindowShouldClose())
        {

            player.Rörelse();
           if( Raylib.CheckCollisionRecs(player.characterRec,platform)&&player.movement.Y>0){
            player.movement.Y = player.bounce;
           }

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Blue);

            player.Rita();

           
            Raylib.DrawRectangleRec(platform, Color.Green);
            Raylib.EndDrawing();
        }


public class Plattform
{
    
}
