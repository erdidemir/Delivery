using MediatR;
using Delivery.Application.Models.Commons;

namespace Delivery.Application.Features.Commands.Deliveries.AddShipment
{
    public class AddShipmentCommand : IRequest<ResponseModelBase<int>>
    {
        public int UserId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
