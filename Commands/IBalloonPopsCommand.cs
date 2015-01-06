namespace BalloonPopsGame.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface IBalloonPopsCommand
    {
        void Execute(string[] arguments);
    }
}
