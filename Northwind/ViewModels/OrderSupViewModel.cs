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
    public class OrderSupViewModel
    {
        // =============
        // TABLE REF : PRODUCT
        // =============
        public int? ProductID { get; set; }

        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }

        [Required]
        [StringLength(15)]
        public string CategoryName { get; set; }

        [StringLength(20)]
        public string QuantityPerUnit { get; set; }

        [Column(TypeName = "money")]
        public decimal? UnitPrice { get; set; }

        public short? UnitsInStock { get; set; }

        public short? UnitsOnOrder { get; set; }// WILL BE CALCULATED FOR GETTING TOTAL UNIT ON ORDER


        public OrderSupViewModel()
        {

        }

        public OrderSupViewModel(Order_Detail ordDetEntity)
        {
            ProductID = ordDetEntity.Product.ProductID;
            ProductName = ordDetEntity.Product.ProductName;
            CategoryName = ordDetEntity.Product.Category.CategoryName;
            QuantityPerUnit = ordDetEntity.Product.QuantityPerUnit;
            UnitPrice = ordDetEntity.Product.UnitPrice;
            UnitsInStock = ordDetEntity.Product.UnitsInStock;
            UnitsOnOrder = ordDetEntity.Product.UnitsOnOrder;
        }
    }
}