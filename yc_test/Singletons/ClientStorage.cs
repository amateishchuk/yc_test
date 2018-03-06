using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Text;

namespace yc_test
{
    public class ClientStorage
    {
        private List<AbstractClient> _socketClients;
        private static ClientStorage _instance;
        public static ClientStorage Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ClientStorage();
                return _instance;
            }
        }
        private ClientStorage()
        {
            _socketClients = new List<AbstractClient>();
        }

        public ReadOnlyCollection<AbstractClient> Clients
        {
            get
            {
                return new ReadOnlyCollection<AbstractClient>(_socketClients);
            }
        }

        public bool CheckForExist(EndPoint endPoint)
        {
            return _socketClients.FirstOrDefault(c => c.EndPoint.ToString() == endPoint.ToString()) != null;
        }

        public void Add(AbstractClient abstractClient)
        {
            _socketClients.Add(abstractClient);
        }

        public void Remove(AbstractClient client)
        {
            if (client != null)
                _socketClients.Remove(client);
        }
    }
}
