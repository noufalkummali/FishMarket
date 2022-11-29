using System;
using System.Collections.Generic;

#nullable disable

namespace FishMarketing.Models
{
    public partial class Vehicle
    {
        public int VehicleId { get; set; }
        public string VehicleNumber { get; set; }
        public string OwnerName { get; set; }
        public string Rcnumber { get; set; }
        public DateTime? RcexpDate { get; set; }
        public DateTime? PolutionExpDate { get; set; }
        public DateTime? InsuranceExpDate { get; set; }
        public int Clogin { get; set; }
        public DateTime Cdate { get; set; }
        public int? Mlogin { get; set; }
        public DateTime? Mdate { get; set; }
    }
}
