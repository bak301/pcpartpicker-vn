using System;
using System.Collections.Generic;

namespace PcPartPickerBackendAPI.Models
{
    public partial class Memory
    {
        public Memory()
        {
            Build = new HashSet<Build>();
        }

        public int Id { get; set; }
        public string Color { get; set; }
        public string Memorytype { get; set; }
        public short? Speed { get; set; }
        public string Sticksize { get; set; }
        public string Memorytiming { get; set; }
        public double? Memoryvoltage { get; set; }
        public bool? Isheatspreaderincluded { get; set; }
        public bool? Isecc { get; set; }
        public bool? Isregistered { get; set; }

        public Part IdNavigation { get; set; }
        public ICollection<Build> Build { get; set; }
    }
}
