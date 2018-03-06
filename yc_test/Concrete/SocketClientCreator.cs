using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace yc_test
{
    public class SocketClientCreator : AbstractClientCreator
    {
        public override AbstractClient Create(EndPoint endPoint)
        {
            return new SocketClient(endPoint);
        }
    }
}
