using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavigationControl
{
    public class NavigationCommands : IBinaryCommand, IEnumerable<INavigationCommand>
    {
        private readonly List<INavigationCommand> _commands =
            new List<INavigationCommand>();

        public NavigationCommands Add(INavigationCommand command)
        {
            _commands.Add(command);
            return this;
        }


        #region IBinaryCommand Members

        byte[] IBinaryCommand.Build()
        {
            var binaryCommands = _commands.ConvertAll(c => c as IBinaryCommand);

            return binaryCommands.Build();
        }

        #endregion

        public IEnumerator<INavigationCommand> GetEnumerator()
        {
            return ((IEnumerable<INavigationCommand>) _commands).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
