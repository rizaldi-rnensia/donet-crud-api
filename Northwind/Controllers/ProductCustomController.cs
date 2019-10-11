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
                    var tmp = db.Products.Where(dt => dt.ProductName.Equals(product.ProductName) && dt.ProductType.Equals(product.ProductType)).FirstOrDefault();
                    return Ok("SAVED");
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
    }
}