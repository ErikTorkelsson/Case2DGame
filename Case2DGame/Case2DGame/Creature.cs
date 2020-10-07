using System;
using System.Collections.Generic;
using System.Text;

namespace Case2DGame
{
    public class Creature : Entity
    {
        public int Width { get; set; }
        public int Length { get; set; }
        public Creature(int width, int length)
        {
            Width = width;
            Length = length;
        }
    }
    public class Player : Creature
    {
        public List<Item> Inventory = new List<Item>();
        public Player(int width, int length) : base(width, length)
        {
            Ikon = 'X';
            X = width / 2;
            Y = length / 2;
            Dmg = 3;
            Health = 10;
        }
    }
    class Wizard : Creature
    {
        public Wizard(int width, int length) : base(width, length)
        {
            Ikon = 'W';
            X = rnd.Next(1, Width - 1);
            Y = rnd.Next(1, Length - 1);
        }
    }
    class Enemy : Creature
    {
        public Enemy(int width, int length) : base(width, length)
        {
            Ikon = 'E';
            X = rnd.Next(1, Width - 1);
            Y = rnd.Next(1, Length - 1);
            Dmg = 2;
            Health = 8;
        }
    }
}
