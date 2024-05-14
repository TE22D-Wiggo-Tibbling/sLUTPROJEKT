using System.Numerics;
using System.Runtime.CompilerServices;
using Raylib_cs;

public class GameScreen
{


    public static (int, Rectangle, int) Colision(Player player, List<Plattform> platforms, int points, int highScore, Rectangle startGround)
    {
        foreach (Plattform plat in platforms)
        {
            // man nuddar och man faller
            if (Raylib.CheckCollisionRecs(player.CharacterRec, plat.Size) && player.Movement.Y > 0)
            {
                // studsar
                player.Movement.Y = player.Bounce;
                // flyttar platformen 
                plat.Size.X = 6000;
                // lägger till points
                points++;
                // updaterar highScore
                if (points > highScore) highScore = points;

            }
            // Tar bort alla platformar som är vid 6000
        }
            platforms.RemoveAll(p => p.Size.X == 6000);

        // när man står på startground
        if (Raylib.CheckCollisionRecs(player.CharacterRec, startGround))
        {
            // Faller inte
            player.Movement.Y = 0;
            player.Gravity = 0;

            if (Raylib.IsKeyPressed(KeyboardKey.Space))
            {
                // slänger up spelare och bestämmer gravitation
                player.Movement.Y = -12.5f;
                player.Gravity = 0.1f;

            }
        }

        // Platformars reaktion när spelare kommer till miten av skärmen
        if (player.CharacterRec.Y < 500 && player.Movement.Y < 0)
        {
            foreach (Plattform move in platforms)
            {
                // flyttar platformarna med spelarens fart up medans spelaren rör sig upåt
                move.Size.Y -= player.Movement.Y;
            }
            // samma med startGround
            startGround.Y -= player.Movement.Y;
        }

        return (points, startGround, highScore);

    }

    // Rita Spel skärmen
    public static void DrawGameScreen(int points, int screenHeight, int screenWidth, Rectangle startGround, Player player, List<Plattform> plattforms)
    {

        Raylib.ClearBackground(Color.Blue);


        Raylib.DrawText(points.ToString(), screenWidth / 2 - Raylib.MeasureText(points.ToString(), 50) / 2, 120, 50, Color.Black);
        player.Draw();

        // ritar alla platformar
        foreach (Plattform pos in plattforms)
        {
            pos.Draw();
        }

        Raylib.DrawRectangleRec(startGround, Color.Brown);

        // visar kontroler när man är på startground
        if (Raylib.CheckCollisionRecs(player.CharacterRec, startGround))
        {
            Raylib.DrawText("SPACE to start", 50, 850, 25, Color.Black);
            Raylib.DrawText("Move with arrow keys", 50, 875, 25, Color.Black);
        }
    }
}