using Delivery.Application.Models.Commons;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Features.Commands.Cargos.Adds.AddCargo
{
    public class AddCargoCommand : IRequest<ResponseViewModelBase<NoContent>>
    {
        public string Name { get; set; }
        public int CargoEnumId { get; set; }
    }
}
