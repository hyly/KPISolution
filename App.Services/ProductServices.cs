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
            var results = entities.Select(it => AutoMapper.Mapper.Map<ProductDto>(it)).ToList();
            return results;
        }

        public Data.Core.PageResult<ProductDto> GetProducts(Data.Core.Page page)
        {
            var entities = this.productRepository.GetPage<string>(page, p => 1 == 1, o => o.Name);
            var result = new Data.Core.PageResult<ProductDto>(entities.Data.Select(it => AutoMapper.Mapper.Map<ProductDto>(it)), page, entities.TotalCount);
            return result;
        }

        public Data.Core.PageResult<ProductDto> GetProducts(Data.Core.Page page,Expression<Func<ProductDto,bool>> filter)
        {
            var entities = this.productRepository.GetPage<string>(page, filter.RemapForType<ProductDto, Product, bool>(), o => o.Name);
            var result = new Data.Core.PageResult<ProductDto>(entities.Data.Select(it => AutoMapper.Mapper.Map<ProductDto>(it)), page, entities.TotalCount);
            return result;
        }

        public List<ProductDto> GetProducts(Expression<Func<ProductDto, bool>> where)
        {
            var filter = where.RemapForType<ProductDto, Product, bool>();
            var results = this.productRepository.GetMany(filter).ToList();
            return results.Select(it=> AutoMapper.Mapper.Map<ProductDto>(it)).ToList();
        }

        public void Insert(ProductDto product) {
            this.productRepository.Add(new Product()
            {
                Active = product.Active,
                Color = product.Color,
                Description = product.Description,
                DisplayOrder = product.DisplayOrder,
                ImagePath = product.ImagePath,
                MetaDescription = product.MetaDescription,
                MetaKeywords = product.MetaKeywords,
                MetaTitle = product.MetaTitle,
                Name = product.Name,
                Price = product.Price
            });
        }
    }
}
