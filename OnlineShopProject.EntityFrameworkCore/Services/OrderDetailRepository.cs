using Microsoft.EntityFrameworkCore;
using OnlineShopProject.Domain.Aggregates.OrderAggregate;
using OnlineShopProject.Domain.Reporities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopProject.EntityFrameworkCore.Services
{
    public class OrderDetailRepository :
        Frameworks.Base.BaseRepository<OnlineShopProjectDbContext, Domain.Aggregates.OrderAggregate.OrderDetail, Guid>,
        Domain.Reporities.IOrderDetailRepository
    {
        #region [ - Ctor - ]
        public OrderDetailRepository(OnlineShopProjectDbContext dbContext) : base(dbContext)
        {

        }
        #endregion

        #region [ - Methods - ]

        #region [ - GetOrderDetailsOfAnOrder(Guid orderHeaderId) - ]
        public async Task<List<OrderDetail>> GetOrderDetailsOfAnOrder(Guid orderHeaderId)
        {
            var orderDetails = DbContext.OrderDetail.Where(od => od.OrderHeaderId == orderHeaderId).ToListAsync();

            return await orderDetails;
        }
        #endregion

        #region [ - FindOrderDetailAsync(Guid orderHeaderId, Guid productId) - ]
        public async Task<OrderDetail> FindOrderDetailAsync(Guid orderHeaderId, Guid productId)
        {
            var orderDetail = await DbContext.OrderDetail.FindAsync(orderHeaderId, productId);
            return orderDetail;
        }
        #endregion

        #region [ - DeleteAsync(Guid orderHeaderId, Guid productId) - ]
        public async Task<OrderDetail> DeleteAsync(Guid orderHeaderId, Guid productId)
        {
            //await DbContext.OrderDetail.ForEachAsync(od => { if (od.OrderHeaderId == orderHeaderId & od.ProductId == productId) DbContext.OrderDetail.Remove(od); });  //Caan't return the deleted item
            foreach (var item in await DbContext.OrderDetail.ToListAsync())
            {
                if (item.OrderHeaderId == orderHeaderId & item.ProductId == productId)
                {
                    DbContext.OrderDetail.Remove(item);
                    break;
                }
                return item;
            }
            return null;
        }
        #endregion

        #endregion
    } 
}
