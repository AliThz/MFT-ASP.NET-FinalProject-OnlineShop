using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TanvirArjel.Extensions.Microsoft.DependencyInjection;

namespace OnlineShopProject.Domain.Factories.ProductFactory
{
    [ScopedService]
    public class ProductFactoryService
    {
        #region [ - Ctor - ]
        public ProductFactoryService(Reporities.IProductRepository productRepository)
        {
            ProductRepository = productRepository;
        }
        #endregion

        #region [ - Prop - ]
        public Reporities.IProductRepository ProductRepository { get; set; }
        #endregion

        #region [ - Method - ]

        #region [ - CreateAsync(string firstName, string lastName) - ]
        public async Task<Aggregates.ProductAggregate.Product> CreateAsync(string title, decimal unitPrice, decimal quantity)
        {
            var requestedProduct = await ProductRepository.GetProductByTitleAsync(title);
            if (requestedProduct == null)
            {
                return new Aggregates.ProductAggregate.Product(title, unitPrice, quantity);
            }
            else
            {
                return null;
            }
        }
        #endregion

        #endregion

    }
}
