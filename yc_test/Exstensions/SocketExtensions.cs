using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Sockets;
using System.Text;

namespace yc_test
{
    public static class SocketExtensions
    {
        public static void SendMessage(this Socket socket, string message)
        {
            socket.Send(Encoding.ASCII.GetBytes(message + "\r\n"));
        }
        public static void SendMessage(this Socket socket, ReadOnlyCollection<AbstractClient> clients)
        {
            string message = string.Join("\r\n", clients);
            socket.SendMessage(message);
        }
    }
}
