using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using Northwind.EntityFramworks;
using Northwind.ViewModels.ProductCustom.Items;

namespace Northwind.ViewModels.ProductCustom.Items
{
    public class MaterialViewModel : IProductItem
    {
        public int ProductID { get; set; }
        public string ProductDescription { get; set; }
        public string ProductionCode { get; set; }
        public string ProductionDate { get; set; }
        public string ExpiredDate { get; set; }
        public string MaterialsType { get; set; }
        public string IsConsumable { get; set; }
        public string UnitOfMeasurement { get; set; }
        public string CostRate { get; set; }

        char[] delimiter = { '\'' };

        public MaterialViewModel()
        {
        }

        public Dictionary<string, object> fromItemToDict()
        {
            Dictionary<string, object> materialDict = new Dictionary<string, object>();
            materialDict.Add("ProductID", this.ProductID);
            materialDict.Add("ProductDescription", this.ProductDescription);
            materialDict.Add("ProductionCode", this.ProductionCode);
            materialDict.Add("ProductionDate", this.ProductionDate);
            materialDict.Add("ExpiredDate", this.ExpiredDate);
            materialDict.Add("MaterialsType", this.MaterialsType);
            materialDict.Add("IsConsumable", this.IsConsumable);
            materialDict.Add("UnitOfMeasurement", this.UnitOfMeasurement);
            materialDict.Add("CostRate", this.CostRate);
            return materialDict;
        }

        public MaterialViewModel(Product product)
        {
            this.ProductID = product.ProductID;
            if (!string.IsNullOrEmpty(product.ProductDetail))
            {
                string[] prod = product.ProductDetail.Split(delimiter);
                this.ProductDescription = prod[0];
                this.ProductionCode = prod[1];
                this.ProductionDate = prod[2];
                this.ExpiredDate = prod[3];
                this.MaterialsType = prod[4];
                this.IsConsumable = prod[5];
                this.UnitOfMeasurement = prod[6];
                this.CostRate = prod[7];
            }
        }
        public string ConvertToItem()
        {
            return
                this.ProductDescription + delimiter +
                this.ProductionCode + delimiter +
                this.ProductionDate + delimiter +
                this.ExpiredDate + delimiter +
                this.MaterialsType + delimiter +
                this.IsConsumable + delimiter +
                this.UnitOfMeasurement + delimiter +
                this.CostRate;
                
        }

        public decimal unitPriceItemCalculation()
        {
            return decimal.Parse(this.CostRate) * (Convert.ToDecimal(110) / Convert.ToDecimal(100));
        }
    }
}