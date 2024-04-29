using System.Numerics;
using System.Runtime.CompilerServices;
using Raylib_cs;

public class Collision
{


// ---------------------------------------------En fråga till micke iväg------------------------------
    public static void Colision(Player player, List<Plattform> platforms,int points,int highScore,Rectangle startGround)
    {
         foreach (Plattform colision in platforms)
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

        platforms.RemoveAll(p => p.size.X == 6000);



        if (player.characterRec.Y < 500 && player.movement.Y < 0)
        {
            foreach (Plattform move in platforms)
            {
                move.size.Y -= player.movement.Y;
            }
            startGround.Height -=1;
        }
    }

}