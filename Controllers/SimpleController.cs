using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi;

namespace WebApi.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class SimpleController : ControllerBase
    {
        public SimpleController()
        {
        }

        // GET api/simple
        [HttpGet(" ")]
        public ActionResult<IEnumerable<string>> Gets()//Getstrings()
        {
            return new List<string> { "value1","value2" };
        }

        // GET api/simple/5
        [HttpGet("/CalculateInterest/{amount}/{interestpercent}")]
        public ActionResult<IEnumerable<Graph>> CalculateInterest(long amount,int interestpercent)
        {       
            //((จำนวนเงิน)*(อัตราดอกเบี้ย))/จำนวนงวดที่ชำระ
            var Listmonth = new List<int>(){12,24,36,72};
            var result = new List<Graph>();
            Listmonth.ForEach((month) => {
                var interest = (amount * interestpercent) / month;
                result.Add(new Graph(){Month = month,Interest = interest});
            });
            
            return result;//string.Format("amout {0} mount {1} percent {2}",amout,mount,percent);
        }


        [HttpPost("/GetProducts/{amount}/{interestpercent}")]
        public IActionResult GetProducts(long amount,int interestpercent)
        {
             //((จำนวนเงิน)*(อัตราดอกเบี้ย))/จำนวนงวดที่ชำระ
            var Listmonth = new List<int>(){12,24,36,72};
            var result = new List<Graph>();
            Listmonth.ForEach((month) => {
                var interest = (amount * interestpercent) / month;
                result.Add(new Graph(){Month = month,Interest = interest});
            });
            
           
                return new JsonResult(result);
        }

        // POST api/simple
        [HttpPost("")]
        public void Poststring(string value)
        {
        }

        // PUT api/simple/5
        [HttpPut("{id}")]
        public void Putstring(int id, string value)
        {
        }

        // DELETE api/simple/5
        [HttpDelete("{id}")]
        public void DeletestringById(int id)
        {
        }
    }
}