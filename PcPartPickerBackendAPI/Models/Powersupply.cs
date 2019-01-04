using System;
using System.Collections.Generic;

namespace PcPartPickerBackendAPI.Models
{
    public partial class Powersupply
    {
        public Powersupply()
        {
            Build = new HashSet<Build>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public short? Wattage { get; set; }
        public string Modularity { get; set; }
        public string Efficiencycert { get; set; }
        public byte? Pcie62connectorcount { get; set; }
        public byte? Pcie6connectorcount { get; set; }
        public byte? Pcie8connectorcount { get; set; }
        public string Output { get; set; }

        public Part IdNavigation { get; set; }
        public ICollection<Build> Build { get; set; }
    }
}
