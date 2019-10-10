using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using Northwind.EntityFramworks;

namespace Northwind.ViewModels
{
    public class RegionDetailViewModel
    {
        public int? RegionID { get; set; }
        public string RegionName { get; set; }
        public string RegionLangitude { get; set; }
        public string RegionLatitude { get; set; }
        public string Country { get; set; }

       public RegionDetailViewModel()
        {

        }

        public RegionDetailViewModel(Region region)
        {
            if (region.RegionDescription.Contains("|"))
            {
                var splitData = region.RegionDescription.Split('|');
                RegionID = region.RegionID;
                RegionName = splitData[0];
                RegionLangitude = splitData[1];
                RegionLatitude = splitData[2];
                Country = splitData[3];
            }
            else
            {
                RegionID = region.RegionID;
                RegionName = region.RegionDescription;
                RegionLangitude = null;
                RegionLatitude = null;
                Country = null;
            }
        }

        public RegionDetailViewModel(List<Region> regionList)
        {
            foreach(var region in regionList)
            {
                this.RegionID = region.RegionID;

                if (!string.IsNullOrEmpty(region.RegionDescription))
                {
                    char[] delimiter = { '|' };
                    String[] regionDetailData = region.RegionDescription.Split(delimiter);
                    if (regionDetailData.Length == 4)
                    {
                        this.RegionName = regionDetailData[0];
                        this.RegionLangitude = regionDetailData[1];
                        this.RegionLatitude = regionDetailData[2];
                        this.Country = regionDetailData[3];
                    }
                }
                else
                {
                    RegionName = region.RegionDescription.Trim();
                    RegionLangitude = null;
                    RegionLatitude = null;
                    Country = null;
                }
            }
        }
        public Region convertToRegion()
        {
            char[] delimiter = { '|' };
            return new Region()
            {
                RegionID = this.RegionID,
                RegionDescription =
                    this.RegionName + delimiter[0] +
                    this.RegionLangitude + delimiter[0] +
                    this.RegionLatitude + delimiter[0] +
                    this.Country,
            };
        }

        public Territory InputData(DB_Context db)
        {
            if (this.Country.Contains("INA"))
            {
                Territory desc_terito = new Territory()
                {
                    TerritoryID = "INA-01",
                    TerritoryDescription = "Bandung adalah bagian dari Indonesia",
                    RegionID = this.RegionID
                };
                db.Territories.Add(desc_terito);
                db.SaveChanges();
                return desc_terito;
            }
            return new Territory();
        }

        public Dictionary<string, object> FinalResult(List<RegionDetailViewModel> listObject, string msg)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            result.Add("Message", msg);
            result.Add("Data", listObject);
            return (result);
        }
    }
}