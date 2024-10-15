using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_102_T
{
    public abstract class Character
    {
        public int Id { get; private set; }
        public Position Position { get; protected set; }
        private static int idCounter = 0;

        public Character(Position initialPosition)
        {
            Id = idCounter++;
            Position = initialPosition;
        }

        public abstract void Move(int boundary); // Implementeras i subklasser
    }
}
