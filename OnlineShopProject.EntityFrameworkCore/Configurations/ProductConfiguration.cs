using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShopProject.Domain.Aggregates.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopProject.EntityFrameworkCore.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Domain.Aggregates.ProductAggregate.Product>
    {
        #region [ - Configure(EntityTypeBuilder<Product> builder) - ]
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Title).IsRequired().HasMaxLength(100);
            builder.Property(p => p.UnitPrice).IsRequired();
            builder.Property(p => p.Quantity).IsRequired();
        } 
        #endregion
    }
}
