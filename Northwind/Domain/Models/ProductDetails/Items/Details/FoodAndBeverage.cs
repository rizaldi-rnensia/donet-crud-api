using System.Collections.Generic;
using Northwind.EntityFramworks;

namespace Northwind.Domain.Models.ProductDetails.Items.Details
{
    public class FoodAndBeverage : Item
    {
        public string ExpiredDate { get; set; }
        public string NetWeight { get; set; }
        public string Ingredients { get; set; }
        public string DailyValue { get; set; }
        public string Certification { get; set; }

        public FoodAndBeverage(char Delimeter, Product product) : base(Delimeter)
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
                this.NetWeight = prod[5];
                this.Ingredients = prod[6];
                this.DailyValue = prod[7];
                this.Certification = prod[8];
                this.UnitOfMeasurement = prod[9];
                this.CostRate = prod[10];
            }
        }

        public FoodAndBeverage(char Delimeter, Dictionary<string, object> dictionary) : base(Delimeter)
        {
            this.ProductDescription = dictionary["ProductDescription"].ToString();
            this.UnitProfit = dictionary["UnitProfit"].ToString();
            this.ProductionCode = dictionary["ProductionCode"].ToString();
            this.ProductionDate = dictionary["ProductionDate"].ToString();
            this.ExpiredDate = dictionary["ExpiredDate"].ToString();
            this.Ingredients = dictionary["Ingredients"].ToString();
            this.NetWeight = dictionary["NetWeight"].ToString();
            this.DailyValue = dictionary["DailyValue"].ToString();
            this.Certification = dictionary["Certification"].ToString();
            this.UnitOfMeasurement = dictionary["UnitOfMeasurement"].ToString();
            this.CostRate = dictionary["CostRate"].ToString();
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
            result.Add("NetWeight", this.NetWeight);
            result.Add("Ingredients", this.Ingredients);
            result.Add("DailyValue", this.DailyValue);
            result.Add("Certification", this.Certification);
            result.Add("UnitOfMeasurement", this.UnitOfMeasurement);
            result.Add("CostRate", this.CostRate);

            return result;
        }

        public override string ConvertToString()
        {
            return this.appendWithDelimiter(
                this.ProductDescription, this.UnitProfit, this.ProductionCode, this.ProductionDate, this.ExpiredDate, this.NetWeight,
                this.Ingredients, this.DailyValue, this.Certification, this.UnitOfMeasurement, this.CostRate);
        }

    }
}