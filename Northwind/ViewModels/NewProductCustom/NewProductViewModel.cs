using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Northwind.EntityFramworks;
using Northwind.ViewModels;
using Northwind.ViewModels.NewProductCustom.ProductItems;
using Northwind.ViewModels.NewProductCustom.ProductSrevices;

namespace Northwind.ViewModels.NewProductCustom
{
    public class NewProductViewModel : ProductViewModel
    {
        public NewProductViewModel()
        {

        }

        public NewProductViewModel(Product product, char? dlmtr)
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
            if (ProductType != null)
            {
                switch (ProductType)
                {
                    case "FoodAndBeverageItems":
                        FoodAndBeveragesViewModel food = new FoodAndBeveragesViewModel(product, dlmtr);
                        ProductDetail = food.FromItemToDict();
                        break;
                    case "GarmentItems":
                        GarmentViewModel garment = new GarmentViewModel(product, dlmtr);
                        ProductDetail = garment.FromItemToDict();
                        break;
                    case "MaterialItems":
                        MaterialViewModel materi = new MaterialViewModel(product, dlmtr);
                        ProductDetail = materi.FromItemToDict();
                        break;
                    case "TransportationServices":
                        TransportationServicesViewModel trans = new TransportationServicesViewModel(product, dlmtr);
                        ProductDetail = trans.FromServToDict();
                        break;
                    case "TelecommunicationServices":
                        TelecomunicationServicesViewModel telecomunication = new TelecomunicationServicesViewModel(product, dlmtr);
                        ProductDetail = telecomunication.FromServToDict();
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
        internal Product ConvertToProduct(string condition = null, int? userDemand = null, decimal? Duration = null, char? dlmtr=null)
        {
            decimal? price = null;
            var prodDet = "";
            var config = new MapperConfiguration(cfg => { });
            var mapper = new Mapper(config);
            if (this.ProductType.Equals("FoodAndBeverageItems"))
            {
                FoodAndBeveragesViewModel food = mapper.Map<FoodAndBeveragesViewModel>(this.ProductDetail);
                prodDet = food.ConvertToItem(dlmtr);
                price = food.UnitPriceItemCalculation();
            }
            else if (this.ProductType.Equals("MaterialItems"))
            {
                MaterialViewModel materi = mapper.Map<MaterialViewModel>(this.ProductDetail);
                prodDet = materi.ConvertToItem(dlmtr);
                price = materi.UnitPriceItemCalculation();
            }
            else if (this.ProductType.Equals("GarmentItems"))
            {
                GarmentViewModel garment = mapper.Map<GarmentViewModel>(this.ProductDetail);
                prodDet = garment.ConvertToItem(dlmtr);
                price = garment.UnitPriceItemCalculation();
            }
            else if (this.ProductType.Equals("TransportationServices"))
            {
                TransportationServicesViewModel trans = mapper.Map<TransportationServicesViewModel>(this.ProductDetail);
                prodDet = trans.ConvertToServ(dlmtr);
                price = trans.RateCostCalculation(condition, userDemand, Duration);
            }
            else if (this.ProductType.Equals("TelecommunicationServices"))
            {
                TelecomunicationServicesViewModel tele = mapper.Map<TelecomunicationServicesViewModel>(this.ProductDetail);
                prodDet = tele.ConvertToServ(dlmtr);
                price = tele.RateCostCalculation(condition, userDemand, Duration);
            }
            else
            {
                price = 0;
                ProductDetail = null;
            }
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

        public Product CalculateUnitPrice(string condition = null, int? userDemand = null, decimal? Duration = null)
        {
            return new Product()
            {
                ProductID = this.ProductID,
                ProductName = this.ProductName,
                SupplierID = this.SupplierID,
                CategoryID = this.CategoryID,
                QuantityPerUnit = this.QuantityPerUnit,
                UnitPrice = null,
                UnitsInStock = this.UnitsInStock,
                UnitsOnOrder = this.UnitsOnOrder,
                ReorderLevel = this.ReorderLevel,
                Discontinued = this.Discontinued,
                ProductType = this.ProductType,
                ProductDetail = null
            };
        }

        public Dictionary<string, object> FinalResult(List<NewProductViewModel> listObject, string msg)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            result.Add("Message", msg);
            result.Add("Data", listObject);
            return (result);
        }
    }
}