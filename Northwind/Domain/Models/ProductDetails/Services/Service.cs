using Northwind.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind.Domain.Models.ProductDetails.Services
{
    public abstract class Service : ProductDetail
    {
        public ProductDetailCalculatorParameter parameter { get; set; }

        public Service(char Delimeter) : base(Delimeter)
        {
            this.Delimeter = ';';
        }

        public string CostCalculationMethod { get; set; }

        public override void setAdditionalParameter(ProductDetailCalculatorParameter parameter)
        {
            this.parameter = parameter;
        }
    }
}