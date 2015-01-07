namespace BalloonPopsGame.Printers
{
    using System.Collections.Generic;

    public interface IPrinter
    {
        void PrintField(IBalloonsField gameBoard);

        void PrintMessage(string message);

        void PrintRankList(IDictionary<string, int> rankList);
    }
}
