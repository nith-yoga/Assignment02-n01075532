using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class J1Controller : Controller
    {
        [HttpGet]
        /* GET: /J1/CalculateCost?R=0&G=0&B=0
           Replace the 0s with the values for R, G, and B. */
        public ActionResult CalculateCost(int R, int G, int B)
        {
            //Define costs for R (Red), G (Green), B (Blue)
            int costR = 3;
            int costG = 4;
            int costB = 5;

            int totalCost = R * costR + G * costG + B * costB;

            return Content(totalCost.ToString());
        }
    }
} 