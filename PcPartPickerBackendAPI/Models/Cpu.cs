using System;
using System.Collections.Generic;

namespace PcPartPickerBackendAPI.Models
{
    public partial class Cpu : Part
    {
        public byte? Datawidth { get; set; }
        public string Socket { get; set; }
        public double? Basefrequency { get; set; }
        public double? Boostfrequency { get; set; }
        public byte? Corescount { get; set; }
        public string L1cache { get; set; }
        public string L2cache { get; set; }
        public string L3cache { get; set; }
        public short? Lithography { get; set; }
        public short? Tdp { get; set; }
        public bool? Iscoolerincluded { get; set; }
        public bool? Ishyperthreaded { get; set; }
        public short? Maxmemory { get; set; }
        public string Igpu { get; set; }
    }
}
