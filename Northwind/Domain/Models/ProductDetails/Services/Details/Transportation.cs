using System;
using System.Collections.Generic;
using Northwind.EntityFramworks;

namespace Northwind.Domain.Models.ProductDetails.Services.Details
{
    public class Transportation : Service
    {
        public string VehicleType { get; set; }
        public string RoutePath { get; set; }
        public string RouteMilleage { get; set; }
        private object[] param { get; set; }

        public Transportation(char Delimeter, Product product) : base(Delimeter)
        {
            this.ProductID = product.ProductID;
            if (!string.IsNullOrEmpty(product.ProductDetail))
            {
                string[] prod = product.ProductDetail.Split(this.Delimeter);
                this.ProductDescription = prod[0];
                this.UnitProfit = prod[1];
                this.VehicleType = prod[2];
                this.RoutePath = prod[3];
                this.RouteMilleage = prod[4];
                this.CostCalculationMethod = prod[5];
                this.CostRate = prod[6];
            }
        }

        public override Dictionary<string, object> ConvertToDictionary()
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            result.Add("ProductID", this.ProductID);
            result.Add("ProductDescription", this.ProductDescription);
            result.Add("UnitProfit", this.UnitProfit);
            result.Add("VehicleType", this.VehicleType);
            result.Add("RoutePath", this.RoutePath);
            result.Add("RouteMilleage", this.RouteMilleage);
            result.Add("CostCalculationMethod", this.CostCalculationMethod);
            result.Add("CostRate", this.CostRate);

            return result;
        }

        public override string ConvertToString()
        {
            return this.appendWithDelimiter(this.ProductDescription, this.UnitProfit, this.VehicleType, this.RoutePath, this.RouteMilleage, this.CostCalculationMethod, this.CostRate);
        }

        public override decimal calculateProductCost()
        {
            decimal DecCostRate = decimal.Parse(this.CostRate);
            decimal DecRouteMilleage = decimal.Parse(this.RouteMilleage);

            if (this.CostCalculationMethod.Equals("FixPerRoute"))
            {
                return DecCostRate;
            }
            else if (this.CostCalculationMethod.Equals("PerMiles"))
            {
                return (DecRouteMilleage * DecCostRate) / 2;
            }
            else if (this.CostCalculationMethod.Equals("PerMilesWithCondition"))
            {
                var conditon = 0;

                if (this.parameter.Wheater != null)
                {
                    if (this.parameter.Wheater.Equals("GoodWheater"))
                    {
                        conditon = 5;
                    }
                    else
                    {
                        conditon = 15;
                    }
                }
                return ((DecRouteMilleage * DecCostRate) / 2) * ((conditon + (this.parameter.getNonNullUserDemand() / 50)) + 95) / 100;
            } else
            {
                return 0;
            }
        }
    }
}