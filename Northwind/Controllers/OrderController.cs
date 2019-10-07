using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using Northwind.EntityFramworks;
using Northwind.GenerateModel;
using Northwind.ViewModels;
using Order_Detail = Northwind.EntityFramworks.Order_Detail;

namespace Northwind.Controllers
{
    [RoutePrefix("api/Order")]
    public class OrderController : ApiController
    {
        // API FOR GETTING DATA ORDER BY DATE AND GROUPED BY SUPPLIER
        [Route("OrderPerSupplier")]
        [HttpGet]
        public IHttpActionResult OrderPerSupplier(DateTime? orderDate = null)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            List<OrderSupViewModel2> listOrdDate = new List<OrderSupViewModel2>();
            using(var db = new DB_Context())
            {
                var dataOrders = db.Orders.AsQueryable();
                if(orderDate != null)
                {
                    dataOrders = dataOrders.Where(item => item.OrderDate == orderDate);
                }
                var listOrderDate = dataOrders.ToList()
                    .Select(dt => new OrderViewModel(dt)).AsQueryable();

                //foreach (var item in listOrderDate)
                //{
                //    var listSupplierDetail = item.Supplierlist.ToList();

                //}

                result.Add("data", listOrderDate);
            }
            return Ok(result);
        }


        // API FOR GETTING DATA ORDER PER CUSTOMER
        [Route("ReadBy2")]
        [HttpGet]
        public IHttpActionResult ReadBy2(int? orderId = null)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            List<OrderCusViewModel> listDetailOrder = new List<OrderCusViewModel>();

            using (var db = new DB_Context())
            {
                var dataOrders = db.Orders.AsQueryable();
                if (orderId != null)
                {
                    dataOrders = dataOrders.Where(item => item.OrderID == orderId);   
                }
                var listOrder = dataOrders.AsEnumerable().ToList();
                foreach( var item in listOrder)
                {
                    var listProductDetail = item.Order_Details.ToList()
                        .Select(dt => new OrderCusViewModel1(dt)).ToList();
                    OrderCusViewModel orderDetail = new OrderCusViewModel(item.OrderID, item.Customer.ContactName, listProductDetail);
                    listDetailOrder.Add(orderDetail);
                }
                result.Add("Message", "Read Data Success");
                result.Add("Data", listDetailOrder);
            }
            return Ok(result);
        }

        [Route("Readaja")]
        [HttpGet]
        public IHttpActionResult GetOrder()
        {
            using (DbModels db = new DbModels())
            {
                var data = db.Territories.ToList();
                return Ok(123);
            }
        }

        [Route("ReadBy")]
        [HttpGet]
        public IHttpActionResult ReadBy(int? orderId=null)
        {
            try
            {
                using (var db = new DB_Context())
                {
                    List<OrderCustome1ViewModel> listAllData = new List<OrderCustome1ViewModel>();        
                    var temp = db.Orders.AsQueryable();
                    if (orderId != null)
                    {
                        return Ok(readAja(orderId));    
                    } else { 
                        foreach (var data1 in temp)
                        {
                            orderId = data1.OrderID;
                            listAllData.Add(readAja(orderId));
                        }
                        return Ok(listAllData);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public OrderCustome1ViewModel readAja(int? orderId)
        {
            using (var db = new DB_Context()) { 
                List<OrderCustomViewModel> listProduct = new List<OrderCustomViewModel>();
                OrderCustome1ViewModel listData = new OrderCustome1ViewModel();
                List<Order_Detail> orderDetTemp = new List<Order_Detail>();
                var temp = db.Orders.AsQueryable();
                var contactName = "";
                orderDetTemp = temp.Where(data => data.OrderID == orderId)
                                        .AsEnumerable().FirstOrDefault().Order_Details
                                        .Where(item => item.OrderID == orderId)
                                        .ToList();
                var orders = temp.Where(data => data.OrderID == orderId).FirstOrDefault();
                contactName = orders.Customer.ContactName;
                listProduct = new List<OrderCustomViewModel>();
                foreach (var data in orderDetTemp)
                {
                    OrderCustomViewModel listOrder = new OrderCustomViewModel(data);
                    listProduct.Add(listOrder);
                };
                return listData = new OrderCustome1ViewModel(listProduct, orderId, contactName);
            }
        }

    }
}