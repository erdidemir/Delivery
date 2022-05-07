using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Domain.Entities.Authentications
{
    /// <summary>
    ///  This class inherents from Microsoft.AspNetCore.Identity.IdentityRole
    ///  int type used for the primary key for the role.
    ///  Represents a role in the identity system
    /// </summary>
    public class Role : IdentityRole<int>
    {
    }
}
