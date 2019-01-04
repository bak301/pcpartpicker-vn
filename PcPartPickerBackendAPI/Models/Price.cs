using System;
using System.Collections.Generic;

namespace PcPartPickerBackendAPI.Models
{
    public partial class Price
    {
        public int Id { get; set; }
        public int Partid { get; set; }
        public string Merchant { get; set; }
        public int Baseprice { get; set; }
        public int? Promotion { get; set; }
        public string Url { get; set; }
        public bool? Isinstock { get; set; }
        public DateTime? Date { get; set; }
    }
}
