using System.Numerics;
using Raylib_cs;

Raylib.InitWindow(800, 800, "before and after");
Raylib.SetTargetFPS(60);

Vector2 pos = new(200, 200);

while (!Raylib.WindowShouldClose())
{
  int mouseX = Raylib.GetMouseX();
  int mouseY = Raylib.GetMouseY();

  if (Raylib.IsKeyDown(KeyboardKey.Right))
  {
    pos.X += 3;
  }
  if (Raylib.IsKeyDown(KeyboardKey.Left))
  {
    pos.X -= 3;
  }
  if (Raylib.IsKeyDown(KeyboardKey.Up))
  {
    pos.Y -= 3;
  }
  if (Raylib.IsKeyDown(KeyboardKey.Down))
  {
    pos.Y += 3;
  }

  while (pos.Y == 800 || pos.X == 800)
  {
    pos.Y = 800;
    pos.X = 800;
  }


  Raylib.BeginDrawing();

  Raylib.ClearBackground(Color.White);

  Raylib.DrawCircleV(pos, 100, Color.Green);

  Raylib.EndDrawing();
}