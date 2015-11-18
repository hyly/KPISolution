using App.Data.DomainModel;
using App.Data.DomainModel.Entities;
using App.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using App.Services.Extensions;
namespace App.Services.Implementation
{
    public class ProductServices:BaseServices,IProductServices
    {
        private IProductRepository productRepository = null;
        public ProductServices(IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this.productRepository = unitOfWork.ProductRepository;
        }

        public ProductDto GetProductById(int id)
        {
            var entity = this.productRepository.GetById(id);
            return AutoMapper.Mapper.Map<ProductDto>(entity);
        }

        public List<ProductDto> GetAllProducts()
        {
            var entities = this.productRepository.GetAll().ToList();
            return AutoMapper.Mapper.Map<List<ProductDto>>(entities);
        }

        public Data.Core.PageResult<ProductDto> GetProducts(Data.Core.Page page)
        {
            var entities = this.productRepository.GetPage<string>(page, p => 1 == 1, o => o.Name);
            var result = new Data.Core.PageResult<ProductDto>(AutoMapper.Mapper.Map<List<ProductDto>>(entities.Data), page, entities.TotalCount);
            return result;
        }

        public List<ProductDto> GetProducts(Expression<Func<ProductDto, bool>> where)
        {
            var filter = where.RemapForType<ProductDto, Product, bool>();
            var results = this.productRepository.GetMany(filter).ToList();
            return AutoMapper.Mapper.Map<List<ProductDto>>(results);
        }
    }
}
