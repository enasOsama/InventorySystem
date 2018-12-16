using InventorySystem.Core.SharedKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventorySystem.Core.Entities
{
    public class ProductItem : BaseEntity
    {
        public int ProductID { get; set; }

        public string SerialNumber { get; set; }

    }
}
