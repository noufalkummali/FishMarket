using System;
using System.Collections.Generic;

#nullable disable

namespace FishMarketing.Models
{
    public partial class Setting
    {
        public int SettingsId { get; set; }
        public string Value { get; set; }
        public string Description { get; set; }
        public DateTime Cdate { get; set; }
        public DateTime? Mdate { get; set; }
    }
}
