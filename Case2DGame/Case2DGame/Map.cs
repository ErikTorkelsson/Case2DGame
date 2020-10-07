using System;
using System.Collections.Generic;
using System.Text;

namespace Case2DGame
{
    class Map
    {
        public static int bredd = 40;

        public static int längd = 20;

        public static List<Entity> Entitylist = new List<Entity>();

        public static Entity[,] spelPlan = new Entity[bredd, längd];

        public static Emptyspace emptyspace = new Emptyspace();

        public static void AddEntity()
        {
            for (int i = 0; i < 5; i++)
            {
                var newEnemy = new Enemy();
                Entitylist.Add(newEnemy);
            }
            for (int i = 0; i < 3; i++)
            {
                var newWizard = new Wizard();
                Entitylist.Add(newWizard);
            }
            Dagger newDagger = new Dagger();
            Entitylist.Add(newDagger);
            HealthPotion healthPotion = new HealthPotion();
            Entitylist.Add(healthPotion);
        }
        public static void AddEntityToMap()
        {
            for (int i = 0; i < spelPlan.GetLength(0); i++)
            {
                for (int j = 0; j < spelPlan.GetLength(1); j++)
                {
                    while (true)
                    {
                        foreach (var item in Entitylist)
                        {
                            if (item.x == j && item.y == i)
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
            }
            AddWalls();
        }
        public static void AddWalls()
        {
            Wall topLeft = new Wall(1);
            Wall topRight = new Wall(2);
            Wall bottomLeft = new Wall(3);
            Wall bottomright = new Wall(4);
            Wall vog = new Wall(5);
            Wall lod = new Wall(6);

            spelPlan[0, 0] = topLeft;
            for (int i = 1; i < spelPlan.GetLength(0) - 1; i++)
            {
                spelPlan[i, 0] = vog;
            }
            spelPlan[spelPlan.GetLength(0) - 1, 0] = topRight;
            for (int i = 1; i < spelPlan.GetLength(1) - 1; i++)
            {
                spelPlan[0, i] = lod;
                spelPlan[spelPlan.GetLength(0) - 1, i] = lod;
            }
            spelPlan[0, spelPlan.GetLength(1) - 1] = bottomLeft;
            for (int i = 1; i < spelPlan.GetLength(0) - 1; i++)
            {
                spelPlan[i, spelPlan.GetLength(1) - 1] = vog;
            }
            spelPlan[spelPlan.GetLength(0) - 1, spelPlan.GetLength(1) - 1] = bottomright;
        }
        public static void PrintMap()
        {
            for (int i = 0; i < spelPlan.GetLength(1); i++)
            {
                for (int j = 0; j < spelPlan.GetLength(0); j++)
                {
                    Console.Write(spelPlan[j, i].ikon);
                }
                Console.Write("\n");
            }
        }
    }
}
