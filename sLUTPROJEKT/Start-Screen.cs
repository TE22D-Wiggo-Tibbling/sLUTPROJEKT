using System.Numerics;
using System.Runtime.CompilerServices;
using Raylib_cs;

public class StartScreen
{
    public static void DrawStartScreen(int highScore, Rectangle startButton, int screenHeight, int screenWidth)
    {
        Raylib.ClearBackground(Color.Brown);


        Raylib.DrawText("HighScore:" + highScore.ToString(), screenWidth / 2 - Raylib.MeasureText("HighScore:" + highScore.ToString(), 50) / 2, 100, 50, Color.Black);
        Raylib.DrawRectangleRec(startButton, Color.Red);
        Raylib.DrawText("start", screenWidth / 2 - Raylib.MeasureText("start", 100) / 2, (int)startButton.Y, 100, Color.Black);

    }

    public static (int, string, Rectangle) Reset(int points, List<Plattform> platforms, int screenWidth, int screenHeight, Rectangle startGround, Player player, string scene)
    {
        points = 0;

        platforms.Clear();
        //Gör 1000 platformar
        for (int i = -1; i < 1000; i++)
        {
            platforms.Add(new Plattform(i * -100));
        }

        // Sätter första platformen i mitten
        platforms[0].Size.X = screenWidth / 2 - platforms[0].Size.Width / 2;


        // Startground position
        startGround = new(0, 850, screenWidth, screenHeight - 850);


        // Player position
        player.CharacterRec.X = screenWidth / 2 - player.CharacterRec.Width / 2;
        player.CharacterRec.Y = 750;


        // Byter scene
        scene = "game";

        return (points, scene, startGround);
    }
}
