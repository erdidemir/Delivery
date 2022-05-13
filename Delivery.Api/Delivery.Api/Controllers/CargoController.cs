using Delivery.Application.Models.Commons;
using Delivery.Domain.Entities.Cargos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Delivery.Api.Controllers
{
    public class CargoController : CustomControllerBase<Cargo, ResponseViewModelBase<NoContent>>
    {
        public CargoController(IMediator mediator) : base(mediator)
        {
        }
    }
}
