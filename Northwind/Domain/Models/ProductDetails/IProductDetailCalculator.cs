using Northwind.Domain.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.Domain.Models.ProductDetails
{
    interface IProductDetailCalculator
    {
        void setAdditionalParameter(ProductDetailCalculatorParameter parameter);
        decimal calculateProductCost();
    }
}
