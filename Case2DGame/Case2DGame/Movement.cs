using System;
using System.Collections.Generic;
using System.Text;

namespace Case2DGame
{
    public abstract class Movement
    {
        public static Player player = new Player();
        public static int counter { get; set; }
        public static bool win = false;

        public static void Move()
        {
            int x = player.x;
            int y = player.y;

            MovePlayer();
            Interaction.Interact();

            if (win)
            {
                SetCursorPosition();
            }
            else
            {
                player.x = x;
                player.y = y;
                SetCursorPosition();
            }

        }
        public static void MovePlayer()
        {
            ConsoleKey move = Console.ReadKey().Key;
            Console.SetCursorPosition(player.x, player.y);
            Console.Write(' ');
            switch (move)
            {
                case ConsoleKey.UpArrow:
                    player.y--;
                    break;
                case ConsoleKey.LeftArrow:
                    player.x--;
                    break;
                case ConsoleKey.DownArrow:
                    player.y++;
                    break;
                case ConsoleKey.RightArrow:
                    player.x++;
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
                Console.SetCursorPosition(Map.bredd + 1, counter);
                Console.WriteLine(item.Type);
                counter++;
            }

        }
        public static void SetCursorPosition()
        {
            Console.SetCursorPosition(player.x, player.y);
            Console.Write(player.ikon);
        }
    }
}
