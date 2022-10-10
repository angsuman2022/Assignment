using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shared.Model;
using ReaderAPI.Models;
using MassTransit;
using Microsoft.Extensions.Configuration;

namespace ReaderAPI.Consumers
{
    public class PaymentConsumer : IConsumer<Payment>
    {

        BookAuthorContext db;


        private IConfiguration _config;

        public PaymentConsumer(IConfiguration config, BookAuthorContext _db)
        {

            _config = config;
            db = _db;
        }
        //BookAuthorContext db = new BookAuthorContext();
        public Task Consume(ConsumeContext<Payment> context)
        {
            var data = context.Message;
            var Invoicedata = db.TblInvoices.Where(x => x.Year == "2022").FirstOrDefault();
            Invoicedata.SlNo = Invoicedata.SlNo + 1;
            db.TblInvoices.Update(Invoicedata);
            db.SaveChanges();
            return Task.CompletedTask;
        }
    }
}
