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
            this.rankList = new Dictionary<string, int>(MaximumNumberOfTopResults);
            this.MovesCount = 0;
        }

        public int MovesCount
        {
            get { return movesCount; }
            set { movesCount = value; }
        }

        public IDictionary<string, int> RankListDictionary
        {
            get
            {
                IDictionary<string, int> tempRankList = new Dictionary<string, int>();
                tempRankList = this.rankList;

                return tempRankList;
            }
        }

        public bool IsCurrentPlayerAdded(int currentMoves)
        {
            if (rankList.Values.Count != 0)
            {
                if (rankList.Values.Count < MaximumNumberOfTopResults)
                {
                    AddEntryInTheRankList(currentMoves);

                    return true;
                }
                else
                {
                    var moves = rankList.Values;

                    if (currentMoves >= moves.Min())
                    {
                        var itemToBeRemoved = rankList.First(move => move.Value == moves.Min());
                        rankList.Remove(itemToBeRemoved.Key);

                        AddEntryInTheRankList(currentMoves);

                        return true;
                    }
                    return false;
                }
            }
            else
            {
                AddEntryInTheRankList(currentMoves);

                return true;
            }
        }

        private void AddEntryInTheRankList(int currentMoves)
        {
            string userName = ReadUserName();

            this.rankList.Add(userName, currentMoves);
        }

        private string ReadUserName()
        {
            Console.WriteLine("Type in your name.");
            string userName = Console.ReadLine();

            return userName;
        }
    }
}