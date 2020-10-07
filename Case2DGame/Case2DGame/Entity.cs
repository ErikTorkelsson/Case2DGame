using System;
using System.Collections.Generic;
using System.Text;

namespace Case2DGame
{
    public abstract class Entity
    {
        public Random rnd = new Random();
        public int X { get; set; }
        public int Y { get; set; }
        public int Dmg { get; set; }
        public int Health { get; set; }
        public char Ikon;
    }      
    public class Emptyspace : Entity
    {
        public Emptyspace()
        {
            Ikon = ' ';
        }
    }
    class Wall : Entity // Wall ärver från Entity
    {
        char[] Frame = new char[] { '╔', '╗', '╚', '╝', '═', '║', };
        public Wall(int nr)
        {
            Ikon = Frame[nr];
        }
    }
}
