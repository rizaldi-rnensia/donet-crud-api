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
        public string ProductionCode { get; set; }
        public string ProductionDate { get; set; }
        public string ExpiredDate { get; set; }
        public string MaterialsType { get; set; }
        public string UnitOfMeasurement { get; set; }
        public string IsConsumable { get; set; }

        public MaterialViewModel()
        {
        }

        public Dictionary<string, object> fromMaterialToDict()
        {
            Dictionary<string, object> materialDict = new Dictionary<string, object>();
            materialDict.Add("ProductID", this.ProductID);
            materialDict.Add("ProductDescription", this.ProductDescription);
            materialDict.Add("ProductionCode", this.ProductionCode);
            materialDict.Add("ProductionDate", this.ProductionDate);
            materialDict.Add("ExpiredDate", this.ExpiredDate);
            materialDict.Add("MaterialsType", this.MaterialsType);
            materialDict.Add("UnitOfMeasurement", this.UnitOfMeasurement);
            materialDict.Add("IsConsumable", this.IsConsumable);
            return materialDict;
        }

        public MaterialViewModel(Product product)
        {
            char[] delimiter = { '|' };
            this.ProductID = product.ProductID;
            if (!string.IsNullOrEmpty(product.ProductDetail))
            {
                string[] prod = product.ProductDetail.Split(delimiter);
                this.ProductDescription = prod[0];
                this.ProductionCode = prod[1];
                this.ProductionDate = prod[2];
                this.ExpiredDate = prod[3];
                this.MaterialsType = prod[4];
                this.UnitOfMeasurement = prod[5];
                this.IsConsumable = prod[6];
            }
        }
        public string ConvertToMateri()
        {
            return
                this.ProductDescription + "|" +
                this.ProductionCode + "|" +
                this.ProductionDate + "|" +
                this.ExpiredDate + "|" +
                this.MaterialsType + "|" +
                this.UnitOfMeasurement + "|" +
                this.IsConsumable;
        }

    }
}