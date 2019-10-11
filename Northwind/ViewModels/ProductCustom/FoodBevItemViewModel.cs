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
    public class FoodBevItemViewModel
    {
        public int ProductID { get; set; }
        public string ProductDescription { get; set; }
        public string ProductionCode { get; set; }
        public string ProductionDate { get; set; }
        public string ExpiredDate { get; set; }
        public string NetWeight { get; set; }
        public string Ingredients { get; set; }
        public string DailyValue { get; set; }
        public string Certification { get; set; }
        


        public FoodBevItemViewModel()
        {
        }
        public Dictionary<string,object> fromFoodToDict()
        {
            Dictionary<string, object> foodDict = new Dictionary<string, object>();
            foodDict.Add("ProductID", this.ProductID);
            foodDict.Add("ProductDescription", this.ProductDescription);
            foodDict.Add("ProductionCode", this.ProductionCode);
            foodDict.Add("ProductionDate", this.ProductionDate);
            foodDict.Add("ExpiredDate", this.ExpiredDate);
            foodDict.Add("NetWeight", this.NetWeight);
            foodDict.Add("Ingredients", this.Ingredients);
            foodDict.Add("DailyValue", this.DailyValue);
            foodDict.Add("Certification", this.Certification);
            return foodDict; 
        }
        public FoodBevItemViewModel(Product product)
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
                this.NetWeight = prod[4];
                this.Ingredients = prod[5];
                this.DailyValue = prod[6];
                this.Certification = prod[7];
            }
        }
        public string ConvertToFood()
        {
            return
                //this.ProductID + "|" +
                this.ProductDescription + "|" +
                this.ProductionCode + "|" +
                this.ProductionDate + "|" +
                this.ExpiredDate + "|" +
                this.NetWeight + "|" +
                this.Ingredients + "|" +
                this.DailyValue + "|" +
                this.Certification;
        }
    }
}