using System;
using System.Collections.Generic;
using Northwind.EntityFramworks;

namespace Northwind.Domain.Models.ProductDetails.Services.Details
{
    public class Telecommunication : Service
    {
        public string PacketType { get; set; }
        public string PacketLimit { get; set; }

        public Telecommunication(char Delimeter, Product product) : base(Delimeter)
        {
            this.ProductID = product.ProductID;
            if (!string.IsNullOrEmpty(product.ProductDetail))
            {
                string[] prod = product.ProductDetail.Split(this.Delimeter);
                this.ProductDescription = prod[0];
                this.UnitProfit = prod[1];
                this.PacketType = prod[2];
                this.PacketLimit = prod[3];
                this.CostCalculationMethod = prod[4];
                this.CostRate = prod[5];
            }
        }

        public override Dictionary<string, object> ConvertToDictionary()
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            result.Add("ProductID", this.ProductID);
            result.Add("ProductDescription", this.ProductDescription);
            result.Add("UnitProfit", this.UnitProfit);
            result.Add("PacketType", this.PacketType);
            result.Add("PacketLimit", this.PacketLimit);
            result.Add("CostCalculationMehod", this.CostCalculationMethod);
            result.Add("CostRate", this.CostRate);

            return result;
        }

        public override string ConvertToString()
        {
            return this.appendWithDelimiter(this.ProductDescription, this.UnitProfit, this.PacketType, this.PacketLimit, this.CostCalculationMethod, this.CostRate);
        }

        public override decimal calculateProductCost()
        {
            decimal DecCostRate = decimal.Parse(CostRate);
            var temp = this.parameter;

            if (CostCalculationMethod.Equals("PerSecond"))
            {
                return DecCostRate * this.parameter.getNonNullDuration();
            }
            else if (CostCalculationMethod.Equals("PerPacket"))
            {
                if (PacketType.Equals("Data"))
                {
                    return decimal.Parse(PacketLimit) * DecCostRate;
                }
                else
                {
                    return DecCostRate * this.parameter.getNonNullDuration();
                }
            }
            else
            {
                return 0;
            }
        }
    }
}