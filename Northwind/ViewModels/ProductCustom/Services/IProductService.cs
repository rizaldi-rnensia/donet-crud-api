using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.ViewModels.ProductCustom.Services
{
    interface IProductService
    {
        Dictionary<string, object> fromServToDict();
        string ConvertToServ();

        decimal? rateCostCalculation(string condition = null, int? userDemand = null, decimal? Duration=null);
    }
}
