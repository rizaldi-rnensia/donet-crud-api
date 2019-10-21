using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Northwind.ViewModels.NewProductCustom.Interface;
using Northwind.EntityFramworks;

namespace Northwind.ViewModels.NewProductCustom.ProductItems
{
    public class GarmentViewModel : ProductDetailViewModel1, IProductItems
    {
        
        public string ProductionDate { get; set; }
        public string GarmentsType { get; set; }
        public string Fabrics { get; set; }
        public string GenderRelated { get; set; }
        public string IsWaterProof { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string AgeGroup { get; set; }
        public string UnitOfMeasurement { get; set; }
        public string CostRate { get; set; }

        public GarmentViewModel()
        {

        }
        public GarmentViewModel(Product product, char? dlmtr)
        {
            this.ProductID = product.ProductID;
            if (!string.IsNullOrEmpty(product.ProductDetail))
            {
                string[] prod = product.ProductDetail.Split(Delimiter(dlmtr));
                this.ProductDescription = prod[0];
                this.UnitProvit = prod[1];
                this.ProductionCode = prod[2];
                this.ProductionDate = prod[3];
                this.GarmentsType = prod[4];
                this.Fabrics = prod[5];
                this.GenderRelated = prod[6];
                this.IsWaterProof = prod[7];
                this.Color = prod[8];
                this.Size = prod[9];
                this.AgeGroup = prod[10];
                this.UnitOfMeasurement = prod[11];
                this.CostRate = prod[12];
            }
        }

        public Dictionary<string, object> FromItemToDict()
        {
            Dictionary<string, object> garmentDict = new Dictionary<string, object>();
            garmentDict.Add("ProductID", this.ProductID);
            garmentDict.Add("ProductDescription", this.ProductDescription);
            garmentDict.Add("UnitProvit", this.UnitProvit);
            garmentDict.Add("ProductionCode", this.ProductionCode);
            garmentDict.Add("ProductionDate", this.ProductionDate);
            garmentDict.Add("GarmentsType", this.GarmentsType);
            garmentDict.Add("Fabrics", this.Fabrics);
            garmentDict.Add("GenderRelated", this.GenderRelated);
            garmentDict.Add("IsWaterProof", this.IsWaterProof);
            garmentDict.Add("Color", this.Color);
            garmentDict.Add("Size", this.Size);
            garmentDict.Add("AgeGroup", this.AgeGroup);
            garmentDict.Add("UnitOfMeasurement", this.UnitOfMeasurement);
            garmentDict.Add("CostRate", this.CostRate);
            return garmentDict;
        }

        public string ConvertToItem(char? dlmtr)
        {
            return
                this.ProductDescription + Delimiter(dlmtr) +
                this.UnitProvit + Delimiter(dlmtr) +
                this.ProductionCode + Delimiter(dlmtr) +
                this.ProductionDate + Delimiter(dlmtr) +
                this.GarmentsType + Delimiter(dlmtr) +
                this.Fabrics + Delimiter(dlmtr) +
                this.GenderRelated + Delimiter(dlmtr) +
                this.IsWaterProof + Delimiter(dlmtr) +
                this.Color + Delimiter(dlmtr) +
                this.Size + Delimiter(dlmtr) +
                this.AgeGroup + Delimiter(dlmtr) +
                this.UnitOfMeasurement + Delimiter(dlmtr) +
                this.CostRate;
        }

        public decimal UnitPriceItemCalculation()
        {
            return decimal.Parse(this.CostRate) * (Convert.ToDecimal(110) / Convert.ToDecimal(100));
        }

        public char Delimiter(char? dlmtr)
        {
            if (dlmtr != null)
            {
                return Convert.ToChar(dlmtr);
            }
            else
            {
                return '|';
            }
        }
    }
}