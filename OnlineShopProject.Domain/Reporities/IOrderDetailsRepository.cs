using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineShopProject.Domain.Reporities
{
    [ScopedService]
    public interface IOrderDetailRepository : Contract.Abstracts.IRepository<Aggregates.OrderAggregate.OrderDetail, Guid>
    {
        // Other behaviors(tasks) that would be create for orderdetail entity and not exists in IRepository

        //Task<Aggregates.OrderAggregate.OrderDetail> FindOrderDetailAsync(Aggregates.OrderAggregate.OrderHeader orderHeader, Aggregates.ProductAggregate.Product product, decimal quantity);
    }
}
