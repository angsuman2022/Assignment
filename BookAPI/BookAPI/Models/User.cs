using System;
using System.Collections.Generic;

#nullable disable

namespace BookAPI.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Type { get; set; }
        public string Password { get; set; }
    }
}
