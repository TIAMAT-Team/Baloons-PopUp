namespace BalloonPopsGame.Commands
{
    using BalloonPopsGame.Printers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CommandFactory : ICommandFactory
    {
        private IPrinter printer;

        public CommandFactory(IPrinter printer)
        {
            this.printer = printer;
        }

        public IBalloonPopsCommand CreateCommand(ICommandInfo commandInfo)
        {
            IBalloonPopsCommand balloonPopsCommand;
            var commandName = commandInfo.CommandName;
            var arguments = commandInfo.Arguments;

            if (commandName.StartsWith("RESTART"))
            {
                balloonPopsCommand = new RestartCommand(this.printer);
            }
            else
            {
                throw new ArgumentException("Invalid command.");
            }

            return balloonPopsCommand;
        }
    }
}
