using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace yc_test
{
    public class SocketServer
    {
        private static SocketServer _instance;
        public static SocketServer Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SocketServer();
                return _instance;
            }
        }

        public void Start(int port)
        {
            IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            Socket listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            Console.WriteLine("Server started and waiting for clients!");

            listener.Bind(localEndPoint);
            listener.Listen(5);

            while (true)
            {
                Socket handler = listener.Accept();
                Thread thread = new Thread(new ParameterizedThreadStart(ProcessClient));
                thread.Start(handler);
            }
        }
        private SocketServer() { }


        public static void ProcessClient(object obj)
        {
            Socket handler = obj as Socket;
            Console.WriteLine($"{handler.RemoteEndPoint} connected.");

            if (ClientStorage.Instance.CheckForExist(handler.RemoteEndPoint))
            {
                handler.SendMessage($"The user with {handler.RemoteEndPoint} ip exists in the storage!");
                Console.WriteLine($"{handler.RemoteEndPoint} already exists.");
            }

            else
            {
                handler.SendMessage($"Hello! {handler.RemoteEndPoint}");

                AbstractClient client = new SocketClientCreator().Create(handler.RemoteEndPoint);
                ClientStorage.Instance.Add(client);

                string data = null;

                while (true)
                {
                    byte[] bytes = new byte[1];
                    int bytesRec = handler.Receive(bytes);

                    data += Encoding.ASCII.GetString(bytes, 0, bytesRec);

                    if (data.EndsWith("\r\n"))
                    {
                        string command = data.Replace("\r\n", "");

                        Console.WriteLine($"{handler.RemoteEndPoint} invoke {command}.");

                        int value;
                        bool isSuccess = int.TryParse(command, out value);
                        if (isSuccess)
                        {
                            client.Add(value);
                            handler.SendMessage($"Sum: {client.Sum.ToString()}");
                            Console.WriteLine($"{handler.RemoteEndPoint} sum: {client.Sum.ToString()}.");
                        }
                        else if (command == "list")
                        {
                            handler.SendMessage(ClientStorage.Instance.Clients);
                            Console.WriteLine($"{handler.RemoteEndPoint} get list of clients.");
                        }
                        else if (command == "exit")
                            break;
                        else
                        {
                            handler.SendMessage("The command is unknown!");
                        }
                        data = null;
                    }
                }
                ClientStorage.Instance.Remove(client);
            }

            Console.WriteLine($"{handler.RemoteEndPoint} disconnected.");
            handler.SendMessage("Bye!");

            handler.Shutdown(SocketShutdown.Both);
            handler.Close();

            handler.Dispose();
        }
    }
}