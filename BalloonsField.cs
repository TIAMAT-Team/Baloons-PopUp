namespace BalloonPopsGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class BalloonsField
    {
        private static readonly int balloonTypesCount = 4;
        public static byte[,] GenerateRandomField(byte rows, byte columns)
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
    }
}
