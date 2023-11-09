using Raylib_cs;
using System.Numerics;

Raylib.InitWindow(1700, 900, "Pelican");
Raylib.SetTargetFPS(60);

Vector2 movement = new Vector2(7, 7);

Texture2D characterImage = Raylib.LoadTexture("gabba.png");
Rectangle characterRect = new Rectangle(100, 100, 128, 128);

while (!Raylib.WindowShouldClose())
{









    Raylib.EndDrawing();

}
