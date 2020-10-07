using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace Case2DGame
{
    class Map
    {
        public static int Width = 40;

        public static int Length = 20;

        public static List<Entity> Entitylist = new List<Entity>();

        public static Entity[,] spelPlan = new Entity[Width, Length];

        public static Emptyspace emptyspace = new Emptyspace();

        public static void CreateMap(int width, int length)
        {
            // Kör alla metoder som behövs för att skriva ut spelplanen
            Width = width;
            Length = length;

            AddEntityToList();
            AddEntityToMap();
            AddWalls();
            PrintMap();
        }
        public static void AddEntityToList()
        { 
            // Lägger in alla entiteter som ska vara på spelplanen i en lista.
            for (int i = 0; i < 3; i++)
            {
                var newEnemy = new Enemy(Width,Length);
                Entitylist.Add(newEnemy);
                var newWizard = new Wizard(Width, Length);
                Entitylist.Add(newWizard);

            }
            Dagger newDagger = new Dagger(Width,Length);
            Entitylist.Add(newDagger);
            HealthPotion healthPotion = new HealthPotion(Width,Length);
            Entitylist.Add(healthPotion);
            Entitylist.Add(Movement.player);
        }
        public static void AddEntityToMap()
        {
            // Lägger in alla entiteter i spelplans arrayen
            for (int i = 0; i < spelPlan.GetLength(0); i++)
            {
                for (int j = 0; j < spelPlan.GetLength(1); j++)
                {
                    AddEntity(i,j);
                }
            }
        }
        public static void AddEntity(int i, int j)
        {
            // Kollar om det ska läggas in en entitet på spelplanen
            while (true)
            {
                foreach (var item in Entitylist)
                {
                    if (item.X == i && item.Y == j)
                    {
                        spelPlan[i, j] = item;
                        break;
                    }
                    else
                    {
                        spelPlan[i, j] = emptyspace;
                    }
                }
                break;
            }
        }
        public static void AddWalls()
        {
            // lägger in väggarna i spelplanen
            Wall topLeft = new Wall(0);
            Wall topRight = new Wall(1);
            Wall bottomLeft = new Wall(2);
            Wall bottomright = new Wall(3);
            Wall horizontal = new Wall(4);
            Wall vertical = new Wall(5);

            spelPlan[0, 0] = topLeft;
            spelPlan[spelPlan.GetLength(0) - 1, 0] = topRight;
            spelPlan[0, spelPlan.GetLength(1) - 1] = bottomLeft;
            spelPlan[spelPlan.GetLength(0) - 1, spelPlan.GetLength(1) - 1] = bottomright;

            for (int i = 1; i < spelPlan.GetLength(0) - 1; i++)
            {
                spelPlan[i, 0] = horizontal;
            }

            for (int i = 1; i < spelPlan.GetLength(1) - 1; i++)
            {
                spelPlan[0, i] = vertical;
                spelPlan[spelPlan.GetLength(0) - 1, i] = vertical;
            }
           
            for (int i = 1; i < spelPlan.GetLength(0) - 1; i++)
            {
                spelPlan[i, spelPlan.GetLength(1) - 1] = horizontal;
            }
           
        }
        public static void PrintMap()
        {
            // skriver ut allt som finns inlaggt i spelplans arrayen.
            for (int i = 0; i < spelPlan.GetLength(1); i++)
            {
                for (int j = 0; j < spelPlan.GetLength(0); j++)
                {
                    Console.Write(spelPlan[j, i].Ikon);
                }
                Console.Write("\n");
            }
        }
    }
}
