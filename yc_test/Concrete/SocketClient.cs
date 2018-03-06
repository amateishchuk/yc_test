using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace yc_test
{
    public class SocketClient : AbstractClient
    {
        public SocketClient(EndPoint endPoint) : base(endPoint) { }
    }
}
