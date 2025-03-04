﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using Northwind.EntityFramworks;
using AutoMapper;
using Northwind.ViewModels.ProductCustom.Items;
using Northwind.ViewModels.ProductCustom.Services;
using Northwind.Domain.Validation;

namespace Northwind.ViewModels.ProductCustom
{
    public class ProductCustomViewModel : ProductViewModel
    {
        public ProductCustomViewModel()
        {
        }
        public ProductCustomViewModel(Product product)
        {
            ProductID = product.ProductID;
            ProductName = product.ProductName;
            SupplierID = product.SupplierID;
            CategoryID = product.CategoryID;
            QuantityPerUnit = product.QuantityPerUnit;
            UnitPrice = product.UnitPrice;
            UnitsInStock = product.UnitsInStock;
            UnitsOnOrder = product.UnitsOnOrder;
            ReorderLevel = product.ReorderLevel;
            Discontinued = product.Discontinued;
            ProductType = product.ProductType; 
            if(ProductType != null)
            {
                switch (ProductType)
                {
                    case "FoodAndBeverageItems":
                        FoodBevItemViewModel food = new FoodBevItemViewModel(product);
                        ProductDetail = food.fromItemToDict();
                        break;
                    case "GarmentItems":
                        GarmentViewModel garment = new GarmentViewModel(product);
                        ProductDetail = garment.fromItemToDict();
                        break;
                    case "MaterialItems":
                        MaterialViewModel materi = new MaterialViewModel(product);
                        ProductDetail = materi.fromItemToDict();
                        break;
                    case "TransportationServices":
                        TransportationServicesViewModel trans = new TransportationServicesViewModel(product);
                        ProductDetail = trans.fromServToDict();
                        break;
                    case "TelecommunicationServices":
                        TelecomunicationServiceViewModel telecomunication = new TelecomunicationServiceViewModel(product);
                        ProductDetail = telecomunication.fromServToDict();
                        break;
                    default:
                        ProductDetail = null;
                        break;
                }
            }
            else
            {
                ProductDetail = null;
            }
        }
        public Product ConvertToProduct(string condition = null, int? userDemand = null, decimal? Duration = null)
        {
            decimal? price=null;
            var prodDet = "";
            ProductValidator validator = new ProductValidator();
            var config = new MapperConfiguration(cfg => { });
            var mapper = new Mapper(config);
            if (this.ProductType.Equals("FoodAndBeverageItems"))
            {
                FoodBevItemViewModel food = mapper.Map<FoodBevItemViewModel>(this.ProductDetail);
                prodDet = food.ConvertToItem();
                price = food.unitPriceItemCalculation();
                validator.isValidProductDetail(prodDet, ProductType);
            }   
            else if (this.ProductType.Equals("MaterialItems"))
            {
                MaterialViewModel materi = mapper.Map<MaterialViewModel>(this.ProductDetail);
                prodDet = materi.ConvertToItem();
                price = materi.unitPriceItemCalculation();
                validator.isValidProductDetail(prodDet, ProductType);
            }
            else if (this.ProductType.Equals("GarmentItems"))
            {
                GarmentViewModel garment = mapper.Map<GarmentViewModel>(this.ProductDetail);
                prodDet = garment.ConvertToItem();
                price = garment.unitPriceItemCalculation();
                validator.isValidProductDetail(prodDet, ProductType);
            }
            else if (this.ProductType.Equals("TransportationServices"))
            {
                TransportationServicesViewModel trans = mapper.Map<TransportationServicesViewModel>(this.ProductDetail);
                prodDet = trans.ConvertToServ();
                price = trans.RateCostCalculation(condition, userDemand, Duration);
                validator.isValidProductDetail(prodDet, ProductType);
            }
            else if (this.ProductType.Equals("TelecommunicationServices"))
            {
                TelecomunicationServiceViewModel tele = mapper.Map<TelecomunicationServiceViewModel>(this.ProductDetail);
                prodDet = tele.ConvertToServ();
                price = tele.RateCostCalculation(condition, userDemand, Duration);
                validator.isValidProductDetail(prodDet, ProductType);
            }
            else
            {
                price = 0;
                ProductDetail = null;
            }

            if (validator.isValidProductDetail(prodDet, ProductType))
            {
                return new Product()
                {
                    ProductID = this.ProductID,
                    ProductName = this.ProductName,
                    SupplierID = this.SupplierID,
                    CategoryID = this.CategoryID,
                    QuantityPerUnit = this.QuantityPerUnit,
                    UnitPrice = price,
                    UnitsInStock = this.UnitsInStock,
                    UnitsOnOrder = this.UnitsOnOrder,
                    ReorderLevel = this.ReorderLevel,
                    Discontinued = this.Discontinued,
                    ProductType = this.ProductType,
                    ProductDetail = prodDet
                };
            }
            else
            {
                return null;
            }
        }

        public Product ConvertToProduct2(string condition = null, int? userDemand = null, decimal? Duration = null)
        {
            decimal? price = null;
            Dictionary<string, object> prodDict = new Dictionary<string, object>();
            ProductValidator validator = new ProductValidator();
            var config = new MapperConfiguration(cfg => { });
            var mapper = new Mapper(config);
            
            if (this.ProductType.Equals("FoodAndBeverageItems"))
            {
                FoodBevItemViewModel food = mapper.Map<FoodBevItemViewModel>(this.ProductDetail);
                prodDict = food.fromItemToDict();
                price = food.unitPriceItemCalculation();
                validator.isValidProductDetail(prodDict, ProductType);
            }
            else if (this.ProductType.Equals("MaterialItems"))
            {
                MaterialViewModel materi = mapper.Map<MaterialViewModel>(this.ProductDetail);
                prodDict = materi.fromItemToDict();
                price = materi.unitPriceItemCalculation();
                validator.isValidProductDetail(prodDict, ProductType);
            }
            else if (this.ProductType.Equals("GarmentItems"))
            {
                GarmentViewModel garment = mapper.Map<GarmentViewModel>(this.ProductDetail);
                prodDict = garment.fromItemToDict();
                price = garment.unitPriceItemCalculation();
                validator.isValidProductDetail(prodDict, ProductType);
            }
            else if (this.ProductType.Equals("TransportationServices"))
            {
                TransportationServicesViewModel trans = mapper.Map<TransportationServicesViewModel>(this.ProductDetail);
                prodDict = trans.fromServToDict();
                price = trans.RateCostCalculation(condition, userDemand, Duration);
                validator.isValidProductDetail(prodDict, ProductType);
            }
            else if (this.ProductType.Equals("TelecommunicationServices"))
            {
                TelecomunicationServiceViewModel tele = mapper.Map<TelecomunicationServiceViewModel>(this.ProductDetail);
                prodDict = tele.fromServToDict();
                price = tele.RateCostCalculation(condition, userDemand, Duration);
                validator.isValidProductDetail(prodDict, ProductType);
            }
            else
            {
                price = 0;
                ProductDetail = null;
            }

            if (validator.isValidProductDetail(prodDict, ProductType))
            {
                return new Product()
                {
                    ProductID = this.ProductID,
                    ProductName = this.ProductName,
                    SupplierID = this.SupplierID,
                    CategoryID = this.CategoryID,
                    QuantityPerUnit = this.QuantityPerUnit,
                    UnitPrice = price,
                    UnitsInStock = this.UnitsInStock,
                    UnitsOnOrder = this.UnitsOnOrder,
                    ReorderLevel = this.ReorderLevel,
                    Discontinued = this.Discontinued,
                    ProductType = this.ProductType,
                    ProductDetail = prodDict.ToString()
                };
            }
            else
            {
                return null;
            }
            
        }

        public Dictionary<string, object> FinalResult(List<ProductCustomViewModel> listObject, string msg)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            result.Add("Message", msg);
            result.Add("Data", listObject);
            return (result);
        }
    }
}