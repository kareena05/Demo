using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Test.Services;

namespace Test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IPayment payment;
        //private readonly IPaymenService paymenService;
        //private readonly IPaymenService2 paymenService2;

        public ValuesController(IPayment payment
            //IPaymenService paymenService, IPaymenService2 paymenService2//
            //
            )
        {
            this.payment = payment;
            //this.paymenService = paymenService;
            //this.paymenService2 = paymenService2;
        }

        [HttpGet]
        public IActionResult GetAsync()
        {
            switch ("Payment")
            {
                case "Paytm":
                    var testclas = new TestClass(new Paytm());
                    testclas.CallMethod();
                    break;
                case "GooglePay":
                    var testcla1s = new TestClass(new Googlepay());
                    testclas.CallMethod();
                    break;
                default:
                    break;
            }

            //var testclass = new TestClass(new Googlepay());
            //testclas.CallMethod();

            payment.PaytoCustomer();
            return Ok();
        }

    }

    public interface IPayment
    {
        public void PaytoCustomer();
    }

    public class Paytm : IPayment
    {
        public readonly int a = 21;
        public void PaytoCustomer()
        {
            throw new NotImplementedException();
        }
    }

    public class Googlepay : IPayment
    {
        public void PaytoCustomer()
        {
            throw new NotImplementedException();
        }
    }

    public class TestClass
    {
        private readonly IPayment payment;

        public TestClass(IPayment payment)
        {
            this.payment = payment;
        }

        public void CallMethod()
        {
            payment.PaytoCustomer();
        }
    }



}
