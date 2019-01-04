using System;
using System.Collections.Generic;

namespace PcPartPickerBackendAPI.Models
{
    public partial class Link
    {
        public int Id { get; set; }
        public int? Partid { get; set; }
        public string Merchant { get; set; }
        public string Url { get; set; }

        public Part Part { get; set; }
    }
}
