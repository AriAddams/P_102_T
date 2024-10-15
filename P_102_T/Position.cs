using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_102_T
 {
        public class Position
        {
            public int X { get; private set; }
            public int Y { get; private set; }

            public Position(int x, int y)
            {
                X = x;
                Y = y;
            }

            // Method to compare two positions
            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                    return false;

                Position other = (Position)obj;
                return X == other.X && Y == other.Y;
            }

            // Override GetHashCode when overriding Equals
            public override int GetHashCode()
            {
                return HashCode.Combine(X, Y);
            }

            // Method to create a readable string representation of the position
            public override string ToString()
            {
                return $"({X}, {Y})";
            }

            // Method to update position if needed
            public void UpdatePosition(int x, int y)
            {
                X = x;
                Y = y;
            }
        }
    }


