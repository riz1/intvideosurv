using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NavigationControl
{
    public static class CommandBuilder
    {
        public static byte[] Build(this INavigationCommand command)
        {
            var buffer = new byte[7];

            int idx = 0;
            buffer[idx++] = 0xff;
            buffer[idx++] = command.DestinationAddress;

            command.CommandCode.CopyTo(buffer, idx);
            idx += command.CommandCode.Length;
            command.CommandData.CopyTo(buffer, idx);
            idx += command.CommandData.Length;
            //
            var checksum = (byte)(buffer.Skip(1).Sum(b => b) % 256);
            //var checksum = (byte)(buffer.Sum(b => b) % 256);
            buffer[idx++] = checksum;

            return buffer;
        }

        public static byte[] Build(this IEnumerable<IBinaryCommand> commands)
        {
            var buffers = commands.Select(navigationCommand => navigationCommand.Build()).ToList();

            var len = buffers.Sum(buf => buf.Length);
            var totalBuffer = new byte[len];

            var idx = 0;
            foreach (byte[] t in buffers)
            {
                t.CopyTo(totalBuffer, idx);
                idx += t.Length;
            }

            return totalBuffer;
        }

        public static byte[] Build(this IEnumerable<INavigationCommand> commands)
        {
            var converted = commands.Select(c => (IBinaryCommand) c);

            return Build(converted);
        }
    }
}
