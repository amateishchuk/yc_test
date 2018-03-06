using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace yc_test
{
    public class AbstractClient
    {
        public EndPoint EndPoint { get; protected set; }
        public int Sum { get; protected set; }
        

        public AbstractClient(EndPoint endPoint)
        {
            this.EndPoint = endPoint;
            this.Sum = 0;
        }
        public virtual void Add(int value)
        {
            this.Sum += value;
        }
        public override string ToString()
        {
            return $"{this.EndPoint.ToString()} {this.Sum}";
        }
    }
}
