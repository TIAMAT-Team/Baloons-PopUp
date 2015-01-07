namespace BalloonPopsGame.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CommandParser : ICommandParser
    {
        public ICommandInfo Parse(string input)
        {
            var splittedInput = input.Split(new char[] { ' ', '.', ',' });

            var arguments = splittedInput.Take(splittedInput.Length);
            var commandInfo = new CommandInfo(splittedInput[0], arguments);

            return commandInfo;
        }
    }
}
