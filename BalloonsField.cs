using System.Text;

namespace BalloonPopsGame
{
    using System;
    using System.Collections.Generic;
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

        //public void Draw()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("    ");

        //    for (byte column = 0; column < this.columns; column++)
        //    {
        //        sb.Append(column + " ");
        //    }

        //    sb.Append("\n   ");

        //    for (byte column = 0; column < (this.columns * 2) + 1; column++)
        //    {
        //        sb.Append("-");
        //    }

        //    sb.AppendLine();

        //    for (byte i = 0; i < this.rows; i++)
        //    {
        //        sb.Append(i + " | ");
        //        for (byte j = 0; j < this.columns; j++)
        //        {
        //            if (this[i, j] == 0)
        //            {
        //                sb.Append("  ");
        //                continue;
        //            }

        //            sb.Append(this[i, j] + " ");
        //        }
        //        sb.Append("| ");
        //        sb.AppendLine();
        //    }

        //    sb.Append("    ");

        //    for (byte column = 0; column < (this.columns * 2) + 1; column++)
        //    {
        //        sb.Append("-");
        //    }

        //    sb.AppendLine();
        //    Console.Write(sb.ToString());
        //}
    }
}
