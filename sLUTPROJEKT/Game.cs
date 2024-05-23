using System.Numerics;
using System.Runtime.CompilerServices;
using Raylib_cs;


class Game{
static int screenWidth = 500;
static int screenHeight = 900;



static string scene = "start";
static Vector2 buttonSize = new(400, 100);
static Rectangle startButton = new Rectangle(screenWidth / 2 - buttonSize.X / 2, 600, buttonSize);

static int points = 0;
static int highScore = 0;


static Player player = new Player();
static Rectangle startGround = new Rectangle();

// Har lista för att jag vill kunna ändra på den under kodens gång. Med aray skulle det inte gå :)
static List<Plattform> platforms = new();

public static void WhileLoop(){

Raylib.InitWindow(screenWidth, screenHeight, "Hello World");
Raylib.SetTargetFPS(120);

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

        (points, startGround, highScore) = GameScreen.Colision(player, platforms, points, highScore, startGround);

        // Förlust
        if (player.CharacterRec.Y > 900)
        {
            scene = "start";
        }


    }

   else if (scene == "start")
    {
        // -------------------------------Reset---------------------------------------
        if (Raylib.CheckCollisionRecs(mouseRec, startButton) && Raylib.IsMouseButtonPressed(MouseButton.Left))
        {

            (points, scene, startGround) = StartScreen.Reset(points, platforms, screenWidth, screenHeight, startGround, player, scene);
        }
    }

    // ------------------------------------------------------------------------------------------
    // --------------------------------------***GRAFIC***----------------------------------------
    // ------------------------------------------------------------------------------------------
    Raylib.BeginDrawing();

    if (scene == "game")
    {
        GameScreen.DrawGameScreen(points, screenWidth, screenWidth, startGround, player, platforms);
    }

    else if (scene == "start")
    {
        StartScreen.DrawStartScreen(highScore, startButton, screenHeight, screenWidth);
    }


    Raylib.EndDrawing();
}

}
}