using Raylib_cs;
using System.Numerics;


Raylib.InitWindow(1700, 900, "Pelican");
Raylib.SetTargetFPS(60);

Texture2D characterImage = Raylib.LoadTexture("peliplayer.png");
Texture2D characterImageDash = Raylib.LoadTexture("peliplayerdash.png");
Rectangle characterRect = new Rectangle(200, 300, 128, 128);

Texture2D testenemy = Raylib.LoadTexture("enemy.png");

characterRect.X = 200;
characterRect.Y = 300;

void Jump()
{
    if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
    {
        characterRect.Y -= 8;
        Raylib.DrawTexture(characterImage, (int) characterRect.X, (int) characterRect.Y, Color.WHITE);
    }
    else if(Raylib.IsKeyDown(KeyboardKey.KEY_W))
    {
        characterRect.Y += 0;
        Raylib.DrawTexture(characterImageDash, (int) characterRect.X, (int) characterRect.Y, Color.WHITE);
    }
    else
    {
        characterRect.Y += 8;
        Raylib.DrawTexture(characterImage, (int) characterRect.X, (int) characterRect.Y, Color.WHITE);
    }
}


while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();

    Raylib.ClearBackground(Color.SKYBLUE);

    Raylib.DrawRectangleRec(characterRect, Color.BLANK);

    Raylib.DrawTexture(testenemy, 1000, 300, Color.WHITE);

    Jump();









    Raylib.EndDrawing();

}
