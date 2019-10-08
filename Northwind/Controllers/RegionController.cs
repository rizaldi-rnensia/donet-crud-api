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
    
    [RoutePrefix("api/Region")]
    public class RegionController : ApiController
    {
        [Route("Create")]
        [HttpPost]
        public IHttpActionResult Create([FromBody] RegionViewModel dataBody)
        {
            using (var db = new DB_Context())
            {
                try
                {
                    Dictionary<string, object> result = new Dictionary<string, object>();
                    List<RegionViewModel> regionTemp = new List<RegionViewModel>();
                    string notif = "Insert data success";
                    Region newRegion = new Region()
                    {
                        RegionID = dataBody.RegionID,
                        RegionDescription = dataBody.RegionName+"|"+dataBody.RegionLangitude+"|"+dataBody.RegionLatitude+"|"+dataBody.Country
                    };
                    //if (newRegion.RegionDescription.Substring(newRegion.RegionDescription.Length - 3) == "INA")
                    if (dataBody.Country.Contains("INA"))
                    {
                        Territory newTeritory = new Territory()
                        {
                            TerritoryID = "INA-01",
                            TerritoryDescription = "Bandung salah satu wilayah yang berada di indonesia",
                            RegionID = dataBody.RegionID
                        };
                        db.Territories.Add(newTeritory);
                        result.Add("data teritory", newTeritory);
                        notif = "Insert data success with Teritory added";
                    };
                    //db.Regions.Where(s => s.RegionID == newRegion.RegionID);
                    result.Add("data region", newRegion);
                    result.Add("Message", notif);
                    db.Regions.Add(newRegion);
                    db.SaveChanges();

                    return Ok(result);
                }
                catch (Exception)
                {
                    throw;
                }
            }   
        }

        [Route("ReadAll")]
        [HttpGet]
        public IHttpActionResult ReadAll(int? regID = null)
        {
            using (var db = new DB_Context())
            {
                try
                {
                    Dictionary<string, object> result = new Dictionary<string, object>();
                    var listRegionEntity = db.Regions.AsQueryable();
                    List<RegionViewModel> listRegion = new List<RegionViewModel>();
                    if(regID != null)
                    {
                        listRegionEntity = listRegionEntity.Where(data => data.RegionID == regID);
                    }
                    foreach(var item in listRegionEntity.AsEnumerable().ToList())
                    {
                        RegionViewModel region = new RegionViewModel(item);
                        listRegion.Add(region);
                    }
                    result.Add("Message", "Read data success");
                    result.Add("Data : ", listRegion);
                    return Ok(result);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }


        [Route("Update")]
        [HttpPut]
        public IHttpActionResult Update([FromBody] RegionViewModel dataBody)
        {
            using (var db = new DB_Context())
            {
                try
                {
                    Dictionary<string, object> result = new Dictionary<string, object>();
                    List<RegionViewModel> listRegion = new List<RegionViewModel>();
                    Region regionTemp = db.Regions.Find(dataBody.RegionID);
                    regionTemp.RegionID = dataBody.RegionID;
                    regionTemp.RegionDescription = dataBody.RegionName + "|" + dataBody.RegionLangitude + "|" + dataBody.RegionLatitude + "|" + dataBody.Country;
                    RegionViewModel region = new RegionViewModel(regionTemp);
                    listRegion.Add(region);
                    db.SaveChanges();
                    result.Add("Message", "Update data success");
                    result.Add("data", listRegion);
                    return Ok(result);
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }

        [Route("Delete")]
        [HttpDelete]
        public IHttpActionResult Delete(int regID)
        {
            using (var db = new DB_Context())
            {
                try
                {
                    Dictionary<string, object> result = new Dictionary<string, object>();
                    Region region = db.Regions.Where(data => data.RegionID == regID).FirstOrDefault();
                    db.Regions.Remove(region);
                    db.SaveChanges();
                    result.Add("message", "Delete data success");
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