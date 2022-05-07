using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Domain.Entities.Commons
{
    /// <summary>
    /// This class supports base abstact class for database entities
    /// <remarks>
    /// This class uses all generic repository actions as T Entity
    /// T Entity has to inherent this abstarct class
    /// </remarks>
    /// </summary>
    public abstract class EntityBase
    {
        /// <summary>
        /// it supports uniquely identify an database entity class.
        /// </summary>
        [Key]
        public int Id { get; protected set; }

        /// <summary>
        /// Gets or sets the created date time 
        /// </summary>
        [Required]
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Gets or sets the last modified date time
        /// </summary>
        [Required]
        public DateTime? LastModifiedDate { get; set; }

        /// <summary>
        /// Gets or sets the order to display
        /// Increases or Decreases
        /// </summary>
        [Required]
        public int DisplayOrder { get; set; }

        /// <summary>
        /// Gets or sets the appearance to display
        /// </summary>
        [Required]
        public bool IsActive { get; set; }
    }
}
