using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_102_T
{
    public class Thief : Character
    {
        public List<string> Inventory { get; private set; } = new List<string>();
        public string LastStolenItem { get; private set; }

        public Thief (Position initialPosition) : base(initialPosition) { }

        public override void Move(int columns)
        {
            // Move left, wrap around if necessary
            Position = new Position(Position.X,(Position.Y - 1 + columns) % columns);
        }

        public void Rob(Citizen citizen)
        {
            if (citizen.Inventory.Count > 0)
            {
                var item = citizen.Inventory[0];
                Inventory.Add(item);
                LastStolenItem = item;
                citizen.Inventory.Remove(item);

                Console.WriteLine($"Thief robbed {item} from citizen!");
            }
            else
            {
                Console.WriteLine("Citizen has nothing to steal");
            }
        }
}    }
