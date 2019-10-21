using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Northwind.ViewModels.NewProductCustom.Interface;
using Northwind.EntityFramworks;

namespace Northwind.ViewModels.NewProductCustom.ProductSrevices
{
    public class TransportationServicesViewModel : ProductDetailViewModel, IProductServices
    {
        public string VehicleType { get; set; }
        public string RoutePath { get; set; }
        public string RouteMilleage { get; set; }
        public string CostCalculationMethod { get; set; }
        public string CostRate { get; set; }
        public TransportationServicesViewModel()
        {

        }
        public TransportationServicesViewModel(Product product, char? dmtr)
        {
            this.ProductID = product.ProductID;
            if (!string.IsNullOrEmpty(product.ProductDetail))
            {
                string[] prod = product.ProductDetail.Split(Delimiter(dmtr));
                this.ProductDescription = prod[0];
                this.UnitProvit = prod[1];
                this.VehicleType = prod[2];
                this.RoutePath = prod[3];
                this.RouteMilleage = prod[4];
                this.CostCalculationMethod = prod[5];
                this.CostRate = prod[6];
            }
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

        public string ConvertToServ(char? dlmtr)
        {
            return
                this.ProductDescription + Delimiter(dlmtr) +
                this.UnitProvit + Delimiter(dlmtr) +
                this.VehicleType + Delimiter(dlmtr) +
                this.RoutePath + Delimiter(dlmtr) +
                this.RouteMilleage + Delimiter(dlmtr) +
                this.CostCalculationMethod + Delimiter(dlmtr) +
                this.CostRate;
        }

        public decimal? RateCostCalculation(string condition, int? userDemand, decimal? Duration)
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

        public Dictionary<string, object> FromServToDict()
        {
            Dictionary<string, object> transDict = new Dictionary<string, object>();
            transDict.Add("ProductID", this.ProductID);
            transDict.Add("ProductDescription", this.ProductDescription);
            transDict.Add("UnitProvit", this.UnitProvit);
            transDict.Add("VehicleType", this.VehicleType);
            transDict.Add("RoutePath", this.RoutePath);
            transDict.Add("RouteMilleage", this.RouteMilleage);
            transDict.Add("CostCalculationMethod", this.CostCalculationMethod);
            transDict.Add("CostRate", this.CostRate);

            return transDict;
        }
    }
}