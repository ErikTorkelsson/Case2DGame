using System;
using System.Collections.Generic;
using System.Text;

namespace Case2DGame
{
    public abstract class Entity
    {
        public Random rnd = new Random();
        public int x { get; set; }
        public int y { get; set; }

        public int Dmg { get; set; }
        public int Health { get; set; }

        public char ikon;
    }
    public abstract class Item : Entity
    {
        // int Property { get; set; }
        public string Type { get; set; }

        public Item()
        {
            ikon = 'I';
        }
        public virtual void Use()
        {

        }
    }
    class Dagger : Item
    {
        public Dagger()
        {
            Type = "Dagger";
            //Property = Dmg =+ 2;
            x = rnd.Next(1, 19);
            y = rnd.Next(1, 19);
        }
        public override void Use()
        {
            Movement.player.Dmg += 5;
        }
    }
    class HealthPotion : Item
    {
        public HealthPotion()
        {
            Type = "Healthpotion";
            //Property = Health =+ 5;
            x = rnd.Next(1, 19);
            y = rnd.Next(1, 19);
        }
        public override void Use()
        {
            Movement.player.Health += 5;
        }
    }
    public class Creature : Entity
    {
    }
    public class Player : Creature
    {
        public List<Item> Inventory = new List<Item>();
        public Player()
        {
            ikon = 'X';
            x = 10;
            y = 10;
            Dmg = 3;
            Health = 10;

        }

    }
    class Wizard : Creature
    {
        public Wizard()
        {
            ikon = 'W';
            x = rnd.Next(1, 19);
            y = rnd.Next(1, 19);
        }
    }
    class Enemy : Creature
    {
        public Enemy()
        {
            ikon = 'E';
            x = rnd.Next(1, 19);
            y = rnd.Next(1, 19);
            Dmg = 2;
            Health = 8;
        }

    }
    class Emptyspace : Entity
    {
        // Returnerar ikon för tom plats
        public Emptyspace()
        {
            ikon = ' ';
        }

        //public override string ToString() { return ikon; }
    }
    class Wall : Entity
    {
        public Wall(int nr)
        {
            switch (nr)
            {
                case 1:
                    ikon = '╔';
                    break;
                case 2:
                    ikon = '╗';
                    break;
                case 3:
                    ikon = '╚';
                    break;
                case 4:
                    ikon = '╝';
                    break;
                case 5:
                    ikon = '═';
                    break;
                case 6:
                    ikon = '║';
                    break;

            }
        }
    }
}
