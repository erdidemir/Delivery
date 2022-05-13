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
    public class CargoWriteRepository : WriteRepository<Cargo>, ICargoWriteRepository
    {
        public CargoWriteRepository(ApplicationContext context) : base(context)
        {

        }
    }
}
