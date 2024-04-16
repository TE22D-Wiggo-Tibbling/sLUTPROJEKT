using System.Numerics;
using System.Runtime.CompilerServices;
using Raylib_cs;


int screenWidth = 500;
int screenHeight = 900;

Random random = new Random();

Raylib.InitWindow(screenWidth, screenHeight, "Hello World");
Raylib.SetTargetFPS(120);

string scene = "start";

Player player = new Player();


Rectangle startGround = new Rectangle();

int points = 0;
int pointsWidth = Raylib.MeasureText(points.ToString(), 50);
int highScore = 0;
int highScoreLength = Raylib.MeasureText("HighScore:" + highScore.ToString(), 50) / 2;

List<Plattform> platformar = new();



// ----------------------------------***start***-------------------------------------------

Vector2 buttonSize = new(400, 100);
Rectangle startButton = new Rectangle(screenWidth / 2 - buttonSize.X / 2, 600, buttonSize);
int startTextWidth = Raylib.MeasureText("start", 100) / 2;





while (!Raylib.WindowShouldClose())
{
    Vector2 mouse = Raylib.GetMousePosition();

    Rectangle mouseRec = new Rectangle(mouse.X, mouse.Y, 1, 1);


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
                if (points > highScore) highScore = points;
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
            Raylib.OpenURL("https://www.youtube.com/watch?v=4JzDttgdILQ");
        }


    }


    // ------------------------------------------------------------------------------------------
    // --------------------------------------***START***------------------------------------------
    // ------------------------------------------------------------------------------------------
    if (scene == "start")
    {
        if (Raylib.CheckCollisionRecs(mouseRec, startButton) && Raylib.IsMouseButtonPressed(MouseButton.Left))
        {


            // ------------------------------------------------------------------------------------------
            // --------------------------------------***RESET***-----------------------------------------
            // ------------------------------------------------------------------------------------------

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

            startGround = new(0, 850, screenWidth, screenHeight - 850);

            // --------------------------------------***PLAYER***----------------------------------------
            player.characterRec.X = screenWidth / 2 - player.characterRec.Width / 2;
            player.characterRec.Y = 750;


            scene = "game";
        }
    }



    // ------------------------------------------------------------------------------------------
    // --------------------------------------***GRAFIC***----------------------------------------
    // ------------------------------------------------------------------------------------------
    Raylib.BeginDrawing();

    if (scene == "game")
    {

        Raylib.ClearBackground(Color.Blue);


        Raylib.DrawText(points.ToString(), screenWidth / 2 - pointsWidth / 2, 120, 50, Color.Black);
        player.Rita();

        foreach (Plattform pos in platformar)
        {
            pos.rita();
        }

        Raylib.DrawRectangleRec(startGround, Color.Brown);

        // ----------------------Controls-----------------------------------

        if (Raylib.CheckCollisionRecs(player.characterRec, startGround))
        {
            Raylib.DrawText("SPACE to start", 50, 850, 25, Color.Black);
            Raylib.DrawText("Move with arrow keys", 50, 875, 25, Color.Black);
        }
    }

    if (scene == "start")
    {
        Raylib.ClearBackground(Color.Brown);


        Raylib.DrawText("HighScore:" + highScore.ToString(), screenWidth / 2 - highScoreLength, 100, 50, Color.Black);
        Raylib.DrawRectangleRec(startButton, Color.Red);
        Raylib.DrawText("start", screenWidth / 2 - startTextWidth, (int)startButton.Y, 100, Color.Black);

    }


    Raylib.EndDrawing();
}

