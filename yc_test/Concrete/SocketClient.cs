using System.Net;

namespace yc_test
{
    public class SocketClient : AbstractClient
    {
        public SocketClient(EndPoint endPoint) : base(endPoint) { }
    }
}
