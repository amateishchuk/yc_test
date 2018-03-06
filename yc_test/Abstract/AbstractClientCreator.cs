using System.Net;

namespace yc_test
{
    public abstract class AbstractClientCreator
    {
        public abstract AbstractClient Create(EndPoint endPoint);
    }
}
