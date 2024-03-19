using System.Numerics;
using System.Runtime.CompilerServices;
using Raylib_cs;


        int screenWidth = 500;
        int screenHeight = 900;

        Random random = new Random();

        Raylib.InitWindow(screenWidth, screenHeight, "Hello World");
        Raylib.SetTargetFPS(60);

        Player player = new Player();

        Plattform plattform = new Plattform();

        for (int i = 0; i < screenHeight; i++)
        {

        }


        while (!Raylib.WindowShouldClose())
        {
        plattform.skap();   
            player.Rörelse();
           if( Raylib.CheckCollisionRecs(player.characterRec,plattform.size)&&player.movement.Y>0){
            player.movement.Y = player.bounce;
           }

            Raylib.BeginDrawing();
            Raylib.ClearBackground(Color.Blue);

            player.Rita();
            plattform.rita();

           
            Raylib.EndDrawing();
        }


public class Plattform
{
    static Random random1 = new Random();

     public Rectangle size = new Rectangle();
    
    public void skap(){

    for (int i = 800; i < 0; i--)
    {
     size = new(random1.Next(0,500),800,80,5);
    }
    }

    public void rita(){
            Raylib.DrawRectangleRec(size, Color.Green);
    }
    
}
