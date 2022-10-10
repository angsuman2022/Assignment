using System;
using System.Collections.Generic;

#nullable disable

namespace ReaderAPI.Models
{
    public partial class TblInvoice
    {
        public string Year { get; set; }
        public string Month { get; set; }
        public int? SlNo { get; set; }
        public bool? Active { get; set; }
    }
}
