using System;
using System.Collections.Generic;

#nullable disable

namespace AuthorAPI.Models
{
    public partial class BookDet
    {
        public int Id { get; set; }
        public string BookTitle { get; set; }
        public string BookCategory { get; set; }
        public string BookImg { get; set; }
        public decimal? BookPrice { get; set; }
        public string BookPublish { get; set; }
        public bool? Active { get; set; }
        public string BookContent { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? CreateBy { get; set; }
        public DateTime? ModyDate { get; set; }
        public string PublishDate { get; set; }
    }
}
