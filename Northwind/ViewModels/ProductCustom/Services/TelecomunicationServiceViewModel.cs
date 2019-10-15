using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using Northwind.EntityFramworks;
using Northwind.ViewModels.ProductCustom.Services;

namespace Northwind.ViewModels.ProductCustom.Services
{
    public class TelecomunicationServiceViewModel : IProductService
    {
        public int ProductID { get; set; }
        public string ProductDescription { get; set; }
        public string PacketType { get; set; }
        public string PacketLimit { get; set; }
        public string CostCalculationMethod { get; set; }
        public string CostRate { get; set; }

        public TelecomunicationServiceViewModel()
        {

        }

        public TelecomunicationServiceViewModel(Product product)
        {
            char[] delimiter = { ';' };
            this.ProductID = product.ProductID;
            if (!string.IsNullOrEmpty(product.ProductDetail))
            {
                string[] prod = product.ProductDetail.Split(delimiter);
                this.ProductDescription = prod[0];
                this.PacketType = prod[1];
                this.PacketLimit = prod[2];
                this.CostCalculationMethod = prod[3];
                this.CostRate = prod[4];
            }
        }

        public Dictionary<string, object> fromServToDict()
        {
            Dictionary<string, object> teleDict = new Dictionary<string, object>();
            teleDict.Add("ProductID", this.ProductID);
            teleDict.Add("ProductDescription", this.ProductDescription);
            teleDict.Add("PacketType", this.PacketType);
            teleDict.Add("PacketLimit", this.PacketLimit);
            teleDict.Add("CostCalculationMehod", this.CostCalculationMethod);
            teleDict.Add("CostRate", this.CostRate);
            return teleDict;
        }

        public string ConvertToServ()
        {
            return
                this.ProductDescription + ";" +
                this.PacketType + ";" +
                this.PacketLimit + ";" +
                this.CostCalculationMethod + ";" +
                this.CostRate;       
        }

        public decimal? rateCostCalculation(string condition = null, int? userDemand = null, decimal? Duration = null)
        {
            decimal? valueResult=null;
            decimal decCostRate = decimal.Parse(CostRate);

            if (CostCalculationMethod.Equals("PerSecond"))
            {
                valueResult = decCostRate* Duration;
            }
            else if (CostCalculationMethod.Equals("PerPacket"))
            {
                if (PacketType.Equals("Data"))
                {
                    valueResult = decimal.Parse(PacketLimit) * decCostRate;
                }
                else
                {
                    valueResult = (decCostRate * Duration) * decCostRate;
                }
            }
            else {
                valueResult = 0;
            }

            return valueResult*(Convert.ToDecimal(110)/Convert.ToDecimal(100));
        }
    }
}