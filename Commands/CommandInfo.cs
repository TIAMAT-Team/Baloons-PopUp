namespace BalloonPopsGame.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class CommandInfo : ICommandInfo
    {
        private string commandName;
        private IEnumerable<string> arguments;

        public CommandInfo(string commandName, IEnumerable<string> arguments)
        {
            this.CommandName = commandName;
            if (null == arguments)
            {
                this.Arguments = new List<string>();
            }
            else
            {
                this.Arguments = arguments;
            }
        }


        public string CommandName
        {
            get
            {
                return this.commandName;
            }
            set
            {
                this.commandName = value;
            }
        }

        public IEnumerable<string> Arguments
        {
            get
            {
                return this.arguments;
            }
            set
            {
                this.arguments = value;
            }
        }
    }
}
