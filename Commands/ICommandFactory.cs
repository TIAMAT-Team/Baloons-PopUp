namespace BalloonPopsGame.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface ICommandFactory
    {
        IBalloonPopsCommand CreateCommand(ICommandInfo commandInfo);
    }
}
