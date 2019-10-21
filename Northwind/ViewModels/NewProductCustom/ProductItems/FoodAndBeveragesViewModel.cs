using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Northwind.EntityFramworks;
using Northwind.ViewModels.NewProductCustom.Interface;

namespace Northwind.ViewModels.NewProductCustom.ProductItems
{
    public class FoodAndBeveragesViewModel : ProductDetailViewModel1, IProductItems
    {
        public string ProductionDate { get; set; }
        public string ExpiredDate { get; set; }
        public string NetWeight { get; set; }
        public string Ingredients { get; set; }
        public string DailyValue { get; set; }
        public string Certification { get; set; }
        public string UnitOfMeasurement { get; set; }
        public string CostRate { get; set; }
        public FoodAndBeveragesViewModel()
        {

        }
        public FoodAndBeveragesViewModel(Product product, char? dlmtr)
        {
            this.ProductID = product.ProductID;
            if (!string.IsNullOrEmpty(product.ProductDetail))
            {
                string[] prod = product.ProductDetail.Split(Delimiter(dlmtr));
                this.ProductDescription = prod[0];
                this.UnitProvit = prod[1];
                this.ProductionCode = prod[2];
                this.ProductionDate = prod[3];
                this.ExpiredDate = prod[4];
                this.NetWeight = prod[5];
                this.Ingredients = prod[6];
                this.DailyValue = prod[7];
                this.Certification = prod[8];
                this.UnitOfMeasurement = prod[9];
                this.CostRate = prod[10];
            }
        }

        public string ConvertToItem(char? dlmtr)
        {
            return
                this.ProductDescription + Delimiter(dlmtr) +
                this.UnitProvit + Delimiter(dlmtr) +
                this.ProductionCode + Delimiter(dlmtr) +
                this.ProductionDate + Delimiter(dlmtr) +
                this.ExpiredDate + Delimiter(dlmtr) +
                this.NetWeight + Delimiter(dlmtr) +
                this.Ingredients + Delimiter(dlmtr) +
                this.DailyValue + Delimiter(dlmtr) +
                this.Certification + Delimiter(dlmtr) +
                this.UnitOfMeasurement + Delimiter(dlmtr) +
                this.CostRate;
        }

        public Dictionary<string, object> FromItemToDict()
        {
            Dictionary<string, object> foodDict = new Dictionary<string, object>();
            foodDict.Add("ProductID", this.ProductID);
            foodDict.Add("ProductDescription", this.ProductDescription);
            foodDict.Add("UnitProvit", this.UnitProvit);
            foodDict.Add("ProductionCode", this.ProductionCode);
            foodDict.Add("ProductionDate", this.ProductionDate);
            foodDict.Add("ExpiredDate", this.ExpiredDate);
            foodDict.Add("NetWeight", this.NetWeight);
            foodDict.Add("Ingredients", this.Ingredients);
            foodDict.Add("DailyValue", this.DailyValue);
            foodDict.Add("Certification", this.Certification);
            foodDict.Add("UnitOfMeasurement", this.UnitOfMeasurement);
            foodDict.Add("CostRate", this.CostRate);
            return foodDict;
        }

        public char Delimiter(char? dlmtr)
        {
            if (dlmtr!=null)
            {
                return Convert.ToChar(dlmtr);
            }
            else
            {
                return '|';
            }
        }


        public decimal UnitPriceItemCalculation()
        {
            return decimal.Parse(this.CostRate) * (Convert.ToDecimal(110) / Convert.ToDecimal(100));
        }
    }
}