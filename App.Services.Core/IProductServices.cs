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
        string GetProductNameById(int id);
        ProductDto GetProductById(int id);
        IEnumerable<ProductDto> GetAllProducts();
        PageResult<ProductDto> GetProducts(Page page);
        IEnumerable<ProductDto> GetProducts(Expression<Func<ProductDto, bool>> where);
    }
}
