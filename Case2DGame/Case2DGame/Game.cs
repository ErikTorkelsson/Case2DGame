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
            // Ställer in höjd och bredd på spelplanen
            int Width = 40;
            int Length = 20;
            
            //skapar en ny spelplan
            Map.CreateMap(Width, Length);
            Console.CursorVisible = false;
            Interaction.MessageBoard("Tryck på piltangenterna för att flytta på spelaren.");

            // Spelet körs så länge denna loop är igång.
            while (Gameloop)
            {
                Movement.Move();
            }

        }
    }
}
