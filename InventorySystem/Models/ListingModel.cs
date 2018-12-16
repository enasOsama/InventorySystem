using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InventorySystem.Models
{
    public class ListingModel
    {
        public int PageNo { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; }
        public string OderDirection { get; set; }
        public string SearchText { get; set; }
    }
}