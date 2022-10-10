using AuthorAPI.Services;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorAPI.Models;
using Shared.Model;


namespace AuthorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {

        IUserService userService;
        private readonly IBus bus;
       // CustomerDBContext db = new CustomerDBContext();
        public PaymentController(IBus _bus, IUserService _userService)
        {
            bus = _bus;
            userService = _userService;
        }
        [HttpPost]
        public async Task<IActionResult> CreatePyment(TblPayment payment)
        {
            if (payment != null)
            {
                bool chk = userService.PaymentBook(payment);
                if(chk==false)
                {
                    return Ok(new { status = "Payement is already done" });
                }
                Uri uri = new Uri("rabbitmq:localhost/orderQueue");
                var endpoint = await bus.GetSendEndpoint(uri);
                Payment paymentMessage = new Payment();
                paymentMessage.bookId = payment.BookId;
                paymentMessage.InvoiceNo = payment.InvoiceNo;
                paymentMessage.paymentBy = payment.PaymentBy;
                paymentMessage.paymentDate = payment.PaymentDate;
                paymentMessage.paymentName = payment.PaymentName;
                paymentMessage.paymentCard = payment.PaymentCard;
                paymentMessage.cancelOrder = payment.CancelOrder;
                await endpoint.Send(paymentMessage);
                return Ok(new { status = "Your payment is placed" });
            }
            return BadRequest();
        }
        //[HttpGet]
        //[Route("get-order")]
        //public IEnumerable<TblOrder> getOrder()
        //{
        //    return db.TblOrders;
        //}
    }
}
