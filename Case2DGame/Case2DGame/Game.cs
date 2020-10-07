using System;
using System.Collections.Generic;
using System.Text;

namespace Case2DGame
{
    static class Game
    {
        public static bool Gameloop = true;
        public static void Start()
        {
            int Width = 40;
            int Length = 20;

            Map.CreateMap(Width, Length);
            Console.CursorVisible = false;

            while (Gameloop)
            {
                Movement.Move();
            }

        }
    }
}
