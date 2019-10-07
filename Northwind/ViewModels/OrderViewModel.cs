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
    public class OrderViewModel
    {
        public DateTime? OrderDate { get; set; }

        public List<OrderViewModel1> Supplierlist { get; set; }

        public int OrderQuantity { get; set; }


        public OrderViewModel()
        {

        }

        public OrderViewModel(
            Order entity
            //List<OrderViewModel1> suppDet
            )
        {
            OrderDate = entity.OrderDate;
            //Supplierlist = suppDet;
            OrderQuantity = 1234;
        }
    }
}