using System.Numerics;
using System.Runtime.CompilerServices;
using Raylib_cs;


int screenWidth = 500;
int screenHeight = 900;

Random random = new Random();

Raylib.InitWindow(screenWidth, screenHeight, "Hello World");
Raylib.SetTargetFPS(120);

string scene = "game";

Player player = new Player();


Rectangle startGround = new Rectangle();

int points = 0;

List<Plattform> platformar = new();



// ----------------------------------***start***-------------------------------------------
Vector2 startButtonSize = new(400,300);
Rectangle startButton = new Rectangle(600,screenWidth/2-startButtonSize.Y/2,startButtonSize);



while (!Raylib.WindowShouldClose())
{

    Vector2 mouse = Raylib.GetMousePosition();

    // ------------------------------------------------------------------------------------------
    // --------------------------------------***GAME***------------------------------------------
    // ------------------------------------------------------------------------------------------
    if (scene == "game")
    {

        player.Rörelse();

        foreach (Plattform colision in platformar)
        {
            if (Raylib.CheckCollisionRecs(player.characterRec, colision.size) && player.movement.Y > 0 && player.characterRec.Y + player.characterRec.Height > colision.size.Y)
            {
                player.movement.Y = player.bounce;
                colision.size.X = 6000;
                points++;
            }
        }

        if (Raylib.CheckCollisionRecs(player.characterRec, startGround))
        {
            player.movement.Y = 0;
            player.gravity = 0;

            if (Raylib.IsKeyPressed(KeyboardKey.Space))
            {
                player.movement.Y = -12.5f;
                player.gravity = 0.1f;
            }
        }

        platformar.RemoveAll(p => p.size.X == 6000);



        if (player.characterRec.Y < 500 && player.movement.Y < 0)
        {
            foreach (Plattform flyt in platformar)
            {
                flyt.size.Y -= player.movement.Y;
            }
            startGround.Y -= player.movement.Y;
        }


        // ------------------------------------------------------------------------------------------
        // --------------------------------------***LOSING***----------------------------------------
        // ------------------------------------------------------------------------------------------
        if (player.characterRec.Y > 900)
        {
            scene = "start";
        }
    }

    // ------------------------------------------------------------------------------------------
    // --------------------------------------***START***------------------------------------------
    // ------------------------------------------------------------------------------------------
    if (scene == "start")
    {



        // ------------------------------------------------------------------------------------------
        // --------------------------------------***RESET***------------------------------------------
        // ------------------------------------------------------------------------------------------
        if (Raylib.IsKeyPressed(KeyboardKey.One))
        {

            scene = "game";


            // -----------------------------------------***POINTS***-------------------------------------
            points = 0;

            // ----------------------------------------***PLATFORMAR***----------------------------------
            platformar.Clear();
            //Gör fem platformar
            for (int i = -1; i < 1000; i++)
            {
                platformar.Add(new Plattform(i * -100));
            }
            platformar[0].size.X = screenWidth / 2 - platformar[0].size.Width / 2;

            // ------------------------------------------***STARTGROUND***-------------------------------
            startGround = new Rectangle(0, 850, screenWidth, 50);


            // --------------------------------------***PLAYER***----------------------------------------
            player.characterRec.X = screenWidth / 2 - player.characterRec.Width / 2;
            player.characterRec.Y = 700;

        }
    }



    Raylib.BeginDrawing();

    if (scene == "game")
    {

        Raylib.ClearBackground(Color.Blue);

        Raylib.DrawText(mouse.ToString(),300,500,70,Color.Black);

        int pointsWidth = Raylib.MeasureText(points.ToString(), 50);
        Raylib.DrawText(points.ToString(), screenWidth / 2 - pointsWidth / 2, 100, 50, Color.Black);
        player.Rita();

        foreach (Plattform pos in platformar)
        {
            pos.rita();
        }

        Raylib.DrawRectangleRec(startGround, Color.Brown);
    }

    if (scene == "start")
    {
        Raylib.ClearBackground(Color.Red);

        Raylib.DrawRectangleRec(startButton,Color.Blank);
    }

    Raylib.EndDrawing();
}


public class Plattform
{
    static Random random1 = new Random();

    public Rectangle size = new Rectangle();

    public Plattform(int nivå)
    {
        size = new(random1.Next(0, 500 - 80), nivå, 80, 5);
    }

    public void rita()
    {
        Raylib.DrawRectangleRec(size, Color.Green);
    }

}
