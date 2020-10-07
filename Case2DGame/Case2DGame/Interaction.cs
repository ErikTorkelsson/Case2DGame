using System;
using System.Collections.Generic;
using System.Text;

namespace Case2DGame
{
    public abstract class Interaction : Movement
    {
        public static void Interact()
        {
            var entity = Map.spelPlan[player.x, player.y] as Entity;

            if (entity is Emptyspace)
            {
                win = true;
            }
            else if (entity is Enemy)
            {
                Console.SetCursorPosition(Map.bredd + 1, counter);
                Console.WriteLine("Du möter en Enemy");
                Attack(player, entity);
            }
            else if (entity is Wizard)
            {
                Console.SetCursorPosition(Map.bredd + 1, counter);
                Console.WriteLine("wizz");
                player.Health = +2;
                counter++;
            }
            else if (entity is Item)
            {
                var item = entity as Item;
                Console.SetCursorPosition(Map.bredd + 1, counter);
                Console.WriteLine("Du har hittat en " + item.Type);
                player.Inventory.Add(item);
                item.Use();
                counter++;
            }
            else if (entity is Wall)
            {
                win = false;
            }
        }
        static void Attack(Player player, Entity enemy)
        {
            while (true)
            {
                counter = SetCursor(counter);
                Console.Write("[1] Attack [2] Fly :");
                Int32.TryParse(Console.ReadLine(), out int nr);
                counter = SetCursor(counter);
                if (nr == 1)
                {
                    enemy.Health -= player.Dmg;
                    counter = SetCursor(counter);
                    Console.WriteLine($"Du Attackerar med {player.Dmg}, Enemy har {enemy.Health} Hp kvar.");
                    counter = SetCursor(counter);
                    if (enemy.Health <= 0)
                    {
                        Console.WriteLine("Du vann");
                        win = true;
                        break;
                    }
                    else if (player.Health <= 0)
                    {
                        Console.WriteLine("Du är död");
                        win = false;
                        break;
                    }
                    player.Health -= enemy.Dmg;
                    counter = SetCursor(counter);
                    Console.WriteLine($"Enemy Attackerar med {enemy.Dmg}, Du har {player.Health} Hp kvar.");

                }
                else if (nr == 2)
                {
                    win = false;
                    break;
                }
                else
                {
                    Console.SetCursorPosition(Map.bredd + 1, counter);
                    Console.WriteLine("Du måste välja 1 eller 2");
                }
            }
        }
        static int SetCursor(int counter)
        {
            Console.SetCursorPosition(Map.bredd + 1, counter);
            counter++;
            return counter;
        }
    }


}
