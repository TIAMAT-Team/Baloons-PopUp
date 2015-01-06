using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonPopsGame.Printers
{
    public interface IPrinter
    {
        void PrintField(BalloonsField gameBoard);

        void PringMessage(string message);

        void PrintRankList(IDictionary<string, int> rankList);
    }
}
