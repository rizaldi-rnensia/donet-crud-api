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
    public class GarmentViewModel
    {
        public int ProductID { get; set; }
        public string ProductDescription { get; set; }
        public string ProductionCode { get; set; }
        public string ProductionDate { get; set; }
        public string GarmentsType { get; set; }
        public string Fabrics { get; set; }
        public string GenderRelated { get; set; }
        public string IsWaterProof { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string AgeGroup { get; set; }

        public GarmentViewModel()
        {

        }

        public GarmentViewModel(Product product)
        {
            char[] delimiter = { '|' };
            this.ProductID = product.ProductID;
            if (!string.IsNullOrEmpty(product.ProductDetail))
            {
                string[] prod = product.ProductDetail.Split(delimiter);
                this.ProductDescription = prod[0];
                this.ProductionCode = prod[1];
                this.ProductionDate = prod[2];
                this.GarmentsType = prod[3];
                this.Fabrics = prod[4];
                this.GenderRelated = prod[5];
                this.IsWaterProof = prod[6];
                this.Color = prod[7];
                this.Size = prod[8];
                this.AgeGroup = prod[9];
            }
        }
        public string ConvertToGarment()
        {
            return
                this.ProductDescription + "|" +
                this.ProductionCode + "|" +
                this.ProductionDate + "|" +
                this.GarmentsType + "|" +
                this.Fabrics + "|" +
                this.GenderRelated + "|" +
                this.IsWaterProof + "|" +
                this.Color + "|" +
                this.Size + "|" +
                this.AgeGroup;
        }

        public Dictionary<string, object> fromGarmentToDict()
        {
            Dictionary<string, object> garmentDict = new Dictionary<string, object>();
            garmentDict.Add("ProductID", this.ProductID);
            garmentDict.Add("ProductDescription", this.ProductDescription);
            garmentDict.Add("ProductionCode", this.ProductionCode);
            garmentDict.Add("ProductionDate", this.ProductionDate);
            garmentDict.Add("GarmentsType", this.GarmentsType);
            garmentDict.Add("Fabrics", this.Fabrics);
            garmentDict.Add("GenderRelated", this.GenderRelated);
            garmentDict.Add("IsWaterProof", this.IsWaterProof);
            garmentDict.Add("Color", this.Color);
            garmentDict.Add("Size", this.Size);
            garmentDict.Add("AgeGroup", this.AgeGroup);
            return garmentDict;
        }
    }
}