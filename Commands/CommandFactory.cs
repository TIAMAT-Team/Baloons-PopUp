namespace BalloonPopsGame.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CommandFactory : ICommandFactory
    {
        public IBalloonPopsCommand CreateCommand(ICommandInfo commandInfo)
        {
            throw new NotImplementedException();
        }
    }
}
