using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Results;
using Northwind.EntityFramworks;
using Northwind.ViewModels.NewProductCustom;

namespace Northwind.Controllers
{
    [RoutePrefix("api/Test")]
    public class TestController : ApiController
    {
        [Route("Palindrome")]
        [HttpPost]
        public IHttpActionResult Palindrome(string inputStr)
        {
            string rev;
            char[] ch = inputStr.ToCharArray();
            Array.Reverse(ch);
            rev = new string(ch);
            bool b = inputStr.Equals(rev, StringComparison.OrdinalIgnoreCase);
            if (b == true)
            {
                return Ok("" + inputStr + " is a Palindrome!");
            }
            else
            {
                return Ok(" " + inputStr + " is not a Palindrome!");
            }
        }

        [Route("PrimeNumber")]
        [HttpPost]
        public IHttpActionResult PrimeNumber(int num)
        {
            int a = 0;
            for (int i = 1; i <= num; i++)
            {
                if (num % i == 0)
                {
                    a++;
                }
            }
            if (a == 2)
            {
                return Ok(num+"is a Prime Number");
            }
            else
            {
                return Ok(num+"is NOT a Prime Number");
            }
        }

        [Route("GanjilGenap")]
        [HttpPost]
        public IHttpActionResult GanjilGenap(int inputNum)
        {
            if(inputNum%2 == 0)
            {
                return Ok(inputNum+" is not odd number");
            }
            else
            {
                return Ok(inputNum + " is odd number");
            }
        }


        [Route("ArrayToString")]
        [HttpPost]
        public IHttpActionResult ArrayToString(int inputNum)
        {
            var count = 100;
            var list = new List<int>(count);
            var random = new Random();
            list.Add(0);

            for (var i = 1; i < count; i++)
            {
                var swap = random.Next(i - 1);
                list.Add(list[swap]);
                list[swap] = i;
            }

            foreach (var item in list)
            {
                if (inputNum==item)
                {
                    _ = item * 100;
                }
            }
            return Ok(list);
        }
    }
}