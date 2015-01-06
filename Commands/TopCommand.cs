using BalloonPopsGame.Printers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonPopsGame.Commands
{
    public class TopCommand : IBalloonPopsCommand
    {
        private IPrinter printer;
        private RankList rankList;

        public TopCommand(IPrinter printer, RankList rankList)
        {
            this.printer = printer;
            this.rankList = rankList;
        }

        public void Execute(string[] arguments)
        {
            printer.PrintRankList(rankList.RankListDictionary);
        }
    }
}
