﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Northwind.GenerateModel
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class DbModels : DbContext
    {
        public DbModels()
            : base("name=DbModels")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<CustomerDemographic> CustomerDemographics { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Order_Detail> Order_Details { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Shipper> Shippers { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Territory> Territories { get; set; }
        public virtual DbSet<Alphabetical_list_of_product> Alphabetical_list_of_products { get; set; }
        public virtual DbSet<Category_Sales_for_1997> Category_Sales_for_1997 { get; set; }
        public virtual DbSet<Current_Product_List> Current_Product_Lists { get; set; }
        public virtual DbSet<Customer_and_Suppliers_by_City> Customer_and_Suppliers_by_Cities { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Order_Details_Extended> Order_Details_Extendeds { get; set; }
        public virtual DbSet<Order_Subtotal> Order_Subtotals { get; set; }
        public virtual DbSet<Orders_Qry> Orders_Qries { get; set; }
        public virtual DbSet<Product_Sales_for_1997> Product_Sales_for_1997 { get; set; }
        public virtual DbSet<Products_Above_Average_Price> Products_Above_Average_Prices { get; set; }
        public virtual DbSet<Products_by_Category> Products_by_Categories { get; set; }
        public virtual DbSet<Sales_by_Category> Sales_by_Categories { get; set; }
        public virtual DbSet<Sales_Totals_by_Amount> Sales_Totals_by_Amounts { get; set; }
        public virtual DbSet<Summary_of_Sales_by_Quarter> Summary_of_Sales_by_Quarters { get; set; }
        public virtual DbSet<Summary_of_Sales_by_Year> Summary_of_Sales_by_Years { get; set; }
    
        public virtual ObjectResult<CustOrderHist_Result> CustOrderHist(string customerID)
        {
            var customerIDParameter = customerID != null ?
                new ObjectParameter("CustomerID", customerID) :
                new ObjectParameter("CustomerID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CustOrderHist_Result>("CustOrderHist", customerIDParameter);
        }
    
        public virtual ObjectResult<CustOrdersDetail_Result> CustOrdersDetail(Nullable<int> orderID)
        {
            var orderIDParameter = orderID.HasValue ?
                new ObjectParameter("OrderID", orderID) :
                new ObjectParameter("OrderID", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CustOrdersDetail_Result>("CustOrdersDetail", orderIDParameter);
        }
    
        public virtual ObjectResult<CustOrdersOrders_Result> CustOrdersOrders(string customerID)
        {
            var customerIDParameter = customerID != null ?
                new ObjectParameter("CustomerID", customerID) :
                new ObjectParameter("CustomerID", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CustOrdersOrders_Result>("CustOrdersOrders", customerIDParameter);
        }
    
        public virtual ObjectResult<Employee_Sales_by_Country_Result> Employee_Sales_by_Country(Nullable<System.DateTime> beginning_Date, Nullable<System.DateTime> ending_Date)
        {
            var beginning_DateParameter = beginning_Date.HasValue ?
                new ObjectParameter("Beginning_Date", beginning_Date) :
                new ObjectParameter("Beginning_Date", typeof(System.DateTime));
    
            var ending_DateParameter = ending_Date.HasValue ?
                new ObjectParameter("Ending_Date", ending_Date) :
                new ObjectParameter("Ending_Date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Employee_Sales_by_Country_Result>("Employee_Sales_by_Country", beginning_DateParameter, ending_DateParameter);
        }
    
        public virtual ObjectResult<Sales_by_Year_Result> Sales_by_Year(Nullable<System.DateTime> beginning_Date, Nullable<System.DateTime> ending_Date)
        {
            var beginning_DateParameter = beginning_Date.HasValue ?
                new ObjectParameter("Beginning_Date", beginning_Date) :
                new ObjectParameter("Beginning_Date", typeof(System.DateTime));
    
            var ending_DateParameter = ending_Date.HasValue ?
                new ObjectParameter("Ending_Date", ending_Date) :
                new ObjectParameter("Ending_Date", typeof(System.DateTime));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Sales_by_Year_Result>("Sales_by_Year", beginning_DateParameter, ending_DateParameter);
        }
    
        public virtual ObjectResult<SalesByCategory_Result> SalesByCategory(string categoryName, string ordYear)
        {
            var categoryNameParameter = categoryName != null ?
                new ObjectParameter("CategoryName", categoryName) :
                new ObjectParameter("CategoryName", typeof(string));
    
            var ordYearParameter = ordYear != null ?
                new ObjectParameter("OrdYear", ordYear) :
                new ObjectParameter("OrdYear", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<SalesByCategory_Result>("SalesByCategory", categoryNameParameter, ordYearParameter);
        }
    
        public virtual ObjectResult<Ten_Most_Expensive_Products_Result> Ten_Most_Expensive_Products()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Ten_Most_Expensive_Products_Result>("Ten_Most_Expensive_Products");
        }
    }
}
