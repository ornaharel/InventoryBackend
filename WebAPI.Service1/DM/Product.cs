using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.InventoryService.DM
{
    [ElasticsearchType(RelationName = "products")]
    public class Product
    {

        [Text(Name = "category_name")]
        public string CategoryName { get; set; }


        [Text(Name = "product_name")]
        public string ProductName { get; set; }
    }
}