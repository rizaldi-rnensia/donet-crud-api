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
    public class RegionViewModel
    {
        public int? RegionID { get; set; }

        public string RegionName { get; set; }
        public string RegionLangitude { get; set; }
        public string RegionLatitude { get; set; }
        public string Country { get; set; }

        public RegionViewModel()
        {

        }

        public RegionViewModel(Region data)
        {
            if (data.RegionDescription.Contains("|"))
            {
                var splitData = data.RegionDescription.Split('|');
                RegionID = data.RegionID;
                RegionName = splitData[0];
                RegionLangitude = splitData[1];
                RegionLatitude = splitData[2];
                Country = splitData[3];
            }
            else
            {
                RegionID = data.RegionID;
                RegionName = data.RegionDescription;
                RegionLangitude = null;
                RegionLatitude = null;
                Country = null;
            }
        }
    }
}