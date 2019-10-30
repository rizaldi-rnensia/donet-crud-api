using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using Northwind.EntityFramworks;
using Northwind.ViewModels.NewProductCustom;
using Northwind.Domain.Calculation;
using Northwind.Domain.ViewModels;
using Northwind.Domain.Models;
using Northwind.ViewModels.ProductCustom;

namespace Northwind.Controllers
{
    [RoutePrefix("api/ProductCustom")]
    public class NewProductCustomController : ApiController
    {
        //[Route("Create")]
        //[HttpPost]
        //public IHttpActionResult Create([FromBody] NewProductViewModel dataBody, string condition = null, int? userDemand = null, decimal? Duration = null, char? dlmtr=null)
        //{
        //    try
        //    {
        //        using (var db = new DB_Context())
        //        {
        //            Product product = dataBody.ConvertToProduct(condition, userDemand, Duration, dlmtr);
        //            db.Products.Add(product);
        //            db.SaveChanges();
        //            return Ok("Data Saved Successfully");
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

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
        public IHttpActionResult CalculateProductUnitPrice([FromBody] ProductDetailCalculatorParameter parameter)
        {
            try
            {
                using (var db = new DB_Context())
                {
                    var temp = db.Products.AsQueryable();
                    Dictionary<string, object> result = new Dictionary<string, object>();
                    var ListProduct = db.Products.OrderByDescending(data => data.ProductID).ToList();
                    ProductCalculator calculator = new ProductCalculator('|');

                    foreach (var item in ListProduct)
                    {
                        calculator.calculateProductUnitPrice(item, parameter);
                    }
                    db.SaveChanges();
                    return Ok("UnitPrice updated");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("Pa")]
        [HttpPost]
        public IHttpActionResult TestPreparation()
        {
            var count = 100;
            var list = new List<int>(count);
            var random = new Random();
            list.Add(0);

            for (var i = 1; i < count; i++)
            {
                var swap = random.Next(i - 1);
                list.Add(list[swap]);
                list[swap] = i;
            }
            return Ok(list);
        }

        private static bool isPrime(int n)
        {
            // Corner case 
            if (n <= 1)
                return false;

            // Check from 2 to n-1 
            for (int i = 2; i < n; i++)
                if (n % i == 0)
                    return false;

            return true;
        }

        // TEST SOLID CONTROLLER

        [Route("countInvalidProductDetail")]
        [HttpGet]
        public IHttpActionResult countInvalidProductType()
        {
            using (var db = new DB_Context())
            {
                try
                {
                    NewProductViewModel listResult = new NewProductViewModel();
                    var listProductEntity = db.Products.AsQueryable();
                    listProductEntity = listProductEntity.Where(data => 
                    data.ProductType != "FoodAndBeverageItems"
                    & data.ProductType != "MaterialItems"
                    & data.ProductType != "GarmentItems"
                    & data.ProductType != "TransportationServices"
                    & data.ProductType != "TelecommunicationServices");
                    listProductEntity.Count();
                    
                    return Ok("Jumlh ProductType yang invalid adalah : "+ listProductEntity);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        [Route("createProductWithStringProductDetail")]
        [HttpPost]
        public IHttpActionResult CreateWithString([FromBody] ProductCustomViewModel dataBody)
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

        [Route("createProductWithProductDetail")]
        [HttpPost]
        public IHttpActionResult CreateProductDetail([FromBody] ProductCustomViewModel dataBody)
        {
            try
            {
                using (var db = new DB_Context())
                {
                    Product product = dataBody.ConvertToProduct2();
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
    }
}