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
        public string ProductID { get; set; }
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

        public MaterialViewModel(Product product)
        {
            char[] delimiter = { '|' };
            string[] prod = product.ProductDetail.Split(delimiter);
            this.ProductID = product.ProductID.ToString();
            if (prod.Length == 8)
            {
                //this.ProductID = prod[0];
                this.ProductDescription = prod[1];
                this.ProductionCode = prod[2];
                this.ProductionDate = prod[3];
                this.ExpiredDate = prod[4];
                this.MaterialsType = prod[5];
                this.UnitOfMeasurement = prod[6];
                this.IsConsumable = prod[7];
            }
        }
        public string ConvertToMateri()
        {
            return
                this.ProductID + "|" +
                this.ProductDescription + "|" +
                this.ProductionCode + "|" +
                this.ProductionDate + "|" +
                this.ExpiredDate + "|" +
                this.MaterialsType + "|" +
                this.UnitOfMeasurement + "|" +
                this.IsConsumable;
        }

        public Dictionary<string, object> fromFoodToMaterial()
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
    }
}