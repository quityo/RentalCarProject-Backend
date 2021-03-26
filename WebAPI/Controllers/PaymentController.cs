using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        [HttpPost("payment")]
        public ActionResult Payment(bool paymentStatus)
        {
            Result result;
            if (paymentStatus)
            {
                result = new Result(true, "Payment Successful");
                return Ok(result);
            }
            result = new Result(false, "Payment failed");
            return BadRequest(result);
        }
    }
}
