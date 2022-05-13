using Delivery.Application.Contracts.Repositories.Commons;
using Delivery.Application.Contracts.Repositories.Deliveries;
using Delivery.Application.Services.Commons;
using Delivery.Application.Services.Deliveries;
using Delivery.Application.Services.Cargos;
using Delivery.Infrastructure.Contracts;
using Delivery.Infrastructure.Contracts.Repositories.Commons;
using Delivery.Infrastructure.Contracts.Repositories.Deliveries;
using Delivery.Infrastructure.Services.Commons;
using Delivery.Infrastructure.Services.Deliveries;
using Delivery.Infrastructure.Services.Cargos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delivery.Application.Contracts.Repositories.Cargos;
using Delivery.Infrastructure.Contracts.Repositories.Cargos;

namespace Delivery.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationContext>(options =>
                                      options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));


            #region Commons

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));




            services.AddScoped(typeof(IServiceBase<>), typeof(ServiceBase<>));




            #endregion

            #region Deliveries

            services.AddScoped<IShipmentReadRepository, ShipmentReadRepository>();
            services.AddScoped<IShipmentWriteRepository, ShipmentWriteRepository>();
            services.AddScoped<IShipmentService, ShipmentService>();



            #endregion


            #region Cargos

            services.AddScoped<ICargoReadRepository, CargoReadRepository>();
            services.AddScoped<ICargoWriteRepository, CargoWriteRepository>();
            services.AddScoped<ICargoService, CargoService>();



            #endregion


            return services;
        }
    }
}
