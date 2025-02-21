using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_2.Controllers
{
    [Route("api/J2")]
    [ApiController]
    public class J2 : ControllerBase
    {


        [HttpGet("ChiliPeppers")]
        public IActionResult ChiliPeppers([FromQuery] string ingredientsName)
        {
            // <summary>
            // calculates the total spiciness of a list of chili peppers
            // </summary>

            // <param name="ingredientsName">string of pepper name </param>

            // <returns>Returns the total spiciness (in SHU) as an integer</returns>
            // <example>
            //   GET : localhost:7151/api/J2/ChiliPeppers?ingredientsName=Poblano%2C%20Cayenne%2CThai%2CPoblano
            // </example>
            //<result>118000</result>
            // <example>
            //   GET : localhost:7151/api/J2/ChiliPeppers?ingredientsName=Habanero%20%2CHabanero%2CHabanero%2CHabanero%2CHabanero
            // </example>
            //<result>625000</result>
            // <example>
            //   GET : localhost:7151/api/J2/ChiliPeppers?ingredientsName=Poblano%2C%20Mirasol%2CSerrano%2CCayenne%2CThai%2CHabanero%2CSerrano
            // </example>
            //<result>278500</result>

            Dictionary<string, int> PepperSHU = new Dictionary<string, int>()
            {
                { "Poblano", 1500 },
                { "Mirasol", 6000 },
                { "Serrano", 15500 },
                { "Cayenne", 40000 },
                { "Thai", 75000 },
                { "Habanero", 125000 }
            };

            string[] peppers = ingredientsName.Split(',');
            int TotalSpiciness = 0;

            for (int i = 0; i < peppers.Length; i++)
            {
                string pepperName = peppers[i].Trim();
                if (PepperSHU.ContainsKey(pepperName))
                {
                    TotalSpiciness = TotalSpiciness + PepperSHU[pepperName];
                }
                else
                {
                    return BadRequest("Invalid Pepper Name: " + pepperName);
                }
            }

            return Ok(TotalSpiciness);
        }

        [HttpGet("FaceMood")]
        public IActionResult FaceMood([FromQuery] string Mood)
        {

            // <summary>
            // A string containing emoticons to determine the overall mood
            // </summary>

            // <param name="Mood">A string containing emoticons such as ":-)" (happy) and ":-(" (sad).</param>
            // <param name = "happyCount" > The count of happy emoticons found in the input string.</param>
            // <param name= "sadCount">The count of sad emoticons found in the input string.</param>
            // <returns>Returns a string indicating the mood like happy , sad, unsure, and none</returns>
            // <example>
            //   GET : localhost:7151/api/J2/FaceMood?Mood=How%20are%20you%20%3A-%29%20doing%20%3A-%28%20today%20%3A-%29%3F
            // </example>
            //<result>happy</result>
            // <example>
            //   GET : localhost:7151/api/J2/FaceMood?Mood=%3A%29
            // </example>
            //<result>none</result>
            // <example>
            //   GET : localhost:7151/api/J2/FaceMood?Mood=This%3A-%28is%20str%3A-%28%3A-%28ange%20te%3A-%29xt.
            // </example>
            //<result>sad</result>

            int happyCount = 0;
            int sadCount = 0;


            for (int i = 0; i < Mood.Length - 2; i++)
            {
                string sub = Mood.Substring(i, 3);


                if (sub == ":-)")
                {
                    happyCount++;
                }
                else if (sub == ":-(")
                {
                    sadCount++;
                }
            }


            if (happyCount == 0 && sadCount == 0)
            {
                return Ok("none");
            }
            else if (happyCount == sadCount)
            {
                return Ok("unsure");
            }
            else if (happyCount > sadCount)
            {
                return Ok("happy");
            }
            else
            {
                return Ok("sad");
            }
        }

    }
}
