using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Northwind.Domain.ViewModels;
using Northwind.EntityFramworks;
using Northwind.Domain.Models.ProductDetails;
using Northwind.Domain.Models.ProductDetails.Items.Details;
using Northwind.Domain.Models.ProductDetails.Services.Details;

namespace Northwind.Domain.Models.ProductDetails
{
    public class ProductDetailByType
    {
        private char Delimeter;

        public ProductDetailByType()
        {
        }

        public ProductDetailByType(char Delimeter)
        {
            this.Delimeter = Delimeter;
        }
        public void CreateProductDetailByType(Product product, ProductDetailCalculatorParameter parameter)
        {
            ProductDetail productDetail = null;

            if (product.ProductType != null)
            {
                if (product.ProductType.Equals("FoodAndBeverageItems"))
                {
                    productDetail = new FoodAndBeverage(this.Delimeter, product);
                }
                else if (product.ProductType.Equals("MaterialItems"))
                {
                    productDetail = new Material(this.Delimeter, product);
                }
                else if (product.ProductType.Equals("GarmentItems"))
                {
                    productDetail = new Garment(this.Delimeter, product);
                }
                else if (product.ProductType.Equals("TransportationServices"))
                {
                    productDetail = new Transportation(this.Delimeter, product);
                }
                else if (product.ProductType.Equals("TelecommunicationServices"))
                {
                    productDetail = new Telecommunication(this.Delimeter, product);
                }
                else
                {
                    throw new Exception("Unknown Product Type");
                }

                productDetail.setAdditionalParameter(parameter);
                product.UnitPrice = productDetail.calculateProductCost() * productDetail.getDecCostRate();
            }
        }
    }
}