﻿using System;
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
    public class FoodBevItemViewModel : IProductItem
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
        public string UnitOfMeasurement { get; set; }
        public string CostRate { get; set; }

        private char[] delimiter = { '\'' };
        public FoodBevItemViewModel()
        {
        }
        public Dictionary<string,object> fromItemToDict()
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
            foodDict.Add("UnitOfMeasurement", this.UnitOfMeasurement);
            foodDict.Add("CostRate", this.CostRate);
            return foodDict; 
        }
        public FoodBevItemViewModel(Product product)
        {
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
                this.UnitOfMeasurement = prod[8];
                this.CostRate = prod[9];
            }
        }
        public string ConvertToItem()
        {
            
            return
                this.ProductDescription + delimiter +
                this.ProductionCode + delimiter +
                this.ProductionDate + delimiter +
                this.ExpiredDate + delimiter +
                this.NetWeight + delimiter +
                this.Ingredients + delimiter +
                this.DailyValue + delimiter +
                this.Certification + delimiter +
                this.UnitOfMeasurement + delimiter +
                this.CostRate;
        }

        public decimal unitPriceItemCalculation()
        {
            return decimal.Parse(this.CostRate) * (Convert.ToDecimal(110) / Convert.ToDecimal(100));
        }
    }
}