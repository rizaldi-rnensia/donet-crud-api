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
    public class OrderCustome1ViewModel
    {
        public int? OrderID { get; set; }
        [StringLength(30)]
        public string ContactName { get; set; }

        public List <OrderCustomViewModel> ProductList { get; set; }

        public decimal GrandTotal { get; set; }

        public OrderCustome1ViewModel()
        {

        }
        public OrderCustome1ViewModel(List<OrderCustomViewModel> orderDet
            ,int? orderId
            ,string contactName
            )
        {
            OrderID = orderId;
            ContactName = contactName;
            ProductList = orderDet;
            GrandTotal = orderDet.Sum(data => data.Total);
        }
        
    }
}