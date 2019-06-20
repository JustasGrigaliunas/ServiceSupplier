using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceSupplier.Entity
{
    public class IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdCountry { get; set; }
        public bool IsInEuropeanUnion { get; set; }
        public bool IsVATPayer { get; set; }
        public int VATPercentage { get; set; }
        
    }
}
