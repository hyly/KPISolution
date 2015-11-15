using App.Data.DomainModel;
using App.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public string GetProductNameById(int id)
        {
            return this.productRepository.GetById(id).Name;
        }

        public ProductDto GetProductById(int id)
        {
            var entity = this.productRepository.GetById(id);
            return AutoMapper.Mapper.Map<ProductDto>(entity);
        }

        public IEnumerable<ProductDto> GetAllProducts()
        {
            throw new NotImplementedException();
        }

        public Data.Core.PageResult<ProductDto> GetProducts(Data.Core.Page page)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductDto> GetProducts(System.Linq.Expressions.Expression<Func<ProductDto, bool>> where)
        {
            throw new NotImplementedException();
        }
    }
}
