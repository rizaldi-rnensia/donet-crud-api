using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using Northwind.EntityFramworks;


namespace Northwind.ViewModels
{
    public class OrderViewModel1
    {
        public int? SupplierID { get; set; }

        [Required]
        [StringLength(40)]
        public string CompanyName { get; set; }

        [StringLength(30)]
        public string ContactName { get; set; }

        public long? TotalUnitOnOrder { get; set; }


        //public List<OrderSupViewModel> ProductList { get; set; }

        public OrderViewModel1()
        {

        }

        public OrderViewModel1(Supplier supEntity)
        {
            SupplierID = supEntity.SupplierID;
            CompanyName = supEntity.CompanyName;
            ContactName = supEntity.ContactName;
            TotalUnitOnOrder = 132;
        }
    }
}