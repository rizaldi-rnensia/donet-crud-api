using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Northwind.Domain.ViewModels;

namespace Northwind.Domain.Models.ProductDetails
{
    public abstract class ProductDetail : IProductDetail, IProductDetailCalculator
    {
        public readonly decimal RateCalculation = (decimal)(110.00 / 100.00);
        public int ProductID { get; set; }
        public string ProductDescription { get; set; }
        public string UnitProfit { get; set; }
        public string CostRate { get; set; }
        public char Delimeter { get; set; }

        public ProductDetail(char Delimeter) {
            this.Delimeter = Delimeter;
        }

        public decimal getDecCostRate() {
            return this.RateCalculation;
        }

        public string appendWithDelimiter(params object[] listParam) {
            string result = "";
            char delimiter = (char) 0;

            foreach (object param in listParam)
            {
                result += delimiter + param.ToString();
                delimiter = this.Delimeter;
            }

            return result;
        }

        public abstract string ConvertToString();
        public abstract Dictionary<string, object> ConvertToDictionary();
        public abstract void setAdditionalParameter(ProductDetailCalculatorParameter parameter);
        public abstract decimal calculateProductCost();
    }
}