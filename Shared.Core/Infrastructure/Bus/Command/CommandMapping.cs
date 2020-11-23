#region Imports

using System.Collections.Generic;
using SPLAR.Shared.Domain.Bus.Command;

#endregion

namespace SPLAR.Shared.Infrastructure.Bus.Command
{
    //TODO review this class
    public class CommandMapping
    {
        public CommandMapping(string assamblyName)
        {
            var type = typeof(ICommand);
        }

        public List<string> Commands { get; } = new List<string>();
    }
}