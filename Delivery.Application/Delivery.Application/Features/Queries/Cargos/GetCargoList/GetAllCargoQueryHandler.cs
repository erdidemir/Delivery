using AutoMapper;
using Delivery.Application.Features.Queries.Commons.GetAll;
using Delivery.Application.Models.Cargos;
using Delivery.Application.Models.Commons;
using Delivery.Application.Services.Cargos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Delivery.Application.Features.Queries.Cargos.GetCargoList
{
    public class GetAllCargoQueryHandler : GetAllQueryHandler<CargoViewModel>
    {
        private readonly ICargoService _cargoService;

        public GetAllCargoQueryHandler(IMapper mapper, ICargoService cargoService) : base(mapper)
        {
            _cargoService = cargoService;
        }

        public override async Task<ResponseViewModelBase<IReadOnlyList<CargoViewModel>>> Handle(GetAllQuery<CargoViewModel> request, CancellationToken cancellationToken)
        {
            _baseEntities = await _cargoService.GetAllAsync();
            return await base.Handle(request, cancellationToken);
        }
    }

}
