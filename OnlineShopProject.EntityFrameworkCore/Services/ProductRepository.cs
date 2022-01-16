using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopProject.EntityFrameworkCore.Services
{
    public class ProductRepository :
        Frameworks.Base.BaseRepository<OnlineShopProjectDbContext, Domain.Aggregates.ProductAggregate.Product, Guid>,
        Domain.Reporities.IProductRepository
    {
        #region [ - Ctor - ]
        public ProductRepository(OnlineShopProjectDbContext dbContext) : base(dbContext)
        {

        }
        #endregion

        #region [ - Method - ]

        #region [ - GetProductByTitleAsync(string title) - ]
        public async Task<Domain.Aggregates.ProductAggregate.Product> GetProductByTitleAsync(string title)
        {
            return await DbSet.FirstOrDefaultAsync(p => p.Title == title);
        }
        #endregion

        #endregion
    }
}
