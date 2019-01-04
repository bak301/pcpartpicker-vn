using System;
using System.Collections.Generic;

namespace PcPartPickerBackendAPI.Models
{
    public partial class Image
    {
        public int Id { get; set; }
        public int Partid { get; set; }
        public string ImageUrl { get; set; }

        public Part Part { get; set; }
    }
}
