namespace GreenVsRed
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        private static readonly List<int> redCheckNumbers = new List<int>() { 3, 6 };
        private static readonly List<int> greenCheckNumbers = new List<int>() { 0, 1, 4, 5, 7, 8 };

        static void Main(string[] args)
        {
            var gridArgs = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var gridWidth = gridArgs[0];
            var gridHeight = gridArgs[1];
            var grid = new Grid(gridHeight, gridWidth);
            FillTheGrid(grid, gridHeight);

            var tokens = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var col = tokens[0];
            var row = tokens[1];
            var generationN = tokens[2];

            Console.WriteLine(GetGreenGenerationsCount(grid, generationN, row, col));
        }

        private static void FillTheGrid(Grid grid, int gridHeight)
        {
            for (int row = 0; row < gridHeight; row++)
            {
                var cellsInput = Console.ReadLine().ToCharArray();

                for (int col = 0; col < cellsInput.Length; col++)
                {
                    var cell = new Cell(row, col, cellsInput[col]);
                    grid.Add(cell);
                }                
            }
        }

        private static int GetGreenGenerationsCount(Grid grid, int number, int row, int col)
        {
            var counter = 0;
            var cellToCheck = grid.GetExactCell(row, col);

            for (int i = 0; i <= number; i++)
            {
                if (cellToCheck.Value.Equals('1'))
                {
                    counter++;
                }

                var redCells = grid.GetAllSpecificCells('0');
                var greenCells = grid.GetAllSpecificCells('1');

                foreach (var redCell in redCells)
                {
                    if (redCheckNumbers.Contains(redCell.GreenNeighboursCount))
                    {
                        redCell.Value = '1';
                    }
                }

                foreach (var greenCell in greenCells)
                {
                    if (greenCheckNumbers.Contains(greenCell.GreenNeighboursCount))
                    {
                        greenCell.Value = '0';
                    }
                }
            }

            return counter;
        }
    }
}