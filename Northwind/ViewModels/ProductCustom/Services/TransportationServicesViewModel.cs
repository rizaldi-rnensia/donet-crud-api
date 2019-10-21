using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using Northwind.EntityFramworks;
using Northwind.ViewModels.ProductCustom.Services;
using AutoMapper;

namespace Northwind.ViewModels.ProductCustom.Services
{
    public class TransportationServicesViewModel : IProductService
    {
        public int ProductID { get; set; }
        public string ProductDescription { get; set; }
        public string VehicleType { get; set; }
        public string RoutePath { get; set; }
        public string RouteMilleage { get; set; }
        public string CostCalculationMethod { get; set; }
        public string CostRate { get; set; }

        public char Delimiter()
        {
            return '\'';
        }

        public TransportationServicesViewModel()
        {

        }

        public TransportationServicesViewModel(Product product)
        {
            this.ProductID = product.ProductID;
            if (!string.IsNullOrEmpty(product.ProductDetail))
            {
                string[] prod = product.ProductDetail.Split(Delimiter());
                this.ProductDescription = prod[0];
                this.VehicleType = prod[1];
                this.RoutePath = prod[2];
                this.RouteMilleage = prod[3];
                this.CostCalculationMethod = prod[4];
                this.CostRate = prod[5];
            }
        }

        public Dictionary<string, object> fromServToDict()
        {
            Dictionary<string, object> transDict = new Dictionary<string, object>();
            transDict.Add("ProductID", this.ProductID);
            transDict.Add("ProductDescription", this.ProductDescription);
            transDict.Add("VehicleType", this.VehicleType);
            transDict.Add("RoutePath", this.RoutePath);
            transDict.Add("RouteMilleage", this.RouteMilleage);
            transDict.Add("CostCalculationMethod", this.CostCalculationMethod);
            transDict.Add("CostRate", this.CostRate);
            
            return transDict;
        }
        public string ConvertToServ()
        {
            return
                this.ProductDescription + Delimiter() +
                this.VehicleType + Delimiter() +
                this.RoutePath + Delimiter() +
                this.RouteMilleage + Delimiter() +
                this.CostCalculationMethod + Delimiter() +
                this.CostRate;
        }

        public decimal? RateCostCalculation(string condition = null, int? userDemand = null, decimal? Duration = null)
        {
            int? valueResult = null;
            if (CostCalculationMethod.Equals("FixPerRoute"))
            {
                valueResult = 1 * Int32.Parse(CostRate);
            }
            if (CostCalculationMethod.Equals("PerMiles"))
            {
                valueResult = Int32.Parse(RouteMilleage) * (Int32.Parse(CostRate) / 2);
            }
            if (CostCalculationMethod.Equals("PerMilesWithCondition"))
            {
                var nilai = 0;
                if (condition == "GoodWeather")
                {
                    nilai = 5;
                }
                else if (condition == "BadWeather")
                {
                    nilai = 15;
                }
                valueResult = (Int32.Parse(RouteMilleage) * Int32.Parse(CostRate) / 2) * (((nilai + (userDemand / 50)) + 95)) / 100;
            }
            return valueResult * (Convert.ToDecimal(110) / Convert.ToDecimal(100));
        }
    }
}