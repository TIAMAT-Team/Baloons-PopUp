using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BalloonPopsGame.Commands
{
    public interface ICommandInfo
    {
         string CommandName { get; set; }

         IEnumerable<string> Arguments { get; set; }
    }
}
