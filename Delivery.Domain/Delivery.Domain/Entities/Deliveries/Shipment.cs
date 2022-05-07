using Delivery.Domain.Entities.Authentications;
using Delivery.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Domain.Entities.Deliveries
{
    public class Shipment : EntityBase
    {
        [ForeignKey("UserId")]
        public int UserId { get; set; }

        public string Code { get; set; }

        public string Description { get; set; }

        public User User { get; set; }
    }
}
