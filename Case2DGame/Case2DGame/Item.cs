using System;
using System.Collections.Generic;
using System.Text;

namespace Case2DGame
{
    public abstract class Item : Entity
    {
        public string Type { get; set; }

        public int Width { get; set; }
        public int Length { get; set; }

        public Item(int width, int length)
        {
            Ikon = 'I';
            Width = width;
            Length = length;
        }
        public virtual void Use() { }
    }
    class Dagger : Item // Dagger ärver från Item
    {
        public Dagger(int width, int length) : base(width, length)
        {
            Type = "Dagger";
            X = rnd.Next(1, width - 1);
            Y = rnd.Next(1, length - 1);
        }
        public override void Use()
        {
            Movement.player.Dmg += 5;
        }
    }
    class HealthPotion : Item
    {
        public HealthPotion(int width, int length) : base(width, length)
        {
            Type = "Healthpotion";
            //Property = Health =+ 5;
            X = rnd.Next(1, width - 1);
            Y = rnd.Next(1, length - 1);
        }
        public override void Use()
        {
            Movement.player.Health += 5;
        }
    }
}
