using System;
using System.Collections.Generic;
using System.Text;

namespace Case2DGame
{
    public abstract class Movement
    {
        public static Player player = new Player(Map.Width,Map.Length);

        public static int counter;
        public static bool win = false;

        public static void Move()
        {
            
            int previousPositionX = player.X;
            int previousPositionY = player.Y;

            // Flyttar spelpjäsen
            MovePlayer();

            // Kollar Vilket föremål spelaren hamnar på
            Interaction.Interact();

            // Tömmer MessageBoard ifall det är fullt.
            CheckCounter();

            if (win)
            {
                Console.SetCursorPosition(previousPositionX, previousPositionY);
                Console.Write(" ");
                SetCursorPosition();
            }
            else
            {
                player.X = previousPositionX;
                player.Y = previousPositionY;
                SetCursorPosition();
            }
        }
        public static void MovePlayer()
        {
            // flyttar på spelaren beroende på vilken knapp du trycker på.
            ConsoleKey move = Console.ReadKey().Key;
            if (move == ConsoleKey.UpArrow || move == ConsoleKey.LeftArrow || move == ConsoleKey.DownArrow || move == ConsoleKey.RightArrow || move == ConsoleKey.Enter)
            {
                Console.SetCursorPosition(player.X, player.Y);
                //Console.Write(' ');
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
            else
            {
                Console.SetCursorPosition(player.X+1, player.Y);
                Console.Write(" ");
                Interaction.MessageBoard("Du styr med piltangenterna.");
            }
        }
        static void ShowInventory(Player player)
        {
            // skriver ut vad som finns i ditt inventory
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
        public static void CheckCounter()
        {
            if (counter > Map.Length + 5)
            {
                Console.Clear();
                Map.PrintMap();
                counter = 0;
            }
        }
    }
}
