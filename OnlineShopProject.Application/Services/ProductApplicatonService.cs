using AutoMapper;
using OnlineShopProject.Application.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopProject.Application.Services
{
    public class ProductApplicatonService : Abstracts.IProductApplicationService
    {
        #region [ - Ctor - ]
        public ProductApplicatonService(Domain.Reporities.IProductRepository productRepository, Domain.Factories.ProductFactory.ProductFactoryService productFactory, IMapper mapper)
        {
            ProductRepository = productRepository;
            ProductFactory = productFactory;
            Mapper = mapper;
        }
        #endregion

        #region [ - Props - ]
        public Domain.Reporities.IProductRepository ProductRepository { get; set; }
        public Domain.Factories.ProductFactory.ProductFactoryService ProductFactory { get; set; }
        public IMapper Mapper { get; set; }
        #endregion

        #region [ - Methods - ]

        #region [ - GetAsync(Guid id) - ]
        public async Task<ProductDTO> GetAsync(Guid id)
        {
            var product = await ProductRepository.FindByIdAsync(id);
            return Mapper.Map<ProductDTO>(product);
        }
        #endregion

        #region [ - GetListAsync() - ]
        public async Task<List<ProductDTO>> GetListAsync()
        {
            var products = await ProductRepository.SelectAsync();
            return Mapper.Map<List<ProductDTO>>(products);
        }
        #endregion

        #region [ - CreateAsync(CreateProductDTO input) - ]
        public async Task<ProductDTO> CreateAsync(CreateProductDTO input)
        {
            var product = await ProductFactory.CreateAsync(input.Title, input.UnitPrice, input.Quantity);
            await ProductRepository.InsertAsync(product);
            return Mapper.Map<Domain.Aggregates.ProductAggregate.Product, ProductDTO>(product);
        }
        #endregion

        #region [ - UpdateAsync(Guid id, UpdateProductDTO input) - ]
        public async Task UpdateAsync(Guid id, UpdateProductDTO input)
        {
            var product = await ProductRepository.FindByIdAsync(id);
            if (product != null)
            {
                product.Title = input.Title;
                product.UnitPrice = input.UnitPrice;
                product.Quantity = input.Quantity;

                await ProductRepository.UpdateAsync(product);
            }
        } 
        #endregion

        #region [ - DeleteAsync(Guid id) - ]
        public async Task DeleteAsync(Guid id)
        {
            await ProductRepository.DeleteAsync(id);
        }
        #endregion

        #endregion
    }
}
