using InventorySystem.Core.Entities;
using InventorySystem.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly InventoryDBContext _dbContext;

        #region repositories
        private IRepository<Brand> _brandsRepo;
        public IRepository<Brand> BrandsRepository
        {
            get
            {
                if (_brandsRepo == null)
                {
                    _brandsRepo = new Repository<Brand>(_dbContext);
                }
                return _brandsRepo;
            }
        }

        private IRepository<Category> _categoriesRepo;
        public IRepository<Category> CategoriesRepository
        {
            get
            {
                if (_categoriesRepo == null)
                {
                    _categoriesRepo = new Repository<Category>(_dbContext);
                }
                return _categoriesRepo;
            }
        }

        private IRepository<Product> _productsRepo;
        public IRepository<Product> ProductsRepository
        {
            get
            {
                if (_productsRepo == null)
                {
                    _productsRepo = new Repository<Product>(_dbContext);
                }
                return _productsRepo;
            }
        }

        private IRepository<ProductItem> _productItemsRepo;
        public IRepository<ProductItem> ProductItemsRepository
        {
            get
            {
                if (_productItemsRepo == null)
                {
                    _productItemsRepo = new Repository<ProductItem>(_dbContext);
                }
                return _productItemsRepo;
            }
        }
        #endregion

        public UnitOfWork(InventoryDBContext context)
        {
            _dbContext = context;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public void RejectChanges()
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries()
              .Where(e => e.State != EntityState.Unchanged))
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.Reload();
                        break;
                }
            }
        }

        public object getRepoByType(Type type)
        {
            PropertyInfo[] properties = typeof(UnitOfWork).GetProperties();
            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType == type)
                {


                    return property.GetValue(this);

                }
            }

            return null;
        }
    }
}
