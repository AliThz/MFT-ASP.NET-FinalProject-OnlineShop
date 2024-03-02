using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShopProject.Domain.Aggregates.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopProject.EntityFrameworkCore.Configurations
{
    public class OrderDetailConfiguration : IEntityTypeConfiguration<Domain.Aggregates.OrderAggregate.OrderDetail>
    {
        #region [ - Configure(EntityTypeBuilder<OrderDetail> builder) - ]
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetail");
            //builder.Property(o => o.OrderHeader).IsRequired();
            //builder.Property(o => o.Product).IsRequired();
            builder.HasKey(o => new { o.OrderHeaderId, o.ProductId });
            builder.HasOne(od => od.OrderHeader)
                   .WithMany(oh => oh.OrderDetails)
                   .HasForeignKey(od => od.OrderHeaderId);
            builder.HasOne(od => od.Product)
                   .WithMany(p => p.OrderDetails)
                   .HasForeignKey(od => od.ProductId);
        }
        #endregion
    }
}
