using System;
using System.Collections.Generic;
using System.Threading;
namespace P_102_T
{
    public class Game
    {
        private Grid grid;
        private bool gameRunning = true;

        private List<Thief> thieves = new List<Thief>();
        private List<Citizen> citizens = new List<Citizen>();
        private List<Police> policeOfficers = new List<Police>();

        public Game()
        {
            grid = new Grid(100, 25); // Start with 100x25 grid
        }

        public void Start()
        {
            InitializeCharacters();

            while (gameRunning)
            {
                HandleInput();
                UpdateCharacterPositions();
                HandleCollisions();
                PrintGameBoard();


                PrintSummary();
                Thread.Sleep(2000);
                Console.Clear();
            }
        }

        private void InitializeCharacters()
        {
            // Initial population logic (add some thieves, citizens, and police)
            for (int i = 0; i < 5; i++) // Add 5 of each type
            {
                thieves.Add(new Thief(grid.GetRandomPosition()));
                citizens.Add(new Citizen(grid.GetRandomPosition()));
                policeOfficers.Add(new Police(grid.GetRandomPosition()));
            }
        }

        private void HandleInput()
        {
            if (Console.KeyAvailable)
            {
                var key = Console.ReadKey(true).Key;
                switch (key)
                {
                    case ConsoleKey.Z:
                        grid.DecreaseSize(thieves, citizens, policeOfficers);
                        break;
                    case ConsoleKey.X:
                        grid.IncreaseSize(thieves, citizens, policeOfficers);
                        break;
                    case ConsoleKey.Q:
                        gameRunning = false;
                        break;
                }
            }
        }

        private void UpdateCharacterPositions()
        {
            foreach (var thief in thieves)
            {
                thief.Move(grid.Columns); // Thieves move left
            }

            foreach (var citizen in citizens)
            {
                citizen.Move(grid.Rows); // Citizens move down
            }

            foreach (var police in policeOfficers)
            {
                police.Move(grid.Rows); // Police move up
            }
        }

        private void HandleCollisions()
        {
            foreach (var police in policeOfficers)
            {
                foreach (var thief in thieves)
                {
                    if (police.Position.Equals(thief.Position))
                    {
                        police.Arrest(thief);
                        Console.WriteLine($"Police {police.Id} arrested Thief {thief.Id}, stolen items: {string.Join(", ", thief.Inventory)}.");
                    }
                }
            }

            foreach (var thief in thieves)
            {
                foreach (var citizen in citizens)
                {
                    if (thief.Position.Equals(citizen.Position))
                    {
                        thief.Rob(citizen);
                        Console.WriteLine($"Thief {thief.Id} robbed Citizen {citizen.Id} and took {thief.LastStolenItem}.");
                    }
                }
            }
        }

        private void PrintGameBoard()
        {
            Console.Clear(); // Clear the console for better visibility
            Console.WriteLine("Game Board:");

            // Render the grid
            for (int row = 0; row < grid.Rows; row++)
            {
                for (int col = 0; col < grid.Columns; col++)
                {
                    bool isOccupied = false;

                    foreach (var police in policeOfficers)
                    {
                        if (police.Position.X == col && police.Position.Y == row)
                        {
                            Console.Write("P "); // Police
                            isOccupied = true;
                            break;
                        }
                    }

                    if (!isOccupied)
                    {
                        foreach (var thief in thieves)
                        {
                            if (thief.Position.X == col && thief.Position.Y == row)
                            {
                                Console.Write("T "); // Thief
                                isOccupied = true;
                                break;
                            }
                        }
                    }

                    if (!isOccupied)
                    {
                        foreach (var citizen in citizens)
                        {
                            if (citizen.Position.X == col && citizen.Position.Y == row)
                            {
                                Console.Write("C "); // Citizen
                                isOccupied = true;
                                break;
                            }
                        }
                    }

                    if (!isOccupied)
                    {
                        Console.Write(". "); // Empty space
                    }
                }
                Console.WriteLine();
            }
        }

        private void PrintSummary()
        {
            Console.WriteLine("Game Summary:");
            foreach (var police in policeOfficers)
            {
                foreach (var thief in thieves)
                {
                    if (police.ArrestedThieves.Contains(thief))
                    {
                        Console.WriteLine($"Police {police.Id} arrested Thief {thief.Id}, stolen items: {string.Join(", ", thief.Inventory)}.");
                    }
                }
            }
        }
    }
}
