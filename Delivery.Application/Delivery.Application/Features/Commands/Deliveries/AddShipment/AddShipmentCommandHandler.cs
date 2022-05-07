using AutoMapper;
using Delivery.Application.Responses;
using Delivery.Application.Services.Deliveries;
using Delivery.Domain.Entities.Deliveries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Delivery.Application.Features.Commands.Deliveries.AddShipment
{
    public class AddShipmentCommandHandler : IRequestHandler<AddShipmentCommand, ResponseBase>

    {
        private readonly IShipmentService _shipmentService;
        private readonly IMapper _mapper;

        public AddShipmentCommandHandler(IShipmentService shipmentService,
            IMapper mapper)
        {
            _shipmentService = shipmentService;
            _mapper = mapper;
        }
        public async Task<ResponseBase> Handle(AddShipmentCommand request, CancellationToken cancellationToken)
        {
            var shipmentEntity = _mapper.Map<Shipment>(request);

            var newShipmentEntity = await _shipmentService.AddAsync(shipmentEntity);

            return null;
        }
    }
}
