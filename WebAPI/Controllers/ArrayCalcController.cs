using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    public class ArrayCalcController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        [Route("[action]")]
        [Route("api/arraycalc/reverse")]
        public string Reverse()
        {
            //get array of all element
            var page = HttpContext.Request.Query["productIds"].ToArray();

            string temp;

            // traverse 0 to array length
            for (int i = 0; i < page.Length - 1; i++)

                // traverse i+1 to array length
                for (int j = i + 1; j < page.Length; j++)

                    // compare array element with 
                    // all next element
                    if (Int32.Parse(page[i]) < Int32.Parse(page[j]))
                    {

                        temp = page[i];
                        page[i] = page[j];
                        page[j] = temp;
                    }

            //return result
            return String.Join(", ", page);
        }

        [HttpGet]
        [Route("api/arraycalc/deletepart")]
        public string DeletePart(int position)
        {
           //cerate list for manipulation
            List<string> result = new List<string>();
            //get arrays for all elements
            var page = HttpContext.Request.Query["productIds"].ToArray();
            //check if posion getre than lenght of array
            if (position < page.Length)
            {
                for (int i = 0; i < page.Length; i++)
                {
                    //if remove position ignore the element
                    if (i == position - 1)
                    {
                        continue;
                    }
                    //add new element to list
                    result.Add(page[i].ToString());
                }
            }
            else
            {
                return "The position is greater than lenght of elements";
            }
            //return result
            return String.Join(", ", result.ToArray());
        }
    }
}
