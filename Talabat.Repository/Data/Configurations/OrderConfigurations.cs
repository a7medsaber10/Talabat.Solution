using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Order_Aggregate;

namespace Talabat.Repository.Data.Configurations
{
    public class OrderConfigurations : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(o => o.Status)
                .HasConversion(OStatus => OStatus.ToString(), OStatus => (OrderStatus) Enum.Parse(typeof(OrderStatus), OStatus));

            builder.OwnsOne(o => o.ShippingAddress, shippingAddress => shippingAddress.WithOwner());

            builder.Property(o => o.SubTotal).HasColumnType("decimal(18,2)");

            builder.HasOne(o => o.DeliveryMethod)
                .WithMany()
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
