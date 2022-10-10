using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Model
{
    public class Payment
    {
        public int paymentId { get; set; }
        public int? bookId { get; set; }
        public string InvoiceNo { get; set; }
        public int ?paymentBy { get; set; }
        public DateTime ?paymentDate { get; set; }
        public string paymentName { get; set; }
        public string paymentCard { get; set; }
        public bool ?cancelOrder { get; set; }
    }
}
