using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Models
{
    public partial class Order
    {
        public int PaymentId { get; set; }
        public int? BookId { get; set; }
        public string BookTitle { get; set; }
        public decimal? BookPrice { get; set; }
        public string InvoiceNo { get; set; }
        public int? PaymentBy { get; set; }
        public string? PaymentDate { get; set; }
        public string PaymentName { get; set; }
        public string PaymentCard { get; set; }
        public bool? CancelOrder { get; set; }
    }
}
