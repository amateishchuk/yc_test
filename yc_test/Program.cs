using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace yc_test
{
    class Program
    {
        public static void Main(String[] args)
        {
            try
            {
                if (args.Length < 1)
                    throw new Exception("The socket server port is apsend!");

                int port;
                bool isSuccess = int.TryParse(args[0], out port);

                if (!isSuccess)
                    throw new Exception("Cannot cast port!");
                else if (port < 1)
                    throw new Exception("The specified port number is incorrect!");
                else
                    SocketServer.Instance.Start(port);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }        
    }
}
