using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using Northwind.EntityFramworks;
using Northwind.ViewModels;

namespace Northwind.Controllers
{
    [RoutePrefix("api/Product")]
    public class ProductController : ApiController
    {
        // ================
        // API FOR READ ALL
        // ================
        [Route("ReadAll")]
        [HttpGet]
        public IHttpActionResult ReadAll()
        {
            // membuat koneksi DB
            var db = new DB_Context();

            try
            {
                // untuk mengambil semua data entity dan merubahnya menjadi list.
                var listProductEntity = db.Products.ToList();

                // variable List untuk menampung view model
                List<ProductViewModel> listProduct = new List<ProductViewModel>();

                // Dictionary(Map) untuk kebutuhan hasil response (jika dibutuhkan)
                Dictionary<string, object> result = new Dictionary<string, object>();

                //mapping entity ke View Model, dan menambahkan nya kedalam list View Model
                foreach (var item in listProductEntity)
                {
                    ProductViewModel product = new ProductViewModel()
                    {
                        ProductID = item.ProductID,
                        ProductName = item.ProductName,
                        SupplierID = item.SupplierID,
                        CategoryID = item.CategoryID,
                        QuantityPerUnit = item.QuantityPerUnit,
                        UnitPrice = item.UnitPrice,
                        UnitsInStock = item.UnitsInStock,
                        UnitsOnOrder = item.UnitsOnOrder,
                        ReorderLevel = item.ReorderLevel,
                        Discontinued = item.Discontinued
                    };

                    // menambahkan object View Model ke list View Model
                    listProduct.Add(product);
                };
                // menambahkan object ke dictionary
                result.Add("Message", "Read data success");
                result.Add("Data : ", listProduct);
                db.Dispose();
                // return data response
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // ==============
        // API FOR CREATE
        // ==============
        [Route("Create")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] ProductViewModel dataBody)
        {
            var db = new DB_Context();

            try
            {
                Dictionary<string, object> result = new Dictionary<string, object>();

                // Buat Object dan menginisialisasi dengan data dari body
                Product newProduct = new Product()
                {
                    ProductID = dataBody.ProductID,
                    ProductName = dataBody.ProductName,
                    SupplierID = dataBody.SupplierID,
                    CategoryID = dataBody.CategoryID,
                    QuantityPerUnit = dataBody.QuantityPerUnit,
                    UnitPrice = dataBody.UnitPrice,
                    UnitsInStock = dataBody.UnitsInStock,
                    UnitsOnOrder = dataBody.UnitsOnOrder,
                    ReorderLevel = dataBody.ReorderLevel,
                    Discontinued = dataBody.Discontinued
                };

                // menambahkan kategori baru ke Category Entity Database
                db.Products.Add(newProduct);
                // method yang digunakan untuk menyimpan perubahan baru di database
                db.SaveChanges();
                db.Dispose();
                result.Add("Message", "Insert data success");
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // ==============
        // API FOR UPDATE
        // ==============
        [Route("Update")]
        [HttpPut]
        public IHttpActionResult Update([FromBody] ProductViewModel dataBody)
        {
            // membuat koneksi DB
            var db = new DB_Context();

            try
            {
                Dictionary<string, object> result = new Dictionary<string, object>();

                // Buat Object dan menginisialisasi dengan data dari database menggunakan method Find(Primary Key)
                Product product = db.Products.Find(dataBody.ProductID);
                // inisialisasi data yang akan dirubah
                product.ProductID = dataBody.ProductID;
                product.ProductName = dataBody.ProductName;
                product.SupplierID = dataBody.SupplierID;
                product.CategoryID = dataBody.CategoryID;
                product.QuantityPerUnit = dataBody.QuantityPerUnit;
                product.UnitPrice = dataBody.UnitPrice;
                product.UnitsInStock = dataBody.UnitsInStock;
                product.UnitsOnOrder = dataBody.UnitsOnOrder;
                product.ReorderLevel = dataBody.ReorderLevel;
                product.Discontinued = dataBody.Discontinued;

                db.SaveChanges();

                db.Dispose();
                result.Add("Message", "Update data success");
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // ==============
        // API FOR DELETE
        // ==============
        [Route("Delete")]
        [HttpDelete]
        public IHttpActionResult Delete(int productId)
        {
            // membuat koneksi DB
            var db = new DB_Context();


            try
            {
                Dictionary<string, object> result = new Dictionary<string, object>();

                // Buat object dan menginisialisasi dengan data dari database menggunakan method Find (Primary Key)
                Product product = db.Products.Where(data => data.ProductID == productId).FirstOrDefault();

                // remove data yang diinginkan
                db.Products.Remove(product);
                //simpan perubahan

                result.Add("Message", "Delete data success");
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // ===================
        // API FOR CUSTOM READ
        // ===================
        [Route("CustRead")]
        [HttpGet]
        public IHttpActionResult CustRead()
        {
            using(var db = new DB_Context())
            {
                try
                {
                    // Dictionary(Map) untuk kebutuhan hasil response (jika dibutuhkan)
                    Dictionary<string, object> result = new Dictionary<string, object>();

                    // CARI MAX  PRODUCT
                    var maxPriceProduct = db.Products.Max(data => data.UnitPrice);
                    var maxProducts = db.Products
                        .Where(data => data.UnitPrice == maxPriceProduct).ToList()
                        .Select(item => new ProductViewModel(item));

                    // CARI MIN PRODUCT
                    var minPriceProduct = db.Products.Min(data => data.UnitPrice);
                    var minProducts = db.Products
                        .Where(data => data.UnitPrice == minPriceProduct).ToList()
                        .Select(item => new ProductViewModel(item));

                    // CARI PRODUCT DGN HARGA DIBAWAH RATA RATA
                    IEnumerable<ProductViewModel> listProductUnderAvg = db.Products
                        .Where(data => data.UnitPrice < db.Products.Average(item => item.UnitPrice))
                        .ToList().Select(item => new ProductViewModel(item));

                    

                    result.Add("Most Expensive Product Price", maxProducts);
                    result.Add("Most Cheapest Product Price", minProducts);
                    result.Add("Product that below of the Average", listProductUnderAvg);


                    return Ok(result);

                }
                catch (Exception)
                {
                    throw;
                }
            }
            
        }

        [Route("FilterBy")]
        [HttpGet]
        public IHttpActionResult FilterBy(string namaProduct=null, string namaCategory=null, decimal? price=null)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            using (var db = new DB_Context())
            {
                if (namaProduct != null)
                {
                    var listProdukEntity = db.Products.ToList();
                    var listProduk = listProdukEntity.Where(s => s.ProductName.Contains(namaProduct))
                        .Select(item => new ProductViewModel(item));
                    result.Add("search by product name ", listProduk);
                }
                else if (namaCategory != null)
                {
                    var listProdukEntity = db.Products.ToList();
                    var listCategoryEntity = db.Categories.ToList();

                    var innerJoinQuery =
                    from prod in listProdukEntity
                    join cat in listCategoryEntity on prod.CategoryID equals cat.CategoryID
                    where cat.CategoryName.Contains(namaCategory)
                    select new {
                        ProductID = prod.ProductID,
                        ProductName = prod.ProductName,
                        SupplierID = prod.SupplierID,
                        CategoryID = prod.CategoryID,
                        CategoryName = cat.CategoryName,
                        QuantityPerUnit = prod.QuantityPerUnit,
                        UnitPrice = prod.UnitPrice,
                        UnitsInStock = prod.UnitsInStock,
                        UnitsOnOrder = prod.UnitsOnOrder,
                        ReorderLevel = prod.ReorderLevel,
                        Discontinued = prod.Discontinued
                    };
                    result.Add("search by category name ", innerJoinQuery);

                }
                else if (price != null)
                {
                    var listProdukEntity = db.Products.ToList();
                    var listProduk = listProdukEntity.Where(s => s.UnitPrice < price)
                        .Select(item => new ProductViewModel(item));
                    result.Add("search by product name ", listProduk);
                }
                else
                {
                    return Ok("filter kosong !");
                }
            }
            return Ok(result);
            
        }

        [Route("Filter")]
        [HttpGet]
        public IHttpActionResult Filter(string namaProduct = null, string namaCategory = null, decimal? price = null)
        {
            using (var db = new DB_Context())
            {
                Dictionary<string, object> result = new Dictionary<string, object>();
                var temp = db.Products.AsQueryable();
                if(namaProduct != null)
                {
                    temp = temp.Where(data => data.ProductName.ToLower().Contains(namaProduct.ToLower()));
                }
                if(namaCategory != null)
                {
                    temp = temp.Where(data => data.Category.CategoryName.ToLower().Contains(namaCategory.ToLower()));
                }
                if(price != null)
                {
                    temp = temp.Where(data => data.UnitPrice < price);
                }
                var listProduct = temp.ToList().Select(data => new ProductViewModel(data));

                result.Add("mesage", "Read data success");
                result.Add("data", listProduct);
                return Ok(result);
            }
                
        }
    }
}