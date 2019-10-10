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
    public class FoodBevItemViewModel : ProductDetailViewModel
    {
        public int ProductionCode { get; set; }
        public string ProductionDate { get; set; }
        public string ExpiredDate { get; set; }
        public string NetWeight { get; set; }
        public string Ingredients { get; set; }
        public string DailyValue { get; set; }
        public string Certification { get; set; }

        public FoodBevItemViewModel(ProductDetailViewModel productDetail)
        {
            ProductID = productDetail.ProductID;
            ProductDescription = productDetail.ProductDescription;
            ProductionCode = this.ProductionCode;
            ProductionDate = this.ProductionDate;
            ExpiredDate = this.ExpiredDate;
            NetWeight = this.NetWeight;
            Ingredients = this.Ingredients;
            DailyValue = this.DailyValue;
            Certification = this.Certification;
        }

        public FoodBevItemViewModel()
        {
        }

        public string ConvertToFood(ProductDetailViewModel prodDet)
        {
            return
                prodDet.ProductDescription + "|" +
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