using System.Numerics;
using Raylib_cs;

Raylib.InitWindow(400, 800, "before and after");
Raylib.SetTargetFPS(60);

// alla information
float radius = 20; // Ball radius
int screenWidth = 400;
int screenHeight = 800;
string gameover;

//all vector2
Vector2 pos = new(200, 400);
Vector2 top = new Vector2(150, 100);
Vector2 bottomLeft = new Vector2(100, 150);
Vector2 bottomRight = new Vector2(200, 150);

// speed for all random block spawn
List<Vector2> blocks = new();
Random rand = new();
float blockSpeed = 4;
int blockSize = 30;

int score = 0; 

// spawn block random on screen width
void SpawnBlock()
{
    blocks.Add(new Vector2(rand.Next(0, screenWidth - blockSize), 0));
}

// fråga chatgpt

// keyboard setting
while (!Raylib.WindowShouldClose())
{

    int mouseX = Raylib.GetMouseX();
    int mouseY = Raylib.GetMouseY();

    if (Raylib.IsKeyDown(KeyboardKey.Right) && pos.X + radius < screenWidth)
    {
        pos.X += 5; //to move right 
    }
    if (Raylib.IsKeyDown(KeyboardKey.Left) && pos.X - radius > 0)
    {
        pos.X -= 5; // to move left
    }
    if (Raylib.IsKeyDown(KeyboardKey.Up) && pos.Y - radius > 0)
    {
        pos.Y -= 5; // to move down
    }
    if (Raylib.IsKeyDown(KeyboardKey.Down) && pos.Y + radius < screenHeight)
    {
        pos.Y += 5; //to move up
    }
    if (rand.Next(100) < 10) // Randomly spawn blocks
    {
        SpawnBlock();
    }



    for (int i = 0; i < blocks.Count; i++)
    {
        blocks[i] = new Vector2(blocks[i].X, blocks[i].Y + blockSpeed);
    }

    blocks.RemoveAll(block => block.Y > screenHeight); //

    score++; //higher score every frame

    // clear block after falling out of screen width and height

    foreach (var block in blocks)
    {
        if (pos.X + radius > block.X && pos.X - radius < block.X + blockSize &&
            pos.Y + radius > block.Y && pos.Y - radius < block.Y + blockSize)
        {
            blocks.Clear();
            pos = new Vector2(200, 400); 
            score = 0; // reset on collision
        }
    }

    


    Raylib.BeginDrawing();
    Raylib.ClearBackground(Color.Gray); // backgroudn color gray
    Raylib.DrawCircleV(pos, 20, Color.Black);

    foreach (var block in blocks)
    {
        Raylib.DrawRectangleV(block, new Vector2(blockSize, blockSize), Color.Red);
    }
        // Draw Score on Screen
    Raylib.DrawText($"Score: {score}", 10, 10, 20, Color.White);

    Raylib.EndDrawing();
}

