namespace BalloonPopsGame.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface ICommandParser
    {
        ICommandInfo Parse(string input);
    }
}
