using System;
using System.Collections.Generic;
using System.Text;

namespace Case2DGame
{
    static class Game
    {
        public static void Start()
        {
            Console.CursorVisible = false;

            Map.AddEntity();
            Map.AddEntityToMap();
            Map.PrintMap();

            while (true)
            {
                Movement.Move();
            }

        }
    }
}
