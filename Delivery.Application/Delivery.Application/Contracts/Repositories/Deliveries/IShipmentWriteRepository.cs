using Delivery.Application.Contracts.Repositories.Commons;
using Delivery.Domain.Entities.Deliveries;

namespace Delivery.Application.Contracts.Repositories.Deliveries
{
    public interface IShipmentWriteRepository : IWriteRepository<Shipment>
    {
    }
}
