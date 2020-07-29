namespace GreenVsRed
{
    public class Cell
    {
        public Cell(int row, int col, char value)
        {
            this.Row = row;
            this.Col = col;
            this.Value = value;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public char Value { get; set; }

        public int GreenNeighboursCount { get; set; }
    }
}