using Delivery.Application.Contracts.Repositories.Cargos;
using Delivery.Domain.Entities.Cargos;
using Delivery.Infrastructure.Contracts.Repositories.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Infrastructure.Contracts.Repositories.Cargos
{
    public class CargoReadRepository : ReadRepository<Cargo>, ICargoReadRepository
    {
        public CargoReadRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
