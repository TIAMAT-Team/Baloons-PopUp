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
            IBalloonPopsCommand balloonPopsCommand;
            var commandName = commandInfo.CommandName;
            var arguments = commandInfo.Arguments;

            if (commandName.StartsWith("RESTART"))
            {
                balloonPopsCommand = new RestartCommand();
            }
            else
            {
                throw new ArgumentException("Invalid command.");
            }

            return balloonPopsCommand;
        }
    }
}
