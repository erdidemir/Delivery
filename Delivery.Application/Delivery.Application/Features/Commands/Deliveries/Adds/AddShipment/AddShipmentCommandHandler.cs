using AutoMapper;
using Delivery.Application.Features.Commands.Deliveries.Adds.AddShipment;
using Delivery.Application.Models.Commons;
using Delivery.Application.Services.Deliveries;
using Delivery.Domain.Entities.Deliveries;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Delivery.Application.Features.Commands.Deliveries.AddShipment
{
    public class AddShipmentCommandHandler : IRequestHandler<AddShipmentCommand, ResponseViewModelBase<int>>

    {
        private readonly IMapper _mapper;
        private readonly IShipmentService _shipmentService;

        public AddShipmentCommandHandler(IShipmentService shipmentService,
            IMapper mapper)
        {
            _shipmentService = shipmentService;
            _mapper = mapper;
        }
        public async Task<ResponseViewModelBase<int>> Handle(AddShipmentCommand request, CancellationToken cancellationToken)
        {
            var shipmentEntity = _mapper.Map<Shipment>(request);

            var newShipmentEntity = await _shipmentService.AddAsync(shipmentEntity);

            return null;
        }
    }
}
