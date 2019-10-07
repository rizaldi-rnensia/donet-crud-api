using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Northwind.EntityFramworks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using Northwind.ViewModels;

namespace Northwind.ViewModels
{
    public class OrderSupViewModel1
    {
        public int? SupplierID { get; set; }

        [Required]
        [StringLength(40)]
        public string CompanyName { get; set; }

        [StringLength(30)]
        public string ContactName { get; set; }

        public long? TotalUnitOnOrder { get; set; }

        public List<OrderSupViewModel> ProductList { get; set; }

        public OrderSupViewModel1()
        {

        }

        public OrderSupViewModel1(int? supplierID, string companyName, string contactName, List<OrderSupViewModel> prodDet)
        {
            SupplierID = supplierID;
            CompanyName = companyName;
            ContactName = contactName;
            TotalUnitOnOrder = prodDet.Sum(data => data.UnitsOnOrder);
            ProductList = prodDet;
        }
        

    }

}