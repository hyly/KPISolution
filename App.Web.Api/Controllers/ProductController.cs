using App.Services.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace App.Web.Api.Controllers
{
    public class ProductController : ApiController
    {
        private IProductServices productServices = null;
        public ProductController(IProductServices productServices)
        {
            this.productServices = productServices;
        }
        [HttpGet]
        public ProductDto GetProductById(int id) {
            return this.productServices.GetProductById(id);
        }

        [HttpGet]
        public List<ProductDto> GetAllProducts() {
            return this.productServices.GetAllProducts();
        }

        [HttpPost]
        public Data.Core.PageResult<ProductDto> GetProducts(Data.Core.Page page)
        {
            return this.productServices.GetProducts(page);
        }
    }
}
