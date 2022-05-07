using Delivery.Application.Contracts.Repositories.Commons;
using Delivery.Domain.Entities.Deliveries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Contracts.Repositories.Deliveries
{
    public interface IShipmentReadRepository : IReadRepository<Shipment>
    {
    }
}
