using AutoMapper;
using Delivery.Application.Features.Commands.Commons.Adds;
using Delivery.Application.Models.Commons;
using Delivery.Application.Services.Cargos;
using Delivery.Domain.Entities.Cargos;
using System.Threading;
using System.Threading.Tasks;

namespace Delivery.Application.Features.Commands.Cargos.Adds.AddCargo
{
    public class AddCargoCommandHandler : AddCommandBaseHandler<AddCargoCommand>
    {
        private readonly ICargoService _cargoService;
        private readonly IMapper _mapper;
        public AddCargoCommandHandler(IMapper mapper, ICargoService cargoService) : base()
        {
            _mapper = mapper;
            _cargoService = cargoService;
        }

        public async override Task<ResponseViewModelBase<NoContent>> Handle(AddCommandBase<AddCargoCommand> request, CancellationToken cancellationToken)
        {
            var cargoEntity = _mapper.Map<Cargo>(request.Entity);

            await _cargoService.AddAsync(cargoEntity);

            return await base.Handle(request, cancellationToken);
        }
    }
}
