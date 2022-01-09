using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShopProject.Domain.Aggregates.PersonAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopProject.EntityFrameworkCore.Configurations
{
    public class PersonConfiguration : IEntityTypeConfiguration<Domain.Aggregates.PersonAggregate.Person>
    {
        #region [- Configure() -] 
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.LastName).IsRequired().HasMaxLength(50);
        }
        #endregion
    }
}
