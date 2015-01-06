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
          var splittedInput = input.Split(new char[]{' ', '.', ','});
            var arguments = splittedInput.Skip(1).Take(splittedInput.Length - 1);
            return new CommandInfo(splittedInput[0], arguments);
        }
    }
}
