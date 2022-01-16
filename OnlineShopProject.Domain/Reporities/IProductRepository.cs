using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineShopProject.Domain.Reporities
{
    [ScopedService]
    public interface IProductRepository : Contract.Abstracts.IRepository<Aggregates.ProductAggregate.Product, Guid>
    {
        // Other behaviors(tasks) that would be create for person entity and not exists in IRepository
        Task<Aggregates.ProductAggregate.Product> GetProductByTitleAsync(string title);
    }
}
