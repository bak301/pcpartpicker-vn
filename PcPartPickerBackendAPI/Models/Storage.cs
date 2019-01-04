using System;
using System.Collections.Generic;

namespace PcPartPickerBackendAPI.Models
{
    public partial class Storage
    {
        public Storage()
        {
            Build = new HashSet<Build>();
        }

        public int Id { get; set; }
        public short? Capacity { get; set; }
        public string Interface { get; set; }
        public short? Cache { get; set; }
        public short? Rpm { get; set; }
        public string Formfactor { get; set; }
        public string Nandtype { get; set; }
        public string Ssdcontroller { get; set; }
        public int? Hybridssdcache { get; set; }

        public Part IdNavigation { get; set; }
        public ICollection<Build> Build { get; set; }
    }
}
