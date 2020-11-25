using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace Lockeroom.Controllers
{
    [Route("api/")]
    public class GedungController : Controller
    {
       [HttpPost("floor")]
       public Output Floor([FromBody] Input body)
        {
            Output output = new Output
            {
                NoFloor = 0
            };

            List<int> LockerOrder = new List<int>
            {
                5, 6, 7
            };

            int Now = 0;
            int x = 0;

            while (body.NoLocker > Now)
            {
                if (x >= 3) x = 0;
                Now += LockerOrder[x];
                output.NoFloor++; 
                x++;
            }
            
            return output;
        }
    }
    public class Input
    {
        public int NoLocker { set; get; }
    }
    public class Output
    {
        public int NoFloor { set; get; }
    }
}