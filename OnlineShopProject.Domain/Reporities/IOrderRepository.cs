using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineShopProject.Domain.Reporities
{
    [ScopedService]
    public interface IOrderRepository : Contract.Abstracts.IRepository<Aggregates.OrderAggregate.OrderHeader, Guid>
    {
        // Other behaviors(tasks) that would be create for order entity and not exists in IRepository
    }
}
