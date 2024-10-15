using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P_102_T
{
    public class Citizen : Character
    {
        public List<string> Inventory { get; private set; } = new List<string>();

        public Citizen(Position initialPosition) : base(initialPosition) { }

        public override void Move(int rows)
        {
            // Move down, wrap around if necessary
            Position = new Position((Position.X + 1) % rows, Position.Y);
        }
        // Genererar en lista med slumpmässiga föremål för medborgarens inventarie
        private List<string> GenerateInitialItems()
        {
            return new List<string>
            {
                "Wallet",
                "Keys",
                "Phone",
                "Watch"
            };
        }
    }
}
