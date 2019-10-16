using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Northwind.ViewModels.ProductCustom.Items;

namespace Northwind.ViewModels.ProductCustom.Items
{
    interface IProductItem
    {
        char Delimiter();
        string UnitOfMeasurement { get; set; }
        string CostRate { get; set; }
        Dictionary<string, object> fromItemToDict();
        string ConvertToItem();

        decimal unitPriceItemCalculation();
    }
}
