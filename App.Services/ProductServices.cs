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
    }
}
