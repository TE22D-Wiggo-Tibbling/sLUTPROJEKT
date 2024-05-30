using System.Numerics;
using System.Runtime.CompilerServices;
using Raylib_cs;

public class StartScreen
{
    public static void DrawStartScreen(int highScore, Rectangle startButton, int screenHeight, int screenWidth, bool dead)
    {
        Raylib.ClearBackground(Color.Brown);


        Raylib.DrawText("Studsa på blatformarna", screenWidth / 2 - Raylib.MeasureText("Studsa på blatformarna", 20) / 2, 250, 20, Color.Black);
        Raylib.DrawText("Va snabb du kan bara landa på dem en gång", screenWidth / 2 - Raylib.MeasureText("Va snabb du kan bara landa på dem en gång", 20) / 2, 280, 20, Color.Black);
        Raylib.DrawText("Om du falle kommer du dö :(", screenWidth / 2 - Raylib.MeasureText("Om du falle kommer du dö :(", 20) / 2, 310, 20, Color.Black);

        if (dead)
        {
        Raylib.DrawText("Du föll", screenWidth / 2 - Raylib.MeasureText("Du föll", 20) / 2, 360, 20, Color.Red);
        Raylib.DrawText("Se till att altid studsa till en ny platform", screenWidth / 2 - Raylib.MeasureText("Se till att altid studsa till en ny platform", 20) / 2, 390, 20, Color.Red);
        Raylib.DrawText("Använd pilarna för att röra på dig", screenWidth / 2 - Raylib.MeasureText("Använd pilarna för att röra på dig", 20) / 2, 420, 20, Color.Red);
        }

        Raylib.DrawText("HighScore:" + highScore.ToString(), screenWidth / 2 - Raylib.MeasureText("HighScore:" + highScore.ToString(), 50) / 2, 100, 50, Color.Black);
        Raylib.DrawRectangleRec(startButton, Color.Red);
        Raylib.DrawText("start", screenWidth / 2 - Raylib.MeasureText("start", 100) / 2, (int)startButton.Y, 100, Color.Black);

    }

    public static (int, string, Rectangle) Reset(int points, List<Plattform> platforms, int screenWidth, int screenHeight, Rectangle startGround, Player player, string scene,bool dead)
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
