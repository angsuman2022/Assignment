
using Microsoft.Extensions.Configuration;
using ReaderAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReaderAPI.Services
{
    public class ReaderServiceImpl:IReaderService
    {
        BookAuthorContext db;


        private IConfiguration _config;

        public ReaderServiceImpl(IConfiguration config, BookAuthorContext _db)
        {

            _config = config;
            db = _db;
        }

        public bool BookCancel( Order obj)
        {
            
            bool Chk = PaymentDtComp(obj.PaymentId);
            if (!Chk)
            {
                return false;
            }
            var Paymentdata = db.TblPayments.Where(x => x.PaymentId == obj.PaymentId).FirstOrDefault();
            Paymentdata.CancelOrder = true;
            db.TblPayments.Update(Paymentdata);
            db.SaveChanges();
            return true;
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
