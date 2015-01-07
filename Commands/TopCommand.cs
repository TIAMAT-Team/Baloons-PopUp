namespace BalloonPopsGame.Commands
{
    using BalloonPopsGame.Printers;

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
