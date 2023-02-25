using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Assignment2.Controllers
{
    public class JController : ApiController
    {
        /*Problem J1: Deliv-e-droid
       Problem Description
       In the game, Deliv-e-droid, a robot droid has to deliver packages while avoiding obstacles.
       At the end of the game, the final score is calculated based on the following point system:
       • Gain 50 points for every package delivered.
       • Lose 10 points for every collision with an obstacle.
       • Earn a bonus 500 points if the number of packages delivered is greater than the number
       of collisions with obstacles.
       Your job is to determine the final score at the end of a game. */
        /// </summary>
        /// <param name="p">int input no. of package </param>
        /// <param name="c">int input no. of collision</param>
        /// <returns>final score </returns>
        /// <example> 
        /// GET http://localhost:59124/api/J/ProblemJ1/5/2  ->  730
        /// GET http://localhost:59124/api/J/ProblemJ1/3/6  ->  90
        /// </example> 
        /// 
        [HttpGet]
        [Route("api/J/ProblemJ1/{p}/{c}")]
        public int ProblemJ1(int p, int c)
        {
            int score;
            int bonus = 0;

            if (p > c)
            {
                bonus = 500;
            }
            score = (p * 50) - (c * 10) + bonus;

            return score;

        }





        /// <summary>
        ///  Problem J2
        /*  Ron is cooking chili using an assortment of peppers.
         The spiciness of a pepper is measured in Scolville Heat Units(SHU). Ron’s chili is currently
         not spicy at all, but each time Ron adds a pepper, the total spiciness of the chili increases
         by the SHU value of that pepper.
         The SHU values of the peppers available to Ron are shown in the following table:
         Pepper Name Scolville Heat Units
         Poblano 1500
         Mirasol 6000
         Serrano 15500
         Cayenne 40000
         Thai 75000
         Habanero 125000
         Your job is to determine the total spiciness of Ron’s chili after he has finished adding peppers. */

        /// 
        /// </summary>
        /// <param name="n">int input no. of peppers </param>
        /// <param name="peppers"> string input name of peppers added </param>
        /// <returns> int output total heat </returns>
        /// <example> 
        /// GET http://localhost:59124/J/ProblemJ2/3/Poblano,Cayenne,Thai   ->  116500
        /// GET http://localhost:59124/J/ProblemJ2/4/Mirasol,Cayenne,Thai,Habanero   -> 246000
        /// <example> 


        [HttpGet]
        [Route("api/J/ProblemJ2/{n}/{peppers}")]
        public int ProblemJ2(int n, string peppers)
        {
            int i;

            string[] listPeppers = peppers.Split(',').ToArray();
            int heat = 0;

            for (i = 0; i < listPeppers.Count(); i++)
            {
                if (listPeppers[i] == "Poblano")
                {
                    heat = heat + 1500;
                }
                else if (listPeppers[i] == "Mirasol")
                {
                    heat = heat + 6000;
                }
                else if (listPeppers[i] == "Serrano")
                {
                    heat = heat + 15500;
                }
                else if (listPeppers[i] == "Cayenne")
                {
                    heat = heat + 40000;
                }
                else if (listPeppers[i] == "Thai")
                {
                    heat = heat + 75000;
                }
                else if (listPeppers[i] == "Habanero")
                {
                    heat = heat + 125000;
                }
            }
            return heat;
        }




        /// <summary>
        /// Problem J3 
        /* You are trying to schedule a special event on one of five possible days.
        Your job is to determine on which day you should schedule the event, so that the largest
        number of interested people are able to attend.
            The first line of input will contain a positive integer N, representing the number of people
        interested in attending your event. The next N lines will each contain one person’s availability using one character for each of Day 1, Day 2, Day 3, Day 4, and Day 5 (in that order).
        The character Y means the person is able to attend and a period(.) means the person is
        not able to attend. 
        
         3
            Y,.,.,Y,Y
            Y,.,.,.,Y
            Y,.,Y,Y,Y

        Will give result 1,5
         */
        /// </summary>
        /// <param name="n">int input n numbr of people</param>
        /// <param name="schedule">string input schedule of 5 days (so of length n times 5 ) </param>
        /// <returns></returns>
        /// <example> 
        /// GET http://localhost:59124/J/ProblemJ2/3/Y,.,.,Y,Y,Y,.,.,.,Y,Y,.,Y,Y,Y
        /// </example>

        [HttpGet]
        [Route("api/J/ProblemJ3/{n}/{schedule}")]
        public string ProblemJ3(int n, string schedule)
        {
            int day;
            string[] scheduleArray = schedule.Split(',').ToArray();
            int[] arr = new int[5];
            int k;
            for (int j = 0; j < 5; j++)
            {
                arr[j] = 0;
            }

            for (int i = 0; i < scheduleArray.Count(); i++)
            {
                /* 1. sum  all the Y which occurs in a particular column and write  the result in an array
                   2. for example array looks like [3,4,3,4,1].
                3. now write 2,4 because 4 occured on 2nd and fourth index. 
                 */
                if (scheduleArray[i] == "Y")
                {
                    k = i % 5;
                    arr[i] += 1;
                }


            }

            string arrStr = string.Join(",", arr);

            return arrStr;
        }


    }
}
