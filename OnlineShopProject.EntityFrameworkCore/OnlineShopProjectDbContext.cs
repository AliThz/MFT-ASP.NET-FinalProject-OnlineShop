using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopProject.EntityFrameworkCore
{
    public class OnlineShopProjectDbContext : IdentityDbContext<IdentityUser>
    {
        #region [ - Ctor - ]
        public OnlineShopProjectDbContext(DbContextOptions<OnlineShopProjectDbContext> contextOptions)
            : base(contextOptions)
        {
    
        }
        #endregion

        #region [ - DbSets - ]
        public DbSet<Domain.Aggregates.PersonAggregate.Person> Person { get; set; }
        public DbSet<Domain.Aggregates.ProductAggregate.Product> Product { get; set; }
        public DbSet<Domain.Aggregates.OrderAggregate.OrderHeader> OrderHeader { get; set; }
        public DbSet<Domain.Aggregates.OrderAggregate.OrderDetail> OrderDetail { get; set; }
        #endregion

        #region [ - OnModelCreating(ModelBuilder modelBuilder) - ]
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        } 
        #endregion
    }
}
