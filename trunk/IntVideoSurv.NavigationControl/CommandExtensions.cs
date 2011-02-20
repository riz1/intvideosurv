using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Damany.Util.Extensions;

namespace NavigationControl
{
    public static class CommandExtensions
    {

        public static IEnumerable<INavigationCommand> AddressTo(this IEnumerable<INavigationCommand> commands, byte destinationAddress)
        {
            foreach (var navigationCommand in commands)
            {
                navigationCommand.DestinationAddress = destinationAddress;
            }

            return commands;
        }


        public static IEnumerable<INavigationCommand> Then(this INavigationCommand command, INavigationCommand appendCommand)
        {
            var commands = command.AsEnumerable();
            return Then(commands, appendCommand);
        }



        public static IEnumerable<INavigationCommand> Then(this IEnumerable<INavigationCommand> commands, INavigationCommand appendCommand)
        {
            var newCommands = new NavigationCommands();

            foreach (var navigationCommand in commands)
            {
                newCommands.Add(navigationCommand);
            }

            newCommands.Add(appendCommand);

            return commands;
        }


       
    }
}
