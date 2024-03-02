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
    public class OrderHeaderConfiguration : IEntityTypeConfiguration<Domain.Aggregates.OrderAggregate.OrderHeader>
    {
        public void Configure(EntityTypeBuilder<OrderHeader> builder)
        {
            builder.ToTable("OrderHeader");
            builder.Ignore(oh => oh.sellerId);
            builder.Ignore(oh => oh.buyerId);
            builder.HasKey(o => o.Id);
            //builder.Property("UnitPrice").HasColumnType("Money");
            //builder.Property(o => o.Seller).IsRequired();
            //builder.Property(o => o.Buyer).IsRequired();
        }
    }
}
