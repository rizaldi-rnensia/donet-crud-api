using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Northwind.EntityFramworks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;

namespace Northwind.ViewModels
{
    public class OrderCustomViewModel
    {
        

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string SupplierName { get; set; }

        [Column(TypeName = "money")]
        public decimal? UnitPrice { get; set; }
        public int Quantity { get; set; }
        public decimal Total { get; set; }


        
        public OrderCustomViewModel()
        {

        }

        public OrderCustomViewModel(Order_Detail ordDetEntity)
        {
            ProductID = ordDetEntity.Product.ProductID;
            ProductName = ordDetEntity.Product.ProductName;
            CategoryName = ordDetEntity.Product.Category.CategoryName;
            SupplierName = ordDetEntity.Product.Supplier.CompanyName;
            UnitPrice = ordDetEntity.UnitPrice;
            Quantity = ordDetEntity.Quantity;
            Total = ordDetEntity.Quantity * ordDetEntity.UnitPrice;
        }


    }
}