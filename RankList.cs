namespace BalloonPopsGame
{
    using System;
    using System.Collections.Generic;

    public class RankList : IComparable<RankList>
    {
        public int value;
        public string name;

        public RankList(int value, string name)
        {
            this.value = value;
            this.name = name;
        }

        public int CompareTo(RankList other)
        {
            return value.CompareTo(other.value);
        }

        public static void Print(string[,] tableToSort)
        {

            List<RankList> rankList = new List<RankList>();

            for (int i = 0; i < 5; ++i)
            {
                if (tableToSort[i, 0] == null)
                {
                    break;
                }

                rankList.Add(new RankList(int.Parse(tableToSort[i, 0]), tableToSort[i, 1]));

            }

            rankList.Sort();
            Console.WriteLine("---------TOP FIVE CHART-----------");
            for (int i = 0; i < rankList.Count; ++i)
            {
                RankList slot = rankList[i];
                Console.WriteLine("{2}.   {0} with {1} moves.", slot.name, slot.value, i + 1);
            }
            Console.WriteLine("----------------------------------");
        }

        public static bool SignIfSkilled(string[,] rank, int points)
        {
            bool skilled = false;
            int worstMoves = 0;
            int worstMovesRankPosition = 0;
            for (int i = 0; i < 5; i++)
            {
                if (rank[i, 0] == null)
                {
                    Console.WriteLine("Type in your name.");
                    string tempUserName = Console.ReadLine();
                    rank[i, 0] = points.ToString();
                    rank[i, 1] = tempUserName;
                    skilled = true;
                    break;
                }
            }
            if (skilled == false)
            {
                for (int i = 0; i < 5; i++)
                {
                    if (int.Parse(rank[i, 0]) > worstMoves)
                    {
                        worstMovesRankPosition = i;
                        worstMoves = int.Parse(rank[i, 0]);
                    }
                }
            }
            if (points < worstMoves && skilled == false)
            {
                Console.WriteLine("Type in your name.");
                string tempUserName = Console.ReadLine();
                rank[worstMovesRankPosition, 0] = points.ToString();
                rank[worstMovesRankPosition, 1] = tempUserName;
                skilled = true;
            }
            return skilled;
        }
    }
}