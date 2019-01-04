using System;
using System.Collections.Generic;

namespace PcPartPickerBackendAPI.Models
{
    public partial class Part
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public string Partname { get; set; }
    }
}
