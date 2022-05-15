using Delivery.Application.Features.Commands.Cargos.Adds.AddCargo;
using Delivery.Application.Models.Cargos;
using Delivery.Application.Models.Commons;
using Delivery.Domain.Entities.Cargos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Api.Controllers
{
    public class CargoController : CustomControllerBase<CargoViewModel, AddCargoCommand>
    {
        public CargoController(IMediator mediator) : base(mediator)
        {
        }
    }
}
