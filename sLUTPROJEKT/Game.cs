using System.Numerics;
using System.Runtime.CompilerServices;
using Raylib_cs;


class Game{


public static void WhileLoop(string scene, Player player, int points, Rectangle startGround, int highScore, List<Plattform> platforms, Rectangle startButton, int screenHeight, int screenWidth){

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