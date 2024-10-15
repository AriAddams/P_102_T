using System;
using System.Collections.Generic;

namespace P_102_T
{
    public class Grid
    {
        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public Grid(int columns, int rows)
        {
            Columns = columns;
            Rows = rows;
        }

        public void DecreaseSize(List<Thief> thieves, List<Citizen> citizens, List<Police> policeOfficers)
        {
            if (thieves.Count > 1 && citizens.Count > 2 && policeOfficers.Count > 1)
            {
                Rows = Math.Max(10, Rows - 5);
                Columns = Math.Max(10, Columns - 5);

                if (thieves.Count >= 2)
                {
                    thieves.RemoveRange(0, 2);
                }
                if (citizens.Count >= 2)
                {
                    citizens.RemoveRange(0, 2);
                }
                if (policeOfficers.Count >= 2)
                {
                    policeOfficers.RemoveRange(0, 2);
                }
            }
        }

        public void IncreaseSize(List<Thief> thieves, List<Citizen> citizens, List<Police> policeOfficers)
        {
            if (thieves.Count > 30 && citizens.Count > 40 && policeOfficers.Count > 20)
            {
                Rows += 5;
                Columns += 10;

                // Lägg till nya karaktärer med slumpmässiga positioner
                thieves.Add(new Thief(GetRandomPosition()));
                thieves.Add(new Thief(GetRandomPosition()));
                citizens.Add(new Citizen(GetRandomPosition()));
                citizens.Add(new Citizen(GetRandomPosition()));
                policeOfficers.Add(new Police(GetRandomPosition()));
                policeOfficers.Add(new Police(GetRandomPosition()));
            }
        }

        // Returnera en slumpmässig Position baserad på Rows och Columns
        public Position GetRandomPosition()
        {

            var random = new Random();
            return new Position(random.Next(Rows), random.Next(Columns));
        }
    }
}
