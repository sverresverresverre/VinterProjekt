using Raylib_cs;
using System.Numerics;

Raylib.InitWindow(1700, 900, "Pelican");
Raylib.SetTargetFPS(60);

Vector2 movement = new Vector2(7, 7);

Texture2D characterImage = Raylib.LoadTexture("peliplayer.png");
Rectangle characterRect = new Rectangle(200, 300, 128, 128);

Texture2D testenemy = Raylib.LoadTexture("enemy.png");

characterRect.X = 200;
characterRect.Y = 300;

while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();

    Raylib.ClearBackground(Color.SKYBLUE);

    Raylib.DrawRectangleRec(characterRect, Color.BLANK);

    Raylib.DrawTexture(characterImage, (int) characterRect.X, (int) characterRect.Y, Color.WHITE);

    Raylib.DrawTexture(testenemy, 1000, 300, Color.WHITE);









    Raylib.EndDrawing();

}
