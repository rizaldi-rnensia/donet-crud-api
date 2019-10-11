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
    public class CostCalculationViewModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string CostCalculationMethod { get; set; }
        public int CostCalculation { get; set; }
        private int CostRate { get; set; }
        private int RouteMilleage { get; set; }

        public CostCalculationViewModel()
        {

        }

        public CostCalculationViewModel(Product product, string condition, int userDemand)
        {
            char[] delimiter = { '|' };
            this.ProductID = product.ProductID;
            if (!string.IsNullOrEmpty(product.ProductDetail))
            {
                string[] prod = product.ProductDetail.Split(delimiter);

                this.ProductName = product.ProductName;
                this.RouteMilleage = Int32.Parse(prod[3]);
                this.CostCalculationMethod = prod[4];
                this.CostRate = Int32.Parse(prod[5]);
                this.CostCalculation = rateCostCalculation(condition, userDemand);

            }
        }

        public int rateCostCalculation(string Condition, int UserDemand)
        {
            var hasil = 0;
            if (CostCalculationMethod.Contains("FixPerRoute"))
            {
                hasil = 1 * CostRate;
            }
            if (CostCalculationMethod.Contains("PerMiles"))
            {
                hasil = RouteMilleage * (CostRate / 2);
            }
            if (CostCalculationMethod.Contains("PerMilesWithCondition"))
            {
                var nilai = 0;
                if (Condition == "GoodWeather")
                {
                    nilai = 5;
                }
                else if (Condition == "BadWeather")
                {
                    nilai = 15;
                }
                hasil = (RouteMilleage * CostRate / 2) * (((nilai + (UserDemand / 50)) + 95)) / 100;
            }
            return hasil;
        }
    }
}