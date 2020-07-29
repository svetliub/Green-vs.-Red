namespace GreenVsRed
{
    using System.Collections.Generic;

    public class Grid
    {
        private Cell[,] grid;

        public Grid(int rows, int cols)
        {
            this.grid = new Cell[rows, cols];
        }

        public void Add(Cell newCell)
        {
            this.grid[newCell.Row, newCell.Col] = newCell;
        }

        public List<Cell> GetAllSpecificCells(char color)
        {
            var cells = new List<Cell>();
            foreach (var cell in this.grid)
            {
                if (cell.Value.Equals(color))
                {
                    cell.GreenNeighboursCount = GetGreenNeighboursCount(cell);
                    cells.Add(cell);
                }
            }

            return cells;
        }

        public int GetGreenNeighboursCount(Cell cell)
        {
            var counter = 0;
            var row = cell.Row;
            var col = cell.Col;

            if (IsInGrid(row - 1, col, this.grid.GetLength(0), this.grid.GetLength(1)) && GetExactCell(row - 1, col).Value == '1')
            {
                counter++;
            }
            if (IsInGrid(row - 1, col + 1, this.grid.GetLength(0), this.grid.GetLength(1)) && GetExactCell(row - 1, col + 1).Value == '1')
            {
                counter++;
            }
            if (IsInGrid(row - 1, col - 1, this.grid.GetLength(0), this.grid.GetLength(1)) && GetExactCell(row - 1, col - 1).Value == '1')
            {
                counter++;
            }
            if (IsInGrid(row + 1, col, this.grid.GetLength(0), this.grid.GetLength(1)) && GetExactCell(row + 1, col).Value == '1')
            {
                counter++;
            }
            if (IsInGrid(row + 1, col - 1, this.grid.GetLength(0), this.grid.GetLength(1)) && GetExactCell(row + 1, col - 1).Value == '1')
            {
                counter++;
            }
            if (IsInGrid(row + 1, col + 1, this.grid.GetLength(0), this.grid.GetLength(1)) && GetExactCell(row + 1, col + 1).Value == '1')
            {
                counter++;
            }
            if (IsInGrid(row, col - 1, this.grid.GetLength(0), this.grid.GetLength(1)) && GetExactCell(row, col - 1).Value == '1')
            {
                counter++;
            }
            if (IsInGrid(row, col + 1, this.grid.GetLength(0), this.grid.GetLength(1)) && GetExactCell(row, col + 1).Value == '1')
            {
                counter++;
            }

            return counter;
        }

        public Cell GetExactCell(int x, int y)
        {
            return this.grid[x, y];
        }

        private static bool IsInGrid(int row, int col, int length, int rowLength)
        {
            return row >= 0 && row < length && col >= 0 && col < rowLength;
        }
    }
}