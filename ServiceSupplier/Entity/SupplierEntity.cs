using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSupplier.Entity
{
    public class SupplierEntity : IEntity
    {
        public SupplierEntity() { }
        public SupplierEntity(int id, string name, int idCountry, bool isInEuropeanUnion
           , bool isVATPayer, int vATPercentage)
        {
            this.Id = id;
            this.Name = name;
            this.IdCountry = idCountry;
            this.IsInEuropeanUnion = isInEuropeanUnion;
            this.IsVATPayer = isVATPayer;
            this.VATPercentage = vATPercentage;
        }
    }
}
