namespace BalloonPopsGame
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BalloonsField
    {
        private static readonly int balloonTypesCount = 4;
        private int rows;
        private int columns;
        private byte[,] field;

        public BalloonsField(byte rows, byte columns)
        {
            this.rows = rows;
            this.columns = columns;
            this.field = this.GenerateRandomField(rows, columns);
        }


        public byte this[int row, int col]
        {
            get
            {
                if (row >= 0 && col >= 0 && row < this.rows && col < this.columns)
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
                if (row >= 0 && col >= 0 && row < this.rows && col < this.columns)
                {
                    this.field[row, col] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException("The requested position can not be set becauser it is outside the field.");
                }
            }
        }


        private byte[,] GenerateRandomField(byte rows, byte columns)
        {
            byte[,] field = new byte[rows, columns];
            Random randNumber = new Random();
            for (byte row = 0; row < rows; row++)
            {
                for (byte column = 0; column < columns; column++)
                {
                    byte tempByte = (byte)randNumber.Next(1, balloonTypesCount + 1);
                    field[row, column] = tempByte;
                }
            }

            return field;
        }

        public int[] Size()
        {
            return new int[] { this.rows, this.columns };
        }

        public bool isWinner()
        {
            for (int r = 0; r < this.rows; r++)
            {
                for (int c = 0; c < this.columns; c++)
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
            Stack<byte> stek = new Stack<byte>();
            int columnLenght = this.rows;
            for (int j = 0; j < this.columns; j++)
            {
                for (int i = 0; i < columnLenght; i++)
                {
                    if (this[i, j] != 0)
                    {
                        stek.Push(this[i, j]);
                    }
                }

                for (int k = columnLenght - 1; k >= 0; k--)
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
    }
}
