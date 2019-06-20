using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceSupplier.Entity;

namespace ServiceSupplier.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private IList<ClientEntity> _clientEntities;
        
        public ClientRepository()
        {
            _clientEntities = new List<ClientEntity>();
        }
        public int Add(ClientEntity client)
        {
            _clientEntities.Add(client);
            return client.Id;
        }

        public IList<ClientEntity> Get()
        {
            return _clientEntities.ToList();
        }

        public ClientEntity GetBy(int id)
        {
            return _clientEntities.Single(c => c.Id == id);
        }

        public int GetCount()
        {
            return _clientEntities.Count;
        }
    }
}
