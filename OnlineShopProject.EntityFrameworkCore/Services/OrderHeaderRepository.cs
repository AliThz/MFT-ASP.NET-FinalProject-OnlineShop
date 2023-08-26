using Microsoft.EntityFrameworkCore;
using OnlineShopProject.Domain.Aggregates.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopProject.EntityFrameworkCore.Services
{
    public class OrderHeaderRepository :
        Frameworks.Base.BaseRepository<OnlineShopProjectDbContext, Domain.Aggregates.OrderAggregate.OrderHeader, Guid>,
        Domain.Reporities.IOrderRepository
    {
        #region [ - Ctor - ]
        public OrderHeaderRepository(OnlineShopProjectDbContext dbContext) : base(dbContext)
        {
        }
        #endregion

        #region [ - Methods - ]

        #region [ - Select() - ]
        public override async Task<List<OrderHeader>> Select()
        {
            var orders = DbContext.OrderHeader
                .Include(oh => oh.Seller)
                .Include(oh => oh.Buyer)
                .Include(oh => oh.OrderDetails).ThenInclude(od => od.OrderHeader)
                .Include(oh => oh.OrderDetails).ThenInclude(od => od.Product)
                //.AsNoTracking()
                .ToListAsync();

            //var result = DbContext.OrderHeader
            //   .Select(oh => new OrderDetail
            //   {
            //       OrderHeaderId = oh.Id,
            //       details = oh.OrderDetails.ToList()  // this will be the ICollection of Details table
            //   }).ToList();


            //var result = DbContext.OrderHeader
            //   .Select(oh => new OrderDetail
            //   {
            //       OrderHeaderId = oh.Id
            //   }).ToListAsync();


            return await orders;
        }
        #endregion

        #region [ - FindByIdAsync(Guid id) - ]
        public override async Task<OrderHeader> FindByIdAsync(Guid id)
        {
            var order = await DbContext.OrderHeader
                .Include(oh => oh.Seller)
                .Include(oh => oh.Buyer)
                .Include(oh => oh.OrderDetails).ThenInclude(od => od.OrderHeader)
                .Include(oh => oh.OrderDetails).ThenInclude(od => od.Product)
                //.AsNoTracking()
                .SingleOrDefaultAsync(oh => oh.Id == id);

            return order;
        }
        #endregion

        #endregion    
    }
}
