using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.ViewModels.ProductCustom.Services
{
    interface IProductService
    {
        char Delimiter();
        string ConvertToServ();
        decimal? RateCostCalculation(string condition = null, int? userDemand = null, decimal? Duration=null);
    }
}
