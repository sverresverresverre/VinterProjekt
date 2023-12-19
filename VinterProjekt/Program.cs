using Raylib_cs;

Raylib.InitWindow(1700, 900, "Pelican");
Raylib.SetTargetFPS(60);

Texture2D characterImage = Raylib.LoadTexture("peliplayer.png");
Texture2D characterImageDash = Raylib.LoadTexture("peliplayerdash.png");
Rectangle characterRect = new Rectangle(250, 300, 128, 128);

Texture2D enemyImage = Raylib.LoadTexture("enemy.png");

characterRect.X = 250;
characterRect.Y = 300;

int enemyXPos = 5000;

int points = 0;

string scene = "start";

List<Rectangle> enemyRect = new();
enemyRect.Add(new Rectangle(enemyXPos, 10, 256, 256));
enemyRect.Add(new Rectangle(enemyXPos, 50, 256, 256));
enemyRect.Add(new Rectangle(enemyXPos, 125, 256, 256));
enemyRect.Add(new Rectangle(enemyXPos, 200, 256, 256));
enemyRect.Add(new Rectangle(enemyXPos, 275, 256, 256));
enemyRect.Add(new Rectangle(enemyXPos, 350, 256, 256));
enemyRect.Add(new Rectangle(enemyXPos, 425, 256, 256));
enemyRect.Add(new Rectangle(enemyXPos, 500, 256, 256));
enemyRect.Add(new Rectangle(enemyXPos, 575, 256, 256));
enemyRect.Add(new Rectangle(enemyXPos, 650, 256, 256));




int r = Random.Shared.Next(enemyRect.Count);


void EnemyFlight()
{
    foreach (Rectangle enemy in enemyRect)
    {
        Rectangle enemyBox = new Rectangle(enemyXPos + 24, (int)enemyRect[r].Y + 24, 216, 216);
        Raylib.DrawRectangleRec(enemyBox, Color.BLANK);
        Raylib.DrawTexture(enemyImage, enemyXPos, (int)enemyRect[r].Y, Color.WHITE);

        if (Raylib.CheckCollisionRecs(characterRect, enemyBox))
        {
            scene = "fail";
        }



    }


    if (enemyXPos > -300)
    {
        enemyXPos -= 30;
    }
    else
    {
        enemyXPos = 1700;
        r = Random.Shared.Next(enemyRect.Count);

        points += 1;
    }

    
}








void Jump()
{
    if (Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
    {
        characterRect.Y -= 8;
        Raylib.DrawTexture(characterImage, (int)characterRect.X, (int)characterRect.Y, Color.WHITE);
    }
    else if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
    {
        characterRect.Y += 0;
        enemyXPos -= 10;
        Raylib.DrawTexture(characterImageDash, (int)characterRect.X, (int)characterRect.Y, Color.WHITE);
    }
    else
    {
        characterRect.Y += 10;
        Raylib.DrawTexture(characterImage, (int)characterRect.X, (int)characterRect.Y, Color.WHITE);
    }
}

void Borders()
{
    if (characterRect.Y < 0)
    {
        characterRect.Y = 0;
    }
    if (characterRect.Y > 782)
    {
        characterRect.Y = 782;
        characterRect.Y += 0;
    }
}


while (!Raylib.WindowShouldClose())
{
    Raylib.BeginDrawing();

    if (scene == "start")
    {
        Raylib.ClearBackground(Color.DARKGREEN);
        Raylib.DrawText("Pelican Flight", 20, 20, 100, Color.BLACK);
        Raylib.DrawText("Press [ENTER] to start", 20, 150, 40, Color.GREEN);
        Raylib.DrawTexture(characterImage, 20, 210, Color.WHITE);

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
        {
            scene = "game";
        }
    }

    else if (scene == "game")
    {
        Raylib.ClearBackground(Color.SKYBLUE);

        Raylib.DrawRectangleRec(characterRect, Color.BLANK);


        Jump();

        Borders();

        EnemyFlight();

        Raylib.DrawText("HOLD [SPACE] TO FLY", 10, 10, 40, Color.BLACK);

        Raylib.DrawText("HOLD [W] TO GLIDE", 10, 80, 40, Color.BLACK);

        Raylib.DrawText($"POINTS: {points}", 1330, 10, 60, Color.GOLD);

        Raylib.DrawText("OUT OF 50", 1450, 80, 40, Color.BLACK);

        if (points == 50)
        {
            scene = "win";
        }
    }

    else if (scene == "fail")
    {
        Raylib.ClearBackground(Color.RED);
        Raylib.DrawText($"YOU SCORED {points} OUT OF 50...", 20, 20, 100, Color.BLACK);
        Raylib.DrawText("Press [ENTER] to continue", 20, 150, 40, Color.GREEN);

        
        if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
        {
            points = 0;

            enemyXPos = 5000;

            characterRect.Y = 300;

            scene = "start";
        }
    }

    else if (scene == "win")
    {
        Raylib.ClearBackground(Color.GOLD);
        Raylib.DrawText("YOU WIN!", 20, 20, 100, Color.BLACK);
        Raylib.DrawText("Press [ENTER] to continue", 20, 150, 40, Color.GREEN);

        points = 0;

        enemyXPos = 5000;

        characterRect.Y = 300;

        if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
        {
            scene = "start";
        }
    }


    Raylib.EndDrawing();

}
