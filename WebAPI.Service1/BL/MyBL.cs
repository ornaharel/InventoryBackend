using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebAPI.InventoryService.DM;

namespace WebAPI.InventoryService.BL
{
   
    public class MyBL
    {
        private const string connectionURL = "http://127.0.0.1:9200";
        private const int maxProducts = 200;
        ElasticClient client = null;
        public MyBL()
        {
            if (client == null)
            {
                var settings = new
               ConnectionSettings(new Uri(connectionURL))
               .DisableDirectStreaming();
                client = new ElasticClient(settings);
            }
        }

     
        public List<Category> GetAllCategories()
        {
            List<Category> categories = new List<Category>();
            var searchResponse = client.Search<Category>(i => i.Index("categories")
                        .MatchAll().Size(10));

            foreach (var hit in searchResponse.Hits)
            {
                categories.Add(hit.Source);
            }
            return categories;
        }

        public List<CategoryBucket> GetAllCategoryBuckets()
        {
            {
                List<CategoryBucket> categoryBuckets = new List<CategoryBucket>();
                List<Product> products = new List<Product>();
            
                var searchResponse = client.Search<Product>(i => i.Index("products")
                            .MatchAll().Size(maxProducts));


                foreach (var hit in searchResponse.Hits)
                {
                    products.Add(hit.Source);
                }

                foreach (var product in products)
                {
                    if (categoryBuckets.FindIndex(aa => aa.CategoryName == product.CategoryName) == -1)
                    {
                        categoryBuckets.Add(new CategoryBucket { CategoryName = product.CategoryName, ProductNames = new List<string>() });
                    }
                    categoryBuckets.Find(aa => aa.CategoryName == product.CategoryName).ProductNames.Add(product.ProductName);
                }
                return categoryBuckets;
            }
        }

        public string AddProduct(Product product)
        {
            var searchResponse = client.Index(product, i => i.Index("products").Refresh(Elasticsearch.Net.Refresh.WaitFor));
            return searchResponse.Id;
        }

    }
}