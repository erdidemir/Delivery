using Delivery.Application.Contracts.Repositories.Deliveries;
using Delivery.Domain.Entities.Deliveries;
using Delivery.Infrastructure.Contracts.Repositories.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Infrastructure.Contracts.Repositories.Deliveries
{
    public class ShipmentReadRepository : ReadRepository<Shipment>, IShipmentReadRepository
    {
        public ShipmentReadRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
