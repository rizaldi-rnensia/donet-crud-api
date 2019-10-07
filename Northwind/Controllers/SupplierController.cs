using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Northwind.EntityFramworks;
using Northwind.ViewModels;

namespace Northwind.Controllers
{
    [RoutePrefix("api/Supplier")]
    public class SupplierController : ApiController
    {
        // ================
        // API FOR READ ALL
        // ================
        [Route("ReadAll")]
        [HttpGet]
        public IHttpActionResult ReadAll()
        {
            // membuat koneksi DB
            using(var db = new DB_Context()){
                try
                {
                    // untuk mengambil semua data entity dan merubahnya menjadi list.
                    var listSupplierEntity = db.Suppliers.ToList();

                    // variable List untuk menampung view model
                    List<SupplierViewModel> listSupplier = new List<SupplierViewModel>();

                    // Dictionary(Map) untuk kebutuhan hasil response (jika dibutuhkan)
                    Dictionary<string, object> result = new Dictionary<string, object>();

                    //mapping entity ke View Model, dan menambahkan nya kedalam list View Model
                    foreach (var item in listSupplierEntity)
                    {
                        SupplierViewModel supplier = new SupplierViewModel()
                        {
                            SupplierID = item.SupplierID,
                            CompanyName = item.CompanyName,
                            ContactName = item.ContactName,
                            ContactTitle = item.ContactTitle,
                            Address = item.Address,
                            City = item.City,
                            Region = item.Region,
                            PostalCode = item.PostalCode,
                            Country = item.Country,
                            Phone = item.Phone,
                            Fax = item.Fax,
                            HomePage = item.HomePage

                        };

                        // menambahkan object View Model ke list View Model
                        listSupplier.Add(supplier);
                    };
                    // menambahkan object ke dictionary
                    result.Add("Message", "Read data success");
                    result.Add("Data : ", listSupplier);
                    // return data response
                    return Ok(result);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        // ==============
        // API FOR CREATE
        // ==============
        [Route("Create")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] CategoryViewModel dataBody)
        {
            var db = new DB_Context();

            try
            {
                Dictionary<string, object> result = new Dictionary<string, object>();

                // Buat Object dan menginisialisasi dengan data dari body
                Category newCategory = new Category()
                {
                    CategoryID = dataBody.CategoryID,
                    CategoryName = dataBody.CategoryName,
                    Description = dataBody.Description,
                    Picture = dataBody.picture
                };

                // menambahkan kategori baru ke Category Entity Database
                db.Categories.Add(newCategory);
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
        public IHttpActionResult Update([FromBody] CategoryViewModel dataBody)
        {
            // membuat koneksi DB
            var db = new DB_Context();

            try
            {
                Dictionary<string, object> result = new Dictionary<string, object>();

                // Buat Object dan menginisialisasi dengan data dari database menggunakan method Find(Primary Key)
                Category category = db.Categories.Find(dataBody.CategoryID);
                // inisialisasi data yang akan dirubah
                category.CategoryID = dataBody.CategoryID;
                category.CategoryName = dataBody.CategoryName;
                category.Description = dataBody.Description;
                category.Picture = dataBody.picture;

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
        public IHttpActionResult Delete(int categoryId)
        {
            // membuat koneksi DB
            var db = new DB_Context();


            try
            {
                Dictionary<string, object> result = new Dictionary<string, object>();

                // Buat object dan menginisialisasi dengan data dari database menggunakan method Find (Primary Key)
                Category category = db.Categories.Where(data => data.CategoryID == categoryId).FirstOrDefault();

                // remove data yang diinginkan
                db.Categories.Remove(category);
                //simpan perubahan

                result.Add("Message", "Delete data success");
                return Ok(result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}