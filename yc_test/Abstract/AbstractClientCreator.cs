using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace yc_test
{
    public abstract class AbstractClientCreator
    {
        public abstract AbstractClient Create(EndPoint endPoint);
    }
}
