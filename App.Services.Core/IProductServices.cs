 using App.Data.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Services.Core
{
    public interface IProductServices
    {
        ProductDto GetProductById(int id);
        List<ProductDto> GetAllProducts();
        PageResult<ProductDto> GetProducts(Page page);
        PageResult<ProductDto> GetProducts(Page page, Expression<Func<ProductDto, bool>> filter);
        List<ProductDto> GetProducts(Expression<Func<ProductDto, bool>> where);
    }
}
