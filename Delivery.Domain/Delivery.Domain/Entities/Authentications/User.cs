using Delivery.Domain.Entities.Deliveries;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Domain.Entities.Authentications
{
    /// <summary>
    ///  This class inherents from Microsoft.AspNetCore.Identity.IdentityUser
    ///  int type used for the primary key for the role.
    ///  Represents an user in the identity system
    /// </summary>
    public class User : IdentityUser<int>
    {
        public User()
        {
            Shipments = new HashSet<Shipment>();
        }

        /// <summary>
        /// Gets or sets user first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets user last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string VerifyCode { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public DateTime VerifyDate { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public bool Verified { get; set; }

        /// <summary>
        /// Gets or sets Last Login Date 
        /// if there is no login for x days, user have to delete
        /// </summary>
        public DateTime LastLoginDate { get; set; }

        public ICollection<Shipment> Shipments { get; set; }
    }
}
