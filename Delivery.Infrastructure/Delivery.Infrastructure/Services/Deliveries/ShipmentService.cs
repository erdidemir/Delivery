using Delivery.Application.Contracts.Repositories.Commons;
using Delivery.Application.Services.Deliveries;
using Delivery.Domain.Entities.Deliveries;
using Delivery.Infrastructure.Services.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Infrastructure.Services.Deliveries
{
    public class ShipmentService : ServiceBase<Shipment>, IShipmentService
    {
        private readonly IReadRepository<Shipment> _entityReadRepository;
        private readonly IWriteRepository<Shipment> _entityWriteRepository;

        public ShipmentService(IReadRepository<Shipment> entityReadRepository, IWriteRepository<Shipment> entityWriteRepository) : base(entityReadRepository, entityWriteRepository)
        {
            _entityReadRepository = entityReadRepository ?? throw new ArgumentNullException(nameof(entityReadRepository));
            _entityWriteRepository = entityWriteRepository ?? throw new ArgumentNullException(nameof(entityWriteRepository));

        }
    }
}
