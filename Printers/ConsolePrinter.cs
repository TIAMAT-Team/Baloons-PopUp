namespace BalloonPopsGame.Printers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    public class ConsolePrinter : IPrinter
    {

        public void PrintField(BalloonsField gameBoard)
        {
            StringBuilder sb = new StringBuilder();
            var columns = gameBoard.Size()[1];
            var rows = gameBoard.Size()[0];

            sb.Append("    ");

            for (byte column = 0; column < columns; column++)
            {
                sb.Append(column + " ");
            }

            sb.Append("\n   ");

            for (byte column = 0; column < (columns * 2) + 1; column++)
            {
                sb.Append("-");
            }

            sb.AppendLine();

            for (byte i = 0; i < rows; i++)
            {
                sb.Append(i + " | ");
                for (byte j = 0; j < columns; j++)
                {
                    if (gameBoard[i, j] == 0)
                    {
                        sb.Append("  ");
                        continue;
                    }

                    sb.Append(gameBoard[i, j] + " ");
                }
                sb.Append("| ");
                sb.AppendLine();
            }

            sb.Append("    ");

            for (byte column = 0; column < (columns * 2) + 1; column++)
            {
                sb.Append("-");
            }

            sb.AppendLine();
            Console.Write(sb.ToString());
        }

        public void PringMessage(string message)
        {
            Console.WriteLine(message);
        }

        public void PrintRankList(IDictionary<string, int> rankList)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Rank List:");


            if (rankList.Count != 0)
            {
                int counter = 1;

                var items = from pair in rankList
                            orderby pair.Value descending
                            select pair;

                foreach (KeyValuePair<string, int> pair in items)
                {
                    sb.AppendFormat("{0}. {1} --> {2}", counter, pair.Key, pair.Value);
                }

                Console.WriteLine(sb.ToString());
            }
            else
            {
                sb.AppendLine("The Rank List is Still Empty!");
                Console.WriteLine(sb.ToString());
            }
        }
    }
}
