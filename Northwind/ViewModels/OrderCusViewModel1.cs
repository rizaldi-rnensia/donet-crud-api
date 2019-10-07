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
    public class OrderCusViewModel1
    {
        public int? ProductID { get; set; }
        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }
        [Required]
        [StringLength(15)]
        public string CategoryName { get; set; }
        [Required]
        [StringLength(40)]
        public string SupplierName { get; set; }

        [Column(TypeName = "money")]
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public decimal? Total { get; set; }

      

        public OrderCusViewModel1()
        {

        }

        public OrderCusViewModel1(Order_Detail ordDetEntity)
        {
            ProductID = ordDetEntity.Product.ProductID;
            ProductName = ordDetEntity.Product.ProductName;
            CategoryName = ordDetEntity.Product.Category.CategoryName;
            SupplierName = ordDetEntity.Product.Supplier.CompanyName;
            UnitPrice = ordDetEntity.UnitPrice;
            Quantity = ordDetEntity.Quantity;
            Total = (UnitPrice * Quantity) - ((UnitPrice * Quantity)*(decimal)ordDetEntity.Discount);
        }
    }
}