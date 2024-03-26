using System.Numerics;
using System.Runtime.CompilerServices;
using Raylib_cs;


int screenWidth = 500;
int screenHeight = 900;

Random random = new Random();

Raylib.InitWindow(screenWidth, screenHeight, "Hello World");
Raylib.SetTargetFPS(120);

Player player = new Player();

int points = 0;

List<Plattform> platformar = new();

//Gör fem tärningar
for (int i = 800; i > -1000; i--)
{
    platformar.Add(new Plattform(i * -100));
}

for (int i = 0; i < screenHeight; i++)
{

}


while (!Raylib.WindowShouldClose())
{


    player.Rörelse();

    foreach (Plattform colision in platformar)
    {
        if (Raylib.CheckCollisionRecs(player.characterRec, colision.size) && player.movement.Y > 0 && player.characterRec.Y+player.characterRec.Height >colision.size.Y)
        {
            player.movement.Y = player.bounce;
            colision.size.X = 6000;
            points++;
        }
    }

    platformar.RemoveAll(p => p.size.X == 6000);



    if (player.characterRec.Y<500&&player.movement.Y<0)
    {
        foreach (Plattform flyt in platformar)
            {          
            flyt.size.Y -=player.movement.Y;
            }
    }

    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.Blue);

    Raylib.DrawText(points.ToString(),screenWidth/2,100,50,Color.Black);
    player.Rita();
    foreach (Plattform pos in platformar)
    {
        pos.rita();
    }


    Raylib.EndDrawing();
}


public class Plattform
{
    static Random random1 = new Random();

    public Rectangle size = new Rectangle();

    public Plattform(int nivå)
    {
        size = new(random1.Next(0, 500-80), nivå, 80, 5);
    }

    public void rita()
    {
        Raylib.DrawRectangleRec(size, Color.Green);
    }

}
