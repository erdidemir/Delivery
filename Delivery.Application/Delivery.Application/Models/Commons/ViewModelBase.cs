using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Application.Models.Commons
{
    public class ViewModelBase
    {
        public int Id { get; protected set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public int DisplayOrder { get; set; }
        public bool IsActive { get; set; }
    }
}
