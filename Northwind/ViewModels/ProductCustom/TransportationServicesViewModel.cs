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
    public class TransportationServicesViewModel
    {
        public string ProductID { get; set; }
        public string ProductDescription { get; set; }
        public string VehicleType { get; set; }
        public string RoutePath { get; set; }
        public string RouteMilleage { get; set; }
        public string CostCalculationMethod { get; set; }
        public string CostRate { get; set; }

        public TransportationServicesViewModel()
        {

        }

        public TransportationServicesViewModel(Product product)
        {
            char[] delimiter = { '|' };
            string[] prod = product.ProductDetail.Split(delimiter);
            this.ProductID = product.ProductID.ToString();
            if (prod.Length == 7)
            {
                this.ProductID = prod[0];
                this.ProductDescription = prod[1];
                this.VehicleType = prod[2];
                this.RoutePath = prod[3];
                this.RouteMilleage = prod[4];
                this.CostCalculationMethod = prod[5];
                this.CostRate = prod[6];
            }
        }

        public Dictionary<string, object> fromFoodToTrans()
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
        public string ConvertToTrans()
        {
            return
                this.ProductID + "|" +
                this.ProductDescription + "|" +
                this.VehicleType + "|" +
                this.RoutePath + "|" +
                this.RouteMilleage + "|" +
                this.CostCalculationMethod + "|" +
                this.CostRate;
        }
    }
}