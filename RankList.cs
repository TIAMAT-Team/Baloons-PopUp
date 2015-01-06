namespace BalloonPopsGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class RankList
    {
        private const int MaximumNumberOfTopResults = 5;

        private IDictionary<string, int> rankList;

        public RankList()
        {
            this.rankList = new Dictionary<string, int>(MaximumNumberOfTopResults);
        }


        public IDictionary<string, int> GetRankList
        {
            get
            {
                return this.rankList;
            }

        }

        public bool SignIfSkilled(RankList rank, int points)
        {
            IDictionary<string, int> rankListDictionary = rank.GetRankList;

            if (rankListDictionary.Values.Count != 0 && rankListDictionary.Values.Count <= MaximumNumberOfTopResults)
            {
                var moves = rankListDictionary.Values;

                if (rankListDictionary.Values.Count == 5)
                {
                    if (points >= moves.Min())
                    {
                        var itemToBeRemoved = rankListDictionary.First(move => move.Value == moves.Min());
                        rankListDictionary.Remove(itemToBeRemoved.Key);
                        Console.WriteLine("Type in your name.");
                        string userName = Console.ReadLine();
                        rankListDictionary.Add(userName, points);

                        return true;
                    }
                }
            }
            else
            {
                Console.WriteLine("Type in your name.");
                string userName = Console.ReadLine();
                rankListDictionary.Add(userName, points);

                return true;
            }

            return false;
        }
    }
}