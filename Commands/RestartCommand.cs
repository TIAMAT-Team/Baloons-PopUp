namespace BalloonPopsGame.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using BalloonPopsGame.Printers;

    public class RestartCommand : IBalloonPopsCommand
    {
        private IPrinter printer;

        public void Execute(string[] arguments)
        {
            var matrix = new BalloonsField(5, 10);
            printer.PrintField(matrix);
            var rankList = new RankList();
        }
    }
}
