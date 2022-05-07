using Delivery.Domain.Configurations.Commons;
using Delivery.Domain.Entities.Deliveries;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delivery.Domain.Configurations.Deliveries
{
    public class ShipmentConfiguration : EntityTypeConfigurationBase<Shipment>
    {
        public override void Configure(EntityTypeBuilder<Shipment> entity)
        {
            base.Configure(entity);

            entity.Property(p => p.Code).IsRequired();
            entity.Property(p => p.UserId).IsRequired();

            #region ForeingKey

            entity.HasOne(d => d.User)
                .WithMany(p => p.Shipments)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region Index

            entity.HasIndex(e => e.Code, "UIX_Code").IsUnique();

            #endregion
        }
    }
}
