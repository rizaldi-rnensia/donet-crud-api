using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using Northwind.EntityFramworks;

namespace Northwind.ViewModels.ProductCustom
{
    public class MaterialViewModel
    {
        public int ProductID { get; set; }
        public string ProductDescription { get; set; }
        public int ProductionCode { get; set; }
        public string ProductionDate { get; set; }
        public string ExpiredDate { get; set; }
        public string MaterialsType { get; set; }
        public string UnitOfMeasurement { get; set; }
        public bool IsConsumable { get; set; }

        public MaterialViewModel()
        {

        }
    }
}