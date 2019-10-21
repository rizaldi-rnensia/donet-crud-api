using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using Northwind.EntityFramworks;
using Northwind.ViewModels.NewProductCustom;

namespace Northwind.Controllers
{
    [RoutePrefix("api/ProductCustom")]
    public class NewProductCustomController : ApiController
    {
        [Route("Create")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] NewProductViewModel dataBody, string condition = null, int? userDemand = null, decimal? Duration = null, char? dlmtr=null)
        {
            try
            {
                using (var db = new DB_Context())
                {
                    Product product = dataBody.ConvertToProduct(condition, userDemand, Duration, dlmtr);
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

        [Route("delete")]
        [HttpDelete]
        public IHttpActionResult Delete(int prodID)
        {
            using (var db = new DB_Context())
            {
                try
                {
                    NewProductViewModel obj = new NewProductViewModel();
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

        [Route("Read")]
        [HttpGet]
        public IHttpActionResult Read(int? prodID = null, char? dlmtr=null)
        {
            using (var db = new DB_Context())
            {
                try
                {
                    NewProductViewModel listResult = new NewProductViewModel();
                    var listProductEntity = db.Products.AsQueryable();
                    List<NewProductViewModel> listProduct = new List<NewProductViewModel>();
                    if (prodID != null)
                    {
                        listProductEntity = listProductEntity.Where(data => data.ProductID == prodID);
                    }
                    foreach (var item in listProductEntity.AsEnumerable().ToList())
                    {
                        NewProductViewModel product = new NewProductViewModel(item, dlmtr);
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

        [Route("Update")]
        [HttpPut]
        public IHttpActionResult Update()
        {
            return Ok(123);
        }

        [Route("CalculateProductUnitPrice")]
        [HttpPut]
        public IHttpActionResult CalculateProductUnitPrice()
        {
            try
            {
                using (var db = new DB_Context())
                {
                    NewProductViewModel listResult = new NewProductViewModel();
                    var listProductEntity = db.Products.AsQueryable();
                    List<NewProductViewModel> listProduct = new List<NewProductViewModel>();
                    foreach (var item in listProductEntity.AsEnumerable().ToList())
                    {
                        //NewProductViewModel product = new NewProductViewModel(item, dlmtr);
                        //product.CalculateUnitPrice();
                        //listProduct.Add(product);
                    }
                    Dictionary<string, object> finalReturn = listResult.FinalResult(listProduct, "Read Data Success");
                    return Ok(finalReturn);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}