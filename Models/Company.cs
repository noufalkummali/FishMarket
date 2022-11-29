using System;
using System.Collections.Generic;

#nullable disable

namespace FishMarketing.Models
{
    public partial class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string RegNo { get; set; }
        public string Address { get; set; }
        public string Location { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileNumber { get; set; }
        public byte[] Logo { get; set; }
        public DateTime Cdate { get; set; }
        public DateTime? Mdate { get; set; }
        public string Type { get; set; }
    }
}
