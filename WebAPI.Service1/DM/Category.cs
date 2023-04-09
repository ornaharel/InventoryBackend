using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.InventoryService.DM
{
    [ElasticsearchType(RelationName = "categories")]
    public class Category
    {

        [Text(Name = "category_name")]
        public string CategoryName { get; set; }
    }
}