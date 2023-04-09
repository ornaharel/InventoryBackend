using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.InventoryService.DM
{
    public class CategoryBucket
    {
        public string CategoryName { get; set; }
        public List<string> ProductNames { get; set; }
    }
}