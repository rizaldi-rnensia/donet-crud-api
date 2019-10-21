using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Northwind.ViewModels.NewProductCustom.Interface;
using Northwind.EntityFramworks;

namespace Northwind.ViewModels.NewProductCustom.ProductItems
{
    public class MaterialViewModel : ProductDetailViewModel1, IProductItems
    {
        public string ProductionDate { get; set; }
        public string ExpiredDate { get; set; }
        public string MaterialsType { get; set; }
        public string IsConsumable { get; set; }
        public string UnitOfMeasurement { get; set; }
        public string CostRate { get; set; }

        public MaterialViewModel()
        {

        }
        public MaterialViewModel(Product product, char? dmtr)
        {
            this.ProductID = product.ProductID;
            if (!string.IsNullOrEmpty(product.ProductDetail))
            {
                string[] prod = product.ProductDetail.Split(Delimiter(dmtr));
                this.ProductDescription = prod[0];
                this.UnitProvit = prod[1];
                this.ProductionCode = prod[2];
                this.ProductionDate = prod[3];
                this.ExpiredDate = prod[4];
                this.MaterialsType = prod[5];
                this.IsConsumable = prod[6];
                this.UnitOfMeasurement = prod[7];
                this.CostRate = prod[8];
            }
        }

        public char Delimiter(char? dlmtr)
        {
            if (dlmtr != null)
            {
                return Convert.ToChar(dlmtr);
            }
            else
            {
                return '|';
            }
        }

        public string ConvertToItem(char? dlmtr)
        {
            return
                this.ProductDescription + Delimiter(dlmtr) +
                this.UnitProvit + Delimiter(dlmtr) +
                this.ProductionCode + Delimiter(dlmtr) +
                this.ProductionDate + Delimiter(dlmtr) +
                this.ExpiredDate + Delimiter(dlmtr) +
                this.MaterialsType + Delimiter(dlmtr) +
                this.IsConsumable + Delimiter(dlmtr) +
                this.UnitOfMeasurement + Delimiter(dlmtr) +
                this.CostRate;
        }

        public Dictionary<string, object> FromItemToDict()
        {
            Dictionary<string, object> materialDict = new Dictionary<string, object>();
            materialDict.Add("ProductID", this.ProductID);
            materialDict.Add("ProductDescription", this.ProductDescription);
            materialDict.Add("UnitProvit", this.UnitProvit);
            materialDict.Add("ProductionCode", this.ProductionCode);
            materialDict.Add("ProductionDate", this.ProductionDate);
            materialDict.Add("ExpiredDate", this.ExpiredDate);
            materialDict.Add("MaterialsType", this.MaterialsType);
            materialDict.Add("IsConsumable", this.IsConsumable);
            materialDict.Add("UnitOfMeasurement", this.UnitOfMeasurement);
            materialDict.Add("CostRate", this.CostRate);
            return materialDict;
        }

        public decimal UnitPriceItemCalculation()
        {
            return decimal.Parse(this.CostRate) * (Convert.ToDecimal(110) / Convert.ToDecimal(100));
        }
    }
}