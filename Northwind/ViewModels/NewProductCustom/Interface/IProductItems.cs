using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.ViewModels.NewProductCustom.Interface
{
    interface IProductItems
    {
        char Delimiter(char? dlmtr);
        string ConvertToItem(char? dlmtr);
        decimal UnitPriceItemCalculation();
        Dictionary<string, object> FromItemToDict();
    }
}
