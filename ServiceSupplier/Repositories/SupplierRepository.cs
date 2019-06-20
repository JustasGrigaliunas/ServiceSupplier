using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceSupplier.Entity;

namespace ServiceSupplier.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private IList<SupplierEntity> _supplierEntities;
        public SupplierRepository()
        {
            _supplierEntities = new List<SupplierEntity>();
        }
        public int Add(SupplierEntity entity)
        {
            _supplierEntities.Add(entity);
            return entity.Id;
        }

        public IList<SupplierEntity> Get()
        {
            return _supplierEntities.ToList();
        }

        public SupplierEntity GetBy(int id)
        {
            return _supplierEntities.Single(s => s.Id == id);
        }

        public int GetCount()
        {
            return _supplierEntities.Count;
        }
    }
}
