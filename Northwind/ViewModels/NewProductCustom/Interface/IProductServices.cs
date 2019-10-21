using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.ViewModels.NewProductCustom.Interface
{
    interface IProductServices
    {
        char Delimiter(char? dlmtr);
        string ConvertToServ(char? dlmtr);
        decimal? RateCostCalculation(string condition = null, int? userDemand = null, decimal? Duration = null);
        Dictionary<string, object> FromServToDict();
    }
}
