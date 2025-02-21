using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Assignment_2.Controllers
{
    [Route("api/J1")]
    [ApiController]
    public class J1 : ControllerBase
    {

        [HttpPost(template: "DelivEDroid")]
        [Consumes("application/x-www-form-urlencoded")]

        public int DelivEDroid(int Collisions, int Deliveries)
        {
            // <summary>
            // Deliv-e-droid, a robot droid has to deliver packages while avoiding obstacles.
            // calculated final score based on deliveries and collisions with obstacles
            // </summary>
            // <param name="collisions">The number of collisions the robot has with obstacles.</param>
            // <param name="deliveries">The number of packages the robot successfully delivers.</param>
            // <returns>he final score based on the deliveries and collisions</returns>
            // <example>
            //   POST : localhost:7151/api/J1/DelivEDroid?Collisions=2&Deliveries=5
            // </example>
            //<result>730</result>
            // <example>
            //   POST : localhost:7151/api/J1/DelivEDroid?Collisions=10&Deliveries=0
            // </example>
            //<result>-100</result>
            // <example>
            //   POST : localhost:7151/api/J1/DelivEDroid?Collisions=3&Deliveries=2
            // </example>
            //<result>70</result>

            int Final_Score = (Deliveries * 50) - (Collisions * 10);

            // Add bonus if Deliveries > Collisions
            if (Deliveries > Collisions)
            {
                Final_Score = Final_Score + 500;
            }

            return Final_Score;
        }

        [HttpPost("SpecialDay")]
        [Consumes("application/x-www-form-urlencoded")]
        public string SpecialDay([FromForm] int month, [FromForm] int day)
        {

            // <summary>
            // asks the user for a numerical month and numerical day of the month.
            // determines whether that date occurs before, after, or on February 18.
            // </summary>

            // <param name="month">The month of the date. </param>
            // <param day="deliveries">The day of the month.</param>
            // <returns>A string indicating whether the date is "Before", "After", or "Special".</returns>
            // <example>
            //   POST : localhost:7151/api/J1/SpecialDay
            //   month=1&day=7
            // </example>
            //<result>Before</result>
            // <example>
            //   POST : localhost:7151/api/J1/SpecialDay
            //   month=8&day=31
            // </example>
            //<result>After</result>
            // <example>
            //  POST : localhost:7151/api/J1/SpecialDay
            //   month=2&day=18
            // </example>
            //<result>Special</result>


            if (month < 2 && day < 18)
            {
                return "Before";
            }
            else if (month > 2 && day > 18)
            {
                return "After";
            }
            else
            {
                return "Special";
            }

        }

    }
}
