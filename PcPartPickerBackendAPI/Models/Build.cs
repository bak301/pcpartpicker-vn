using System;
using System.Collections.Generic;

namespace PcPartPickerBackendAPI.Models
{
    public partial class Build
    {
        public int Id { get; set; }
        public int? Cpu { get; set; }
        public int? Motherboard { get; set; }
        public int? Memory { get; set; }
        public int? Gpu { get; set; }
        public int? Storage { get; set; }
        public int? Powersupply { get; set; }
        public int? Pccase { get; set; }
        public string Buildname { get; set; }
        public DateTime? Builddate { get; set; }
        public int IdUser { get; set; }

        public Cpu CpuNavigation { get; set; }
        public Gpu GpuNavigation { get; set; }
        public Memory MemoryNavigation { get; set; }
        public Motherboard MotherboardNavigation { get; set; }
        public Pccase PccaseNavigation { get; set; }
        public Powersupply PowersupplyNavigation { get; set; }
        public Storage StorageNavigation { get; set; }
        public User UserNavigation { get; set; }
    }
}
