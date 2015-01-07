using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonPopsGame
{
    public interface IBalloonsField
    {
        int[] Size();

        bool IsEmpty();

        void NormalizeBalloonField();

        byte this[int row, int col] { get; set; }
    }
}
