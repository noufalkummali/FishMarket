using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FishMarketing.ViewModel
{
    public class PurchasePlaceVm
    {
        public int PurchasePlaceId { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        [Display(Name = "Name")]
        public string Name { get; set; }
        public string Address { get; set; }
        public string Place { get; set; }
        [Display(Name = "Type")]
        public string Type { get; set; }
        [Display(Name = "Mobile")]
        public string MobileNumber { get; set; }
        [Display(Name = "Contact Name")]
        public string ContactName { get; set; }
        public decimal ProfCommission { get; set; }//0% normal
        public decimal Deposit { get; set; }
        public decimal Advance { get; set; }
        [Display(Name = "Is Active")]
        public bool IsActive { get; set; }
        public string Code { get; set; }
    }
}
