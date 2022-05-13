using Delivery.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Domain.Entities.Cargos
{
    public class Cargo : EntityBase
    {
        public string Name { get; set; }
        public int CargoEnumId { get; set; }
    }
}
