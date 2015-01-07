using BalloonPopsGame.Printers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonPopsGame.Commands
{
    public class BalloonsPopCommand : IBalloonPopsCommand
    {
        private int poppingRow;
        private int poppingColumn;
        private IPrinter printer;
        private RankList rankList;
        private BalloonsField gameBoard;

        public BalloonsPopCommand(int poppingRow, int poppingColumn, IPrinter printer, RankList rankList, BalloonsField gameBoard)
        {
            this.poppingRow = poppingRow;
            this.poppingColumn = poppingColumn;
            this.printer = printer;
            this.rankList = rankList;
            this.gameBoard = gameBoard;
        }



        public void Execute(string[] arguments)
        {

            if (BalloonPopper.IsBalloonPopped(this.gameBoard, this.poppingRow, this.poppingColumn))
            {
                printer.PrintMessage("cannot pop missing ballon!");
            }
            else
            {
                BalloonPopper.PopBalloons(this.gameBoard, this.poppingRow, this.poppingColumn);
            }

            this.rankList.MovesCount++;
            this.gameBoard.NormalizeBalloonField();

            if (gameBoard.isWinner())
            {
                GameOver(this.rankList, this.gameBoard, this.rankList.MovesCount);
            }

            printer.PrintField(gameBoard);

        }

        private void GameOver(RankList rankList, BalloonsField matrix, int userMoves)
        {
            this.printer.PrintMessage(String.Format("Gratz ! You completed it in {0} moves.", userMoves));
            if (rankList.SignIfSkilled(rankList))
            {
                printer.PrintRankList(rankList.RankListDictionary);
            }
            else
            {
                Console.WriteLine("I am sorry you are not skillful enough for TopFive chart!");
            }
            matrix = new BalloonsField(5, 10);
            userMoves = 0;
        }
    }
}
