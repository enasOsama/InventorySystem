using InventorySystem.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Product> ProductsRepository { get; }
        IRepository<ProductItem> ProductItemsRepository { get; }
        IRepository<Brand> BrandsRepository { get; }
        IRepository<Category> CategoriesRepository { get; }
                     

        object getRepoByType(Type type);


        /// <summary>
        /// Commits all changes
        /// </summary>
        void Commit();
        /// <summary>
        /// Discards all changes that has not been commited
        /// </summary>
        void RejectChanges();
    }
}
