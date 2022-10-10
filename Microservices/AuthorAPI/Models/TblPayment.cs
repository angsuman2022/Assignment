using System;
using System.Collections.Generic;

#nullable disable

namespace AuthorAPI.Models
{
    public partial class TblPayment
    {
        public int PaymentId { get; set; }
        public int? BookId { get; set; }
        public string InvoiceNo { get; set; }
        public int? PaymentBy { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string PaymentName { get; set; }
        public string PaymentCard { get; set; }
        public bool? CancelOrder { get; set; }
    }
}
