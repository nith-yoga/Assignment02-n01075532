using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class J3Controller : Controller
    {
        // GET: J3
        [HttpGet]
        public ActionResult CalculateBronzeLevel(List<int> scores) 
        {
            //Check for null or insufficient results
            if (scores == null || scores.Count < 3)
            {
                return Content("At least three scores needed.");
            }
            //Initializing variables:
            //By initializing the scores to -1 we ensure that any non-negative score will increase the threshold naturally
            int goldScore = -1;
            int silverScore = -1;
            int bronzeScore = -1;
            //Initialize the variables for the number of participants so that participants in gold, silver, and bronze can be counted accordingly
            int goldCount = 0;
            int silverCount = 0;
            int bronzeCount = 0;

            //Processing each score
            foreach (int score in scores)
            {
                if (score > goldScore) {
                    //If the score is higher than goldScore, it shifts each of the scores up one place & sets goldScore to the current score
                    bronzeScore = silverScore;
                    silverScore = goldScore;
                    goldScore = score;

                    bronzeCount = silverCount;
                    silverCount = goldCount;
                    goldCount = 1;
                }
                else if (score == goldScore)
                {
                    //if the score is equal to goldScore, we simply increase goldCount
                    goldCount++;
                }
                else if (score > silverScore)
                {
                    //Repeating the same process for silverScore, and then for bronzeScore
                    bronzeScore = silverScore;
                    silverScore = score;

                    bronzeCount = silverCount;
                    silverCount = 1;
                }
                else if (score == silverScore)
                {
                    silverCount++;
                }
                else if (score > bronzeScore)
                {
                    bronzeScore = score;
                    bronzeCount = 1;
                }
                else if (score == bronzeScore)
                {
                    bronzeCount++;
                }
            }
            //Now that we have the bronze scores and the bronze count, return results as a string:
            return Content("Bronze Score: " + bronzeScore + ", Bronze Count: " + bronzeCount);
        }
    }
}