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
    public class OrderCusViewModel
    {
        public int? OrderID { get; set; }
        [StringLength(30)]
        public string ContactName { get; set; }

        public List<OrderCusViewModel1> ProductList { get; set; }

        public decimal? GrandTotal { get; set; }

        public OrderCusViewModel()
        {

        }
        public OrderCusViewModel(int? orderId, string contactName, List<OrderCusViewModel1> orderDet)
        {
            OrderID = orderId;
            ContactName = contactName;
            ProductList = orderDet;
            GrandTotal = orderDet.Sum(data => data.Total);
        }
    }
}