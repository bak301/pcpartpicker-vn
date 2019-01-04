using System;
using System.Collections.Generic;

namespace PcPartPickerBackendAPI.Models
{
    public partial class Pccase
    {

        public int Id { get; set; }
        public string Color { get; set; }
        public string Type { get; set; }
        public short? Wattagepsuincluded { get; set; }
        public byte? Internal525baycount { get; set; }
        public byte? Internal35baycount { get; set; }
        public byte? External525baycount { get; set; }
        public byte? External35baycount { get; set; }
        public string Motherboardformsupported { get; set; }
        public bool? Isfrontusb3supported { get; set; }
        public double? Vgamaxlength { get; set; }
        public string Dimensions { get; set; }

        public Part IdNavigation { get; set; }
        public ICollection<Build> Build { get; set; }
    }
}
