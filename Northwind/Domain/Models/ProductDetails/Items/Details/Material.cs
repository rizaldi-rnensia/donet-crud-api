using System.Collections.Generic;
using Northwind.EntityFramworks;

namespace Northwind.Domain.Models.ProductDetails.Items.Details
{
    public class Material : Item
    {
        public string ExpiredDate { get; set; }
        public string MaterialsType { get; set; }
        public string IsConsumable { get; set; }

        public Material(char Delimeter, Product product) : base(Delimeter)
        {
            this.ProductID = product.ProductID;
            if (!string.IsNullOrEmpty(product.ProductDetail))
            {
                string[] prod = product.ProductDetail.Split(this.Delimeter);
                this.ProductDescription = prod[0];
                this.UnitProfit = prod[1];
                this.ProductionCode = prod[2];
                this.ProductionDate = prod[3];
                this.ExpiredDate = prod[4];
                this.MaterialsType = prod[5];
                this.IsConsumable = prod[6];
                this.UnitOfMeasurement = prod[7];
                this.CostRate = prod[8];
            }
        }
        public override Dictionary<string, object> ConvertToDictionary()
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            result.Add("ProductID", this.ProductID);
            result.Add("ProductDescription", this.ProductDescription);
            result.Add("UnitProfit", this.UnitProfit);
            result.Add("ProductionCode", this.ProductionCode);
            result.Add("ProductionDate", this.ProductionDate);
            result.Add("ExpiredDate", this.ExpiredDate);
            result.Add("MaterialsType", this.MaterialsType);
            result.Add("IsConsumable", this.IsConsumable);
            result.Add("UnitOfMeasurement", this.UnitOfMeasurement);
            result.Add("CostRate", this.CostRate);

            return result;
        }

        public override string ConvertToString()
        {
            return this.appendWithDelimiter(
                 this.ProductDescription, this.UnitProfit, this.ProductionCode, this.ProductionDate, this.ExpiredDate, this.MaterialsType,
                 this.IsConsumable, this.UnitOfMeasurement, this.CostRate);
        }
    }
}