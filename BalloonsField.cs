namespace BalloonPopsGame
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BalloonsField : IBalloonsField
    {
        private static readonly int balloonTypesCount = 4;
        private int rowsCount;
        private int columnsCount;
        private byte[,] field;

        public BalloonsField(byte rows, byte columns)
        {
            this.rowsCount = rows;
            this.columnsCount = columns;
            this.field = this.GenerateRandomField(rows, columns);
        }
        
        public byte this[int row, int col]
        {
            get
            {
                if (row >= 0 && col >= 0 && row < this.rowsCount && col < this.columnsCount)
                {
                    return this.field[row, col];
                }
                else
                {
                    throw new IndexOutOfRangeException("The requested coordinates are outside the field.");
                }
            }

            set
            {
                if (row >= 0 && col >= 0 && row < this.rowsCount && col < this.columnsCount)
                {
                    this.field[row, col] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("The requested position can not be set becauser it is outside the field.");
                }
            }
        }

        public int[] Size()
        {
            return new int[] { this.rowsCount, this.columnsCount };
        }

        public bool IsEmpty()
        {
            for (int r = 0; r < this.rowsCount; r++)
            {
                for (int c = 0; c < this.columnsCount; c++)
                {
                    if (this[r, c] != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public void NormalizeBalloonField()
        {
            // TODO: replace columnLength with this.rowsCount
            Stack<byte> stek = new Stack<byte>();
            int columnLength = this.rowsCount;
            for (int j = 0; j < this.columnsCount; j++)
            {
                for (int i = 0; i < columnLength; i++)
                {
                    if (this[i, j] != 0)
                    {
                        stek.Push(this[i, j]);
                    }
                }

                for (int k = columnLength - 1; k >= 0; k--)
                {
                    try
                    {
                        this[k, j] = stek.Pop();
                    }
                    catch (Exception)
                    {
                        this[k, j] = 0;
                    }
                }
            }
        }

        private byte[,] GenerateRandomField(byte rowsCount, byte columnsCount)
        {
            byte[,] balloonsField = new byte[rowsCount, columnsCount];
            Random randNumber = new Random();
            for (byte row = 0; row < rowsCount; row++)
            {
                for (byte column = 0; column < columnsCount; column++)
                {
                    byte tempByte = (byte)randNumber.Next(1, balloonTypesCount + 1);
                    balloonsField[row, column] = tempByte;
                }
            }

            return balloonsField;
        }




    }
}
