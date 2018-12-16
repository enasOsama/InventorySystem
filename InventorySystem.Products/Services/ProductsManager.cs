using InventorySystem.Core.Entities;
using InventorySystem.Core.Interfaces;
using InventorySystem.Core.SharedKernel;
using InventorySystem.Products.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Products.Services
{
    public class ProductsManager : IProductsManager
    {
        private readonly IRepository<Product> _productsRepository;

        public ProductsManager(IUnitOfWork unitOfWork)
        {
            _productsRepository = unitOfWork.getRepoByType(typeof(IRepository<Product>)) as IRepository<Product> ?? throw new ArgumentNullException("productRepo");
        }

        public ResultMessage<Product> AddProduct(Product product)
        {
            try
            {
                _productsRepository.Insert(product);
                _productsRepository.SaveChanges();

                return new ResultMessage<Product>
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                //log
                return new ResultMessage<Product>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        public ResultMessage<Product> DeleteProduct(Product product)
        {
            try
            {
                _productsRepository.Delete(product);
                _productsRepository.SaveChanges();

                return new ResultMessage<Product>
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                //log
                return new ResultMessage<Product>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        public ResultMessage<Product> EditProduct(Product product)
        {

            try
            {
                _productsRepository.Update(product);
                _productsRepository.SaveChanges();

                return new ResultMessage<Product>
                {
                    Success = true
                };
            }
            catch (Exception ex)
            {
                //log
                return new ResultMessage<Product>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        public ResultMessage<List<Product>> GetProductsPagedFiltered(int pageNo, int pageSize, string orderBy, string sortDirection, Expression<Func<Product, bool>> filter = null)
        {
            try
            {
                return new ResultMessage<List<Product>>
                {
                    Success = true,
                    Data = _productsRepository.Get(filter)
                    .OrderBy($"{orderBy} {sortDirection}")
                    .Take(pageSize)
                    .Skip(pageNo * pageSize).ToList()
                };
            }
            catch (Exception ex)
            {
                //log
                return new ResultMessage<List<Product>>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }

        public ResultMessage<List<Product>> GetProductsFiltered(Expression<Func<Product, bool>> filter = null)
        {
            try
            {
                return new ResultMessage<List<Product>>
                {
                    Success = true,
                    Data = _productsRepository.Get(filter).ToList()
                };
            }
            catch (Exception ex)
            {
                //log
                return new ResultMessage<List<Product>>
                {
                    Success = false,
                    Message = ex.Message
                };
            }
        }


    }
}
