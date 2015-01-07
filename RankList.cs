namespace BalloonPopsGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RankList
    {
        private const int MaximumNumberOfTopResults = 5;

        private IDictionary<string, int> rankList;
        private int movesCount;

        public RankList()
        {
            this.RankListDictionary = new Dictionary<string, int>(MaximumNumberOfTopResults);
            this.MovesCount = 0;
        }

        public int MovesCount
        {
            get { return movesCount; }
            set { movesCount = value; }
        }

        public IDictionary<string, int> RankListDictionary
        {
            get { return rankList; }
            set { rankList = value; }
        }

        public bool SignIfSkilled(RankList rank)
        {
            int currentMoves = rank.MovesCount;
            IDictionary<string, int> rankListDictionary = rank.RankListDictionary;

            if (rankListDictionary.Values.Count != 0)
            {
                if (rankListDictionary.Values.Count < MaximumNumberOfTopResults)
                {
                    Console.WriteLine("Type in your name.");
                    string userName = Console.ReadLine();
                    rankListDictionary.Add(userName, currentMoves);

                    return true;
                }
                else
                {
                    var moves = rankListDictionary.Values;

                    if (currentMoves >= moves.Min())
                    {
                        var itemToBeRemoved = rankListDictionary.First(move => move.Value == moves.Min());
                        rankListDictionary.Remove(itemToBeRemoved.Key);

                        Console.WriteLine("Type in your name.");
                        string userName = Console.ReadLine();
                        rankListDictionary.Add(userName, currentMoves);

                        return true;
                    }
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Type in your name.");
                string userName = Console.ReadLine();
                rankListDictionary.Add(userName, currentMoves);

                return true;
            }
        }
    }
}