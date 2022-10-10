using BookAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        BookAppDBContext db = new BookAppDBContext();

        [HttpPost]
        [Route("Book-Payment")]
        public IActionResult Post([FromBody] TblPayment obj)
        {
            obj.InvoiceNo = InvoiceNo();
            obj.PaymentDate = System.DateTime.Now;
            db.TblPayments.Add(obj);
            db.SaveChanges();
            var Invoicedata = db.TblInvoices.Where(x => x.Year=="2022").FirstOrDefault();
            Invoicedata.SlNo = Invoicedata.SlNo+1;
            db.TblInvoices.Update(Invoicedata);
            db.SaveChanges();
            var response = new { Status = "Payment Successful" };
            return Ok(response);
        }

        [HttpPost]
        [Route("Book-Cancel")]
        public IActionResult BookCancel([FromBody] Order obj)
        {
            var response = new { Status = "Cancel only possible within 24 hours" };
            bool Chk = PaymentDtComp(obj.PaymentId);
            if(!Chk)
            {
                return Ok(response);
            }
            var Paymentdata = db.TblPayments.Where(x => x.PaymentId == obj.PaymentId).FirstOrDefault();
            Paymentdata.CancelOrder = true;
            db.TblPayments.Update(Paymentdata);
            db.SaveChanges();
            response = new { Status = "Order cancel Successfull" };
            return Ok(response);
        }

        private string InvoiceNo()
        {



            var invoice = (from em in db.TblInvoices.Where(c => c.Active != false)
                           select new
                           {
                               Invoice = "Inv_" + em.Year + "_" + em.Month + "_" + em.SlNo.ToString()

                           }).FirstOrDefault();

            return invoice.Invoice;

        }
        private bool PaymentDtComp(int PaymentId)
        {

            var Order = (from em in db.TblPayments.Where(c => c.PaymentId == PaymentId)
                           select new
                           {
                               PaymentDate = em.PaymentDate

                           }).FirstOrDefault();

            bool rtn = DateTime.Now.AddDays(-2).Date <= Order.PaymentDate ? true : false;

            return rtn;
            
               

        }


    }
}
