using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FishMarketing.ViewModel
{
    public class BoxMarkVm
    {
        public int BoxMarkId { get; set; }
        [Required(ErrorMessage = "Please enter name")]
        [Display(Name = "Box Mark")]
        public string BoxMarkName { get; set; }
        public string Remarks { get; set; }
    }
}
