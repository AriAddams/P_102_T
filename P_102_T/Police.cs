using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_102_T
{
    public class Police : Character
    {
          public List<string> Inventory { get; private set; } = new List<string>();
    public List<Thief> ArrestedThieves { get; private set; } = new List<Thief>();

    public Police(Position initialPosition) : base(initialPosition) { }

    public override void Move(int rows)
    {
        // Move up, wrap around if necessary
        Position = new Position((Position.X - 1 + rows) % rows, Position.Y);
    }

    public void Arrest(Thief thief)
    {
            if (thief.Inventory.Count>0)
            {
               Inventory.AddRange(thief.Inventory);
                Console.WriteLine($"Police confiscated {thief.Inventory.Count} items from the thief.");
            }
            else
            {
                Console.WriteLine("Thief has no stolen items.");
            }
            ArrestedThieves.Add(thief);

            thief.Inventory.Clear();
            Console.WriteLine("Thief has been arrested and inventory cleared.");
        }
    }
}
