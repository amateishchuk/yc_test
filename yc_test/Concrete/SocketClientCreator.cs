using System.Net;

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
