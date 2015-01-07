namespace BalloonPopsGame.Commands
{
    using BalloonPopsGame.Printers;

    public class RestartCommand : IBalloonPopsCommand
    {
        private IPrinter printer;

        public RestartCommand(IPrinter printer)
        {
            this.printer = printer;
        }

        public void Execute(string[] arguments)
        {
            var matrix = new BalloonsField(5, 10);
            printer.PrintField(matrix);
            var rankList = new RankList();
        }
    }
}
