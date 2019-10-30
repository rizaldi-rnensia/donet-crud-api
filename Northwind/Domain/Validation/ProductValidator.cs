using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Northwind.Domain.Models.ProductDetails;
using Northwind.Domain.Calculation;
using Northwind.EntityFramworks;
using Northwind.Domain.ViewModels;

namespace Northwind.Domain.Validation
{
    public class ProductValidator
    {
        Product product = new Product();
        public bool isValidProductDetail(ProductDetail productDetail, string productType)
        {
            if (productDetail.Delimeter == '|' && productType == product.ProductType)
            {
                return true;
            }
            else if (productDetail.Delimeter == ';' && productType == product.ProductType)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isValidProductDetail(Dictionary<string, object>productDetail, string productType)
        {
            if (productDetail.ToString().Contains('|') && productType == product.ProductType)
            {
                return true;
            }
            else if(productDetail.ToString().Contains(';') && productType == product.ProductType)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool isValidProductDetail(string productDetail, string productType)
        {
            return false;
        }
    }
}