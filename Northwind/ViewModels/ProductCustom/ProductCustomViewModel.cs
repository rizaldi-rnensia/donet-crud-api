using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using Northwind.EntityFramworks;
using AutoMapper;

namespace Northwind.ViewModels.ProductCustom
{
    public class ProductCustomViewModel : ProductViewModel
    {
        public ProductCustomViewModel()
        {
        }
        internal ProductCustomViewModel(Product product)
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
            //if (ProductType != null && product.ProductType.Contains("FoodAndBeverageItems"))
            if(ProductType != null)
            {
                switch (ProductType)
                {
                    case "FoodAndBeverageItems":
                        FoodBevItemViewModel food = new FoodBevItemViewModel(product);
                        ProductDetail = food.fromFoodToDict();
                        break;
                    case "GarmentItems":
                        GarmentViewModel garment = new GarmentViewModel(product);
                        ProductDetail = garment.fromFoodToGarment();
                        break;
                    case "MaterialItems":
                        MaterialViewModel materi = new MaterialViewModel(product);
                        ProductDetail = materi.fromFoodToMaterial();
                        break;
                    case "TransportationServices":
                        TransportationServicesViewModel trans = new TransportationServicesViewModel(product);
                        ProductDetail = trans.fromFoodToTrans();
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
        internal Product ConvertToProduct()
        {
            var prodDet = "";
            var config = new MapperConfiguration(cfg => { });
            var mapper = new Mapper(config);
            if (this.ProductType.Contains("FoodAndBeverageItems"))
            {
                FoodBevItemViewModel food = mapper.Map<FoodBevItemViewModel>(this.ProductDetail);
                prodDet = food.ConvertToFood();
            }   
            else if (this.ProductType.Contains("TransportationServices"))
            {
                TransportationServicesViewModel trans = mapper.Map<TransportationServicesViewModel>(this.ProductDetail);
                prodDet = trans.ConvertToTrans();
            }
            else if (this.ProductType.Contains("MaterialItems"))
            {
                MaterialViewModel materi = mapper.Map<MaterialViewModel>(this.ProductDetail);
                prodDet = materi.ConvertToMateri();
            }
            else if (this.ProductType.Contains("GarmentItems"))
            {
                GarmentViewModel garment = mapper.Map<GarmentViewModel>(this.ProductDetail);
                prodDet = garment.ConvertToGarment();
            }
            else
            {
                ProductDetail = null;
            }
            return new Product()
            {
                ProductID = this.ProductID,
                ProductName = this.ProductName,
                SupplierID = this.SupplierID,
                CategoryID = this.CategoryID,
                QuantityPerUnit = this.QuantityPerUnit,
                UnitPrice = this.UnitPrice,
                UnitsInStock = this.UnitsInStock,
                UnitsOnOrder = this.UnitsOnOrder,
                ReorderLevel = this.ReorderLevel,
                Discontinued = this.Discontinued,
                ProductType = this.ProductType,
                ProductDetail = prodDet
            };
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