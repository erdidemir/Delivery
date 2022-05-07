using Delivery.Domain.Entities.Authentications;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Infrastructure.Contracts
{
    public class ApplicationContextSeed
    {
        public static async Task SeedAsync(ApplicationContext applicationContext,
            ILogger<ApplicationContextSeed> logger,
            UserManager<User> userManager,
            RoleManager<Role> roleManager)
        {

            logger.LogInformation("Seed database associated with context {DbContextName}", typeof(ApplicationContext).Name);
        }

    }
}
