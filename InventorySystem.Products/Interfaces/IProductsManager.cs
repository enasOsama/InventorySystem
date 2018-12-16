using InventorySystem.Core.Entities;
using InventorySystem.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Products.Interfaces
{
    public interface IProductsManager
    {
        ResultMessage<Product> AddProduct(Product product);

        ResultMessage<Product> DeleteProduct(Product product);

        ResultMessage<Product> EditProduct(Product product);

        ResultMessage<List<Product>> GetProductsPagedFiltered(int pageNo, int pageSize, string orderBy, string sortDirection, Expression<Func<Product, bool>> filter = null);

        ResultMessage<List<Product>> GetProductsFiltered(Expression<Func<Product, bool>> filter = null);
    }
}
