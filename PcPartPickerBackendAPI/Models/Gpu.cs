using System;
using System.Collections.Generic;

namespace PcPartPickerBackendAPI.Models
{
    public partial class Gpu : Part
    {
        public string Color { get; set; }
        public string Interface { get; set; }
        public string Chipset { get; set; }
        public int? Memorysize { get; set; }
        public string Memorytype { get; set; }
        public short? Coreclock { get; set; }
        public short? Boostclock { get; set; }
        public short? Tdp { get; set; }
        public bool? Isfanincluded { get; set; }
        public bool? Isslisupported { get; set; }
        public string Iscrossfiresupported { get; set; }
        public double? Cardlength { get; set; }
        public bool? Isadaptivesyncsupported { get; set; }
        public byte? Dvicount { get; set; }
        public byte? Displayportcount { get; set; }
        public byte? Hdmicount { get; set; }
        public byte? Vgacount { get; set; }
        public byte? Minidpcount { get; set; }
        public byte? Svideocount { get; set; }
    }
}
