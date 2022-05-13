using Delivery.Application.Contracts.Repositories.Commons;
using Delivery.Application.Services.Cargos;
using Delivery.Domain.Entities.Cargos;
using Delivery.Infrastructure.Services.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Infrastructure.Services.Cargos
{
    public class CargoService : ServiceBase<Cargo>, ICargoService
    {
        private readonly IReadRepository<Cargo> _entityReadRepository;
        private readonly IWriteRepository<Cargo> _entityWriteRepository;

        public CargoService(IReadRepository<Cargo> entityReadRepository, IWriteRepository<Cargo> entityWriteRepository) : base(entityReadRepository, entityWriteRepository)
        {
            _entityReadRepository = entityReadRepository ?? throw new ArgumentNullException(nameof(entityReadRepository));
            _entityWriteRepository = entityWriteRepository ?? throw new ArgumentNullException(nameof(entityWriteRepository));

        }
    }
}
