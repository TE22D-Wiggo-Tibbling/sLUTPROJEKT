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
bool dead = false;


Player player = new Player();
Rectangle startGround = new Rectangle();

// Har lista för att jag vill kunna ändra på den under kodens gång. Med aray skulle det inte gå :)
List<Plattform> platforms = new();


Game.WhileLoop(scene,player,points,startGround,highScore,platforms,startButton,screenHeight,screenWidth,dead);

