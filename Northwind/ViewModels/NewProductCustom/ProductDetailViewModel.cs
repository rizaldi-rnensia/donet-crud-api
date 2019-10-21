using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Northwind.ViewModels.NewProductCustom;

namespace Northwind.ViewModels.NewProductCustom
{
    public class ProductDetailViewModel : NewProductViewModel
    {
        public string ProductDescription { get; set; }
        public string UnitProvit { get; set; }

        public ProductDetailViewModel()
        {

        }
    }
}