using InventorySystem.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Entities
{
    public class Product : BaseEntity
    {
        public int BrandID { get; set; }

        public string Model { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public int AvailableQuantity { get; set; }

        public int SoldQuantity { get; set; }

        public int MinimumQuantity { get; set; }

        public int CategoryID { get; set; }

        public virtual Brand Brand { get; set; }

        public virtual Category Category { get; set; }
    }
}
