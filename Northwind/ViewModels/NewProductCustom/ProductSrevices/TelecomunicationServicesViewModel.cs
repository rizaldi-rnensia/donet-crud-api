using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Northwind.ViewModels.NewProductCustom.Interface;
using Northwind.EntityFramworks;

namespace Northwind.ViewModels.NewProductCustom.ProductSrevices
{
    public class TelecomunicationServicesViewModel : ProductDetailViewModel, IProductServices
    {
        public string PacketType { get; set; }
        public string PacketLimit { get; set; }
        public string CostCalculationMethod { get; set; }
        public string CostRate { get; set; }
        public TelecomunicationServicesViewModel()
        {

        }

        public TelecomunicationServicesViewModel(Product product, char? dlmtr)
        {
            this.ProductID = product.ProductID;
            if (!string.IsNullOrEmpty(product.ProductDetail))
            {
                string[] prod = product.ProductDetail.Split(Delimiter(dlmtr));
                this.ProductDescription = prod[0];
                this.UnitProvit = prod[1];
                this.PacketType = prod[2];
                this.PacketLimit = prod[3];
                this.CostCalculationMethod = prod[4];
                this.CostRate = prod[5];
            }
        }
        public string ConvertToServ(char? dlmtr)
        {
            return
                this.ProductDescription + Delimiter(dlmtr) +
                this.UnitProvit + Delimiter(dlmtr) +
                this.PacketType + Delimiter(dlmtr) +
                this.PacketLimit + Delimiter(dlmtr) +
                this.CostCalculationMethod + Delimiter(dlmtr) +
                this.CostRate;
        }

        public decimal? RateCostCalculation(string condition, int? userDemand, decimal? Duration)
        {
            decimal? valueResult = null;
            decimal decCostRate = decimal.Parse(CostRate);

            if (CostCalculationMethod.Equals("PerSecond"))
            {
                valueResult = decCostRate * Duration;
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
            else
            {
                valueResult = 0;
            }

            return valueResult * (Convert.ToDecimal(110) / Convert.ToDecimal(100));
        }

        public Dictionary<string, object> FromServToDict()
        {
            Dictionary<string, object> teleDict = new Dictionary<string, object>();
            teleDict.Add("ProductID", this.ProductID);
            teleDict.Add("ProductDescription", this.ProductDescription);
            teleDict.Add("UnitProvit", this.UnitProvit);
            teleDict.Add("PacketType", this.PacketType);
            teleDict.Add("PacketLimit", this.PacketLimit);
            teleDict.Add("CostCalculationMehod", this.CostCalculationMethod);
            teleDict.Add("CostRate", this.CostRate);
            return teleDict;
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
    }
}