using System;
using System.Collections.Generic;

namespace PcPartPickerBackendAPI.Models
{
    public partial class Motherboard
    {
        public Motherboard()
        {
            Build = new HashSet<Build>();
        }

        public int Id { get; set; }
        public string Color { get; set; }
        public string Formfactor { get; set; }
        public string Socket { get; set; }
        public string Chipset { get; set; }
        public byte? Memoryslots { get; set; }
        public string Memorytype { get; set; }
        public short? Memorymaxsize { get; set; }
        public bool? Raidsupport { get; set; }
        public bool? Isigpusupported { get; set; }
        public bool? Isxfiresupported { get; set; }
        public bool? Isslisupported { get; set; }
        public byte? Sata3portcounts { get; set; }
        public string Onboardethernet { get; set; }
        public bool? Isusb3supported { get; set; }

        public Part IdNavigation { get; set; }
        public ICollection<Build> Build { get; set; }
    }
}
