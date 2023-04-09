using AutoMapper;
using Nest;
using Serilog;
using System;
using System.Collections.Generic;
using System.Web.Http;
using WebAPI.InventoryService.DM;
using WebAPI.InventoryService.BL;

namespace WebAPI.InventoryService
{

    public class InventoryController : ApiController
    {

        [HttpGet]
        [Route("GetAllCategories")]
        public List<Category> GetAllCategories()
        {
            try
            {
                MyBL bl = new MyBL();
                List<Category> categories = new List<Category>();
                categories = bl.GetAllCategories();
                return categories;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("GetAllCategoryBuckets")]
        public List<CategoryBucket> GetAllCategoryBuckets()
        {
            try
            {
                List<CategoryBucket> categoryBuckets = new List<CategoryBucket>();
                MyBL bl = new MyBL();
                categoryBuckets = bl.GetAllCategoryBuckets();
                return categoryBuckets;
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        [Route("AddProduct")]
        public string AddProduct(Product product)
        {
            try
            {
                MyBL bl = new MyBL();
                string res = bl.AddProduct(product);
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
 