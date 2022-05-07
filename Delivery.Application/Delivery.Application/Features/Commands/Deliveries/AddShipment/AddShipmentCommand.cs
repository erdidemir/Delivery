using Delivery.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Delivery.Application.Features.Commands.Deliveries.AddShipment
{
    public class AddShipmentCommand : IRequest<ResponseBase>
    {
        public int UserId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }
}
