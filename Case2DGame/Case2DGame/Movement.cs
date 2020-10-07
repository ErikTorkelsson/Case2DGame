using System;
using System.Collections.Generic;
using System.Text;

namespace Case2DGame // Dags att committa
{
    public abstract class Movement
    {
        public static Player player = new Player(Map.Width,Map.Length);

        public static int counter;
        public static bool win = false;

        public static void Move()
        {
            int x = player.X;
            int y = player.Y;

            MovePlayer();
            Interaction.Interact();

            if (win)
            {
                SetCursorPosition();
            }
            else
            {
                player.X = x;
                player.Y = y;
                SetCursorPosition();
            }
        }
        public static void MovePlayer()
        {
            ConsoleKey move = Console.ReadKey().Key;
            Console.SetCursorPosition(player.X, player.Y);
            Console.Write(' ');
            switch (move)
            {
                case ConsoleKey.UpArrow:
                    player.Y--;
                    break;
                case ConsoleKey.LeftArrow:
                    player.X--;
                    break;
                case ConsoleKey.DownArrow:
                    player.Y++;
                    break;
                case ConsoleKey.RightArrow:
                    player.X++;
                    break;
                case ConsoleKey.Enter:

                    ShowInventory(player);
                    break;
            }
        }
        static void ShowInventory(Player player)
        {
            foreach (var item in player.Inventory)
            {
                Console.SetCursorPosition(Map.Width + 1, counter);
                Console.WriteLine(item.Type);
                counter++;
            }
        }
        public static void SetCursorPosition()
        {
            Console.SetCursorPosition(player.X, player.Y);
            Console.Write(player.Ikon);
        }
    }
}
