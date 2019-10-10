using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using Northwind.EntityFramworks;
using AutoMapper;

namespace Northwind.ViewModels.ProductCustom
{
    public class ProductDetailViewModel : ProductCustomViewModel
    {
        public string ProductDescription { get; set; }
        public ProductDetailViewModel()
        {
            
        }

        public ProductCustomViewModel ProductCustom(ProductCustomViewModel productCustom)
        {
            ProductCustomViewModel productCustomView = new ProductCustomViewModel();
            this.ProductID = productCustom.ProductID;
            ProductDescription = this.ProductDescription;
            if (productCustomView.ProductType.ToLower().Contains("FoodAndBeverageItems"))
            {
                var temp = this.ProductDetail;
                FoodBevItemViewModel obj = new FoodBevItemViewModel();
                

            }
            return productCustomView;
        }

    }
}