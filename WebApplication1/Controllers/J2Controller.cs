using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class J2Controller : Controller
    {
        // GET: J2/Index
        public ActionResult Index()
        {
            int D = int.Parse(Request.QueryString["D"]); //Dusa's original size, int D
            string yobiInput = Request.QueryString["Y"];
            int[] Y = yobiInput.Split(',').Select(int.Parse).ToArray(); //Yobi's sizes, int D [The user can input multiple numbers and they will be split & converted to separate integers, then placed in an array

            int R = D;

            foreach (int yobiSize in Y)
            {
                if (yobiSize < R)
                {
                    R += yobiSize;
                }
                else
                {
                    break;
                }
            }
            return Content(R.ToString());
        }
    }
}