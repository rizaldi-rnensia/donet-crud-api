using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Northwind.Domain.ViewModels
{
    public class ProductDetailCalculatorParameter
    {
        public int? UserDemand { get; set; }
        public string Wheater { get; set; }
        public int? Duration { get; set; }

        public int getNonNullUserDemand() {
            return this.UserDemand ?? 0;
        }

        public int getNonNullDuration() {
            return this.Duration ?? 0;
        }
    }
}