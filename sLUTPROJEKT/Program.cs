using System.Numerics;
using System.Runtime.CompilerServices;
using Raylib_cs;

// Använder Program.cs som källa för variablar

int screenWidth = 500;
int screenHeight = 900;

Raylib.InitWindow(screenWidth, screenHeight, "Hello World");
Raylib.SetTargetFPS(120);


string scene = "start";
Vector2 buttonSize = new(400, 100);
Rectangle startButton = new Rectangle(screenWidth / 2 - buttonSize.X / 2, 600, buttonSize);

int points = 0;
int highScore = 0;


Player player = new Player();
Rectangle startGround = new Rectangle();
List<Plattform> platforms = new();


while (!Raylib.WindowShouldClose())
{
    Vector2 mouse = Raylib.GetMousePosition();

    Rectangle mouseRec = new Rectangle(mouse.X, mouse.Y, 1, 1);

    // ------------------------------------------------------------------------------------------
    // --------------------------------------***LOGIC***------------------------------------------
    // ------------------------------------------------------------------------------------------
    if (scene == "game")
    {

        player.Controls();

       (points, startGround, highScore) = GameScreen.Colision(player,platforms,points,highScore,startGround);


        // ------------------------------------------------------------------------------------------
        // --------------------------------------***LOSING***----------------------------------------
        // ------------------------------------------------------------------------------------------
        if (player.CharacterRec.Y > 900)
        {
            scene = "start";
        }


    }

    if (scene == "start")
    {
        // -------------------------------Reset---------------------------------------
        if (Raylib.CheckCollisionRecs(mouseRec, startButton) && Raylib.IsMouseButtonPressed(MouseButton.Left))
        {

           (points,scene,startGround) = StartScreen.Reset(points,platforms,screenWidth,screenHeight,startGround,player,scene);
        }
    }

    // ------------------------------------------------------------------------------------------
    // --------------------------------------***GRAFIC***----------------------------------------
    // ------------------------------------------------------------------------------------------
    Raylib.BeginDrawing();

    if (scene == "game")
    {
        GameScreen.DrawGameScreen(points,screenWidth,screenWidth,startGround,player,platforms);
    }

    if (scene == "start")
    {
        StartScreen.DrawStartScreen(highScore,startButton,screenHeight,screenWidth);
    }


    Raylib.EndDrawing();
}

