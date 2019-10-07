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
    public class OrderSupViewModel2
    {
        public DateTime? OrderDate { get; set; }

        public List<OrderSupViewModel1> SupplierList { get; set; }

        public OrderSupViewModel2()
        {

        }

        public OrderSupViewModel2(DateTime? orderDate, List<OrderSupViewModel1> suppList)
        {
            OrderDate = orderDate;
            SupplierList = suppList;
        }
    }
}