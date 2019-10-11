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
        public int ProductID { get; set; }
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
            this.ProductID = product.ProductID;
            if (!string.IsNullOrEmpty(product.ProductDetail))
            {
                string[] prod = product.ProductDetail.Split(delimiter);
                this.ProductDescription = prod[0];
                this.VehicleType = prod[1];
                this.RoutePath = prod[2];
                this.RouteMilleage = prod[3];
                this.CostCalculationMethod = prod[4];
                this.CostRate = prod[5];
            }
        }

        public Dictionary<string, object> fromTransToDict()
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
                this.ProductDescription + "|" +
                this.VehicleType + "|" +
                this.RoutePath + "|" +
                this.RouteMilleage + "|" +
                this.CostCalculationMethod + "|" +
                this.CostRate;
        }
    }
}