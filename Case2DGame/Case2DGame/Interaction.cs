using System;
using System.Collections.Generic;
using System.Text;

namespace Case2DGame
{
    public abstract class Interaction : Movement
    {
        public static void Interact()
        {
            // Kollar vilken typ av objekt som spelaren har hamnat på
            var entity = Map.spelPlan[player.X, player.Y] as Entity;            

            if (entity is Emptyspace)
            {
                win = true;
            }
            else if (entity is Enemy)
            {
                MessageBoard("Du möter en Enemy. Skriv 1 eller 2 tryck sedan Enter");
                Attack(player, entity);
            }
            else if (entity is Wizard)
            {
                MessageBoard("Du Möter en Wizard.");
                player.Health = +2;
                Map.spelPlan[player.X, player.Y] = Map.emptyspace;
                counter++;
            }
            else if (entity is Item)
            {
                var item = entity as Item;
                MessageBoard("Du har hittat en " + item.Type);
                player.Inventory.Add(item);
                item.Use();
                counter++;
                
                Map.spelPlan[player.X, player.Y] = Map.emptyspace;
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
                MessageBoard("[1] Attack [2] Fly :");
                Int32.TryParse(Console.ReadLine(), out int nr);
                if (nr == 1)
                {
                    enemy.Health -= player.Dmg;
                    MessageBoard($"Du Attackerar med {player.Dmg}, Din fiende har {enemy.Health} Hp kvar.");
                    if (enemy.Health <= 0)
                    {
                        MessageBoard("Du vann");
                        win = true;
                        Map.spelPlan[player.X, player.Y] = Map.emptyspace;
                        break;
                    }
                    else if (player.Health <= 0)
                    {
                        MessageBoard("Du är död");
                        Game.Gameloop = false;
                        break;
                    }
                    player.Health -= enemy.Dmg;
                    MessageBoard($"Fienden Attackerar med {enemy.Dmg}, Du har {player.Health} Hp kvar.");
                }
                else if (nr == 2)
                {
                    win = false;
                    break;
                }
                else
                {
                    MessageBoard("Du måste välja 1 eller 2");
                }
            }
        }
        public static void MessageBoard(String Message)
        {
            Console.SetCursorPosition(Map.Width + 1, counter);
            Console.Write(Message);
            counter++;
        }
    }


}
