using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using Northwind.EntityFramworks;
using Northwind.ViewModels;
using Northwind.ViewModels.ProductCustom;

namespace Northwind.Controllers
{
    [RoutePrefix("api/ProductDetail")]
    public class ProductCustomController : ApiController
    {
        [Route("Create")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] ProductCustomViewModel dataBody)
        {
            try
            {
                using (var db = new DB_Context())
                {
                    Product product = dataBody.ConvertToProduct();
                    db.Products.Add(product);
                    db.SaveChanges();
                    return Ok("Data Saved Successfully");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("Read")]
        [HttpGet]
        public IHttpActionResult Read(int? prodID = null)
        {
            using (var db = new DB_Context())
            {
                try
                {
                    ProductCustomViewModel listResult = new ProductCustomViewModel();
                    var listProductEntity = db.Products.AsQueryable();
                    List<ProductCustomViewModel> listProduct = new List<ProductCustomViewModel>();
                    if(prodID != null)
                    {
                        listProductEntity = listProductEntity.Where(data => data.ProductID == prodID);
                    }
                    foreach (var item in listProductEntity.AsEnumerable().ToList())
                    {
                        ProductCustomViewModel product = new ProductCustomViewModel(item);
                        listProduct.Add(product);
                    }
                    Dictionary<string, object> finalReturn = listResult.FinalResult(listProduct, "Read Data Success");
                    return Ok(finalReturn);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        [Route("delete")]
        [HttpDelete]
        public IHttpActionResult Delete(int prodID)
        {
            using (var db = new DB_Context())
            {
                try
                {
                    ProductCustomViewModel obj = new ProductCustomViewModel();
                    Product product = db.Products.Where(data => data.ProductID == prodID).FirstOrDefault();
                    db.Products.Remove(product);
                    db.SaveChanges();
                    return Ok(obj.FinalResult(null, "Delete data Success"));
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        [Route("getTransportationCostCalculation")]
        [HttpGet]
        public IHttpActionResult CostCalculation(string condition, int userdemand)
        {
            using (var db = new DB_Context())
            {
                try
                {
                    var tem = db.Products.AsQueryable();
                    Dictionary<string, object> result = new Dictionary<string, object>();
                    List<CostCalculationViewModel> listProduct = new List<CostCalculationViewModel>();
                    tem = tem.Where(data => data.ProductType.Contains("TransportationServices"));
                    var listCostEntity = tem.AsEnumerable().ToList();
                    foreach (var item in listCostEntity)
                    {
                        CostCalculationViewModel product = new CostCalculationViewModel(item, condition, userdemand);
                        listProduct.Add(product);
                    }
                    result.Add("Message", "Read Data Success");
                    result.Add("Data", listProduct);
                    return Ok(result);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}