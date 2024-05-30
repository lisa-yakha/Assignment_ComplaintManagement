//using ComplaintManagement.Models;
using Microsoft.AspNetCore.Mvc;
using ComplaintManagement;
using Microsoft.AspNetCore.Authorization;
using System.Data.SqlClient;

namespace ComplaintManagement.Controllers
{
    public class ComplaintManagementController : Controller
    {
        private readonly DataServices data;
        public ComplaintManagementController(DataServices myData)
        {
            this.data = myData;
        }

        [Route("/checker")]
        [HttpGet]
        public IActionResult Checker()
        {
            return Ok("API is running");
        }

        [Route("/NewComplaint")]
        [HttpPost]
        public async Task<IActionResult> InsertComplaintAsync([FromBody] Models.ComplaintForm complaint)
        {
            bool result = await data.InsertComplaintAsync(complaint);
            if(result)
            {
                return Ok();
            }
            else 
            {
                return StatusCode(500, "Internal error"); ;
            }
        }


        [Route("/AllComplaints")]
        [HttpGet]
        public async Task<ActionResult> AllComplaints()
        {

            var complaints = await data.RetrieveAllComplaints();
            if (complaints == null)
                return BadRequest();
            return Ok(complaints);
        }

        [Route("/ByName")]
        [HttpGet]
        public async Task<ActionResult> ByName([FromQuery]string name)
        {

            var byName = await data.RetrieveComplaintsByNameAsync(name);
            if (byName == null)
                return BadRequest();
            return Ok(byName);
        }

        [Route("/ByDate")]
        [HttpGet]
        public async Task<ActionResult> ByDate([FromQuery]DateOnly date)
        {

            var byDate = await data.RetrieveComplaintsByDateAsync(date);
            if (byDate == null)
                return BadRequest();
            return Ok(byDate);
        }
        /*
        [Route("/testroute2")]
        [HttpGet]
        public async Task<double> TestRoute1([FromQuery] double a, [FromQuery] double b)
        {
            return a + b;
        }
        
        [Route("api/testroute3")]
        [HttpPost]
        public async Task<double> TestRoute3([FromBody] ExamplePostModel requestdata)
        {
            return requestdata.a + requestdata.b;
        }

        [Route("api/testroute4")]
        [HttpPost]
        public async Task<ExampleCalculations> TestRoute4([FromBody] ExamplePostModel requestdata)
        {
            ExampleCalculations calculations = new ExampleCalculations();
            calculations.Calculation1 = requestdata.a + requestdata.b;
            calculations.Calculation2 = requestdata.a * requestdata.b;

            return calculations;
        }

        [Route("api/testroute5")]
        [HttpPost]
        public async Task<Dictionary<string, List<ExampleCalculations>>> TestRoute5([FromBody] List<ExamplePostModel> requestdata)
        {
            Dictionary<string, List<ExampleCalculations>> finalresult = new Dictionary<string, List<ExampleCalculations>>();
            foreach (var item in requestdata)
            {
                List<ExampleCalculations> resultcalculations = new List<ExampleCalculations>();
                for (int i = 0; i < 50; i++)
                {
                    var rnd = new Random();
                    ExampleCalculations calculations = new ExampleCalculations();
                    calculations.Calculation1 = item.a + item.b + rnd.Next(1, 100);
                    calculations.Calculation2 = item.a * item.b + rnd.Next(1, 100);
                    resultcalculations.Add(calculations);
                }
                finalresult.Add(Guid.NewGuid().ToString(), resultcalculations);
            }


            return finalresult;
        }*/
    }
}
